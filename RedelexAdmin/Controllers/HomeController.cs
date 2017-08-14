using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedelexBLL;

namespace RedelexAdmin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [VerifyUserAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KeepAlive()
        {
            return View();
        }


        public ActionResult Estadisticas(string ClaseEstadistica)
        {
            RedelexDTO.Estadisticas _est  = new RedelexDTO.Estadisticas(30);

            //RedelexBLL.Estadisticas _est = new RedelexBLL.Estadisticas(30, ClaseEstadistica);

            _est.Estadistica = RedelexBLL.Estadisticas.GetEstadisticas(30, ClaseEstadistica);

            ViewBag.FechaInicial = _est.FechaIniString;
            ViewBag.FechaFinal = _est.FechaFinString;
            ViewBag.ClaseEstadistica = ClaseEstadistica;

            return View(_est);
        }

        [VerifyUserAttribute]
        public ActionResult DashboardCuentas()
        {
            return View();
        }

    }
}
