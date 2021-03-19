using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Interface;
using Model;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private readonly IReporte reporte;

        public DataTests(IReporte reporte)
        {
            this.reporte = new FormaGeometrica();
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                reporte.Imprimir(new List<FormaGeometricaModel>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                reporte.Imprimir(new List<FormaGeometricaModel>(), 2));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnPortugues()
        {
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                reporte.Imprimir(new List<FormaGeometricaModel>(), 3));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometricaModel>();
            cuadrados.Add(new FormaGeometricaModel { Tipo = FormaGeometrica.Cuadrado, Nombre = "Cuadrado", Lado = 5 });

            var resumen = reporte.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometricaModel>
            {
                new FormaGeometricaModel{ Tipo = FormaGeometrica.Cuadrado,Nombre = "Cuadrado",Lado = 5 },
                new FormaGeometricaModel{ Tipo = FormaGeometrica.Cuadrado,  Nombre = "Cuadrado",Lado = 1 },
                new FormaGeometricaModel{Tipo = FormaGeometrica.Cuadrado,  Nombre = "Cuadrado",Lado = 3 }
            };

        var resumen = reporte.Imprimir(cuadrados, FormaGeometrica.Ingles);

        Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

    [TestCase]
    public void TestResumenListaConMasTipos()
    {
        var formas = new List<FormaGeometricaModel>
            {
                new FormaGeometricaModel{Tipo = FormaGeometrica.Cuadrado,  Nombre = "Cuadrado",Lado = 5 },
                new FormaGeometricaModel{Tipo = FormaGeometrica.Circulo,  Nombre = "Circulo",Lado = 3 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.TrianguloEquilatero,  Nombre = "Triangulo Equilatero",Lado = 4 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.Cuadrado,  Nombre = "Cuadrado",Lado = 2 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.TrianguloEquilatero,  Nombre = "Triangulo Equilatero",Lado = 9 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.Circulo,  Nombre = "Circulo",Lado = 2.75m },
                new FormaGeometricaModel{Tipo =FormaGeometrica.TrianguloEquilatero,  Nombre = "Triangulo Equilatero",Lado = 4.2m }
            };

        var resumen = reporte.Imprimir(formas, FormaGeometrica.Ingles);

        Assert.AreEqual(
            "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
            resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTiposEnCastellano()
    {
        var formas = new List<FormaGeometricaModel>
            {
                new FormaGeometricaModel{Tipo =FormaGeometrica.Cuadrado,  Nombre = "Cuadrado",Lado = 5 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.Circulo,  Nombre = "Circulo",Lado = 3 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.TrianguloEquilatero,  Nombre = "Triangulo Equilatero",Lado = 4 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.Cuadrado,  Nombre = "Cuadrado",Lado = 2 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.TrianguloEquilatero,  Nombre = "Triangulo Equilatero",Lado = 9 },
                new FormaGeometricaModel{Tipo =FormaGeometrica.Circulo,  Nombre = "Circulo",Lado = 2.75m },
                new FormaGeometricaModel{Tipo =FormaGeometrica.TrianguloEquilatero,  Nombre = "Triangulo Equilatero",Lado = 4.2m }
            };

        var resumen = reporte.Imprimir(formas, FormaGeometrica.Castellano);

        Assert.AreEqual(
            "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
            resumen);
    }
}
}
