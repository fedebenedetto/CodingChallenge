using CodingChallenge.Data.Classes;
using CodingChallenge.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodingChallenge.Service
{
    public class ReporteService
    {
        private readonly IReporte reporte;

        public ReporteService()
        {
            this.reporte = new FormaGeometrica();
        }

        public string ObtenerReporte(List<FormaGeometricaModel> formas,int idioma)
        {
            try
            {
                var reporteString = reporte.Imprimir(formas, idioma);
                return reporteString;
            }
            catch (Exception)
            {
                return "Ocurrio un error al obtener el reporte";
            }
        }

        public SelectList CargarComboFormas()
        {
            try
            {
                var formas = reporte.ObtenerFormas();

                SelectList listaFinalFormas;
                List<SelectListItem> items = new List<SelectListItem>();

                SelectListItem itemZero = new SelectListItem();
                itemZero.Value = "" + 0;
                itemZero.Text = "--Seleccione forma--";

                items.Insert(0, itemZero);

                foreach (var item in formas)
                {
                    SelectListItem itemLista = new SelectListItem();
                    itemLista.Value = item.Tipo.ToString();
                    itemLista.Text = item.Nombre;

                    items.Add(itemLista);
                }

                listaFinalFormas = new SelectList(items, "Value", "Text");

                return listaFinalFormas;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
