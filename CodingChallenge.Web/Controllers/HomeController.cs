using CodingChallenge.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        private ReporteService reporteService;

        public HomeController()
        {
            reporteService = new ReporteService();
        }

        public ActionResult Index()
        {
            var comboFormas = reporteService.CargarComboFormas();
            ViewBag.Formas = comboFormas;
            return View();
        }

        [HttpPost]
        public ActionResult Imprimir(List<FormaGeometricaModel> formas, int idioma)
        {
            try
            {
                var reporte = reporteService.ObtenerReporte(formas, idioma);
                return this.Json(new
                {
                    ok = true,
                    msj = reporte
                });
            }
            catch (Exception)
            {
                string msj = "Ocurrió un error al obtener el reporte";
                return this.Json(new
                {
                    ok = true,
                    msj = msj
                });

            }
        }
    }
}