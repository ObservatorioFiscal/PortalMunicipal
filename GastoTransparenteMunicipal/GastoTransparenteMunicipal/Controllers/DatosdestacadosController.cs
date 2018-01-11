using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class DatosdestacadosController : Controller
    {
        // GET: Datosdestacados
        public ActionResult Sueldos()
        {
            ViewBag.Sueldos = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Proveedores()
        {
            ViewBag.Proveedores = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Subsidios()
        {
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Corporaciones()
        {
            return View();
        }

    }
}
