using CodingChallenge.Data.Classes;
using CodingChallenge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Service
{
    public class ReporteService
    {
        public readonly IReporte reporte;

        public ReporteService()
        {
            this.reporte = new FormaGeometrica();
        }
    }
}
