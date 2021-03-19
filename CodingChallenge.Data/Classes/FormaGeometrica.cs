/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica : IReporte
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Portuges = 3;

        #endregion



        public FormaGeometrica()
        {

        }

        public string Imprimir(List<FormaGeometricaModel> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else if(idioma == Ingles)
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");
                else
                    sb.Append("<h1>Relatório de formas</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecios = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecios = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecios = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += CalcularArea(formas[i]);
                        perimetroCuadrados += CalcularPerimetro(formas[i]);
                    }
                    else if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += CalcularArea(formas[i]);
                        perimetroCirculos += CalcularPerimetro(formas[i]);
                    }
                    else if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += CalcularArea(formas[i]);
                        perimetroTriangulos += CalcularPerimetro(formas[i]);
                    }
                    else
                    {
                        numeroTrapecios++;
                        areaTrapecios += CalcularArea(formas[i]);
                        perimetroTrapecios += CalcularPerimetro(formas[i]);
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));
                sb.Append(ObtenerLinea(numeroTrapecios, areaTrapecios, perimetroTrapecios, Trapecio, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == Castellano || idioma == Portuges ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos+perimetroTrapecios).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos+areaTrapecios).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else if (idioma == Portuges) return cantidad == 1 ? "Quadrado" : "Quadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano || idioma == Portuges) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else if (idioma == Portuges) return cantidad == 1 ? "Triângulo" : "Triângulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
                case Trapecio:
                    if (idioma == Castellano) return cantidad == 1 ? "Trapecio" : "Trapecios";
                    else if (idioma == Portuges) return  "Trapézio";
                    else return cantidad == 1 ? "Trapeze" : "Trapezoids";
            }

            return string.Empty;
        }

        public static decimal CalcularArea(FormaGeometricaModel forma)
        {
            switch (forma.Tipo)
            {
                case Cuadrado: return forma.Lado * forma.Lado;
                case Circulo: return (decimal)Math.PI * (forma.Lado / 2) * (forma.Lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * forma.Lado * forma.Lado;
                case Trapecio: return ((forma.Lado * 2) / 2) * 2;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public static decimal CalcularPerimetro(FormaGeometricaModel forma)
        {
            switch (forma.Tipo)
            {
                case Cuadrado: return forma.Lado * 4;
                case Circulo: return (decimal)Math.PI * forma.Lado;
                case TrianguloEquilatero: return forma.Lado * 3;
                case Trapecio: return forma.Lado + forma.Lado * 4;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public List<FormaModel> ObtenerFormas()
        {
            List<FormaModel> models = new List<FormaModel>();
            models.Add(new FormaModel { Tipo = Cuadrado, Nombre = "Cuadrado" });
            models.Add(new FormaModel { Tipo = TrianguloEquilatero, Nombre = "Triangulo Equilatero" });
            models.Add(new FormaModel { Tipo = Circulo, Nombre = "Circulo" });
            models.Add(new FormaModel { Tipo = Trapecio, Nombre = "Trapecio" });

            return models;
        }
    }
}
