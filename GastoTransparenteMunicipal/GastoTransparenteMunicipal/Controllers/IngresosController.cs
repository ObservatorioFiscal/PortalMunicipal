using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class IngresosController : Controller
    {
        // GET: Ingresos
        public ActionResult Index()
        {
            ViewBag.Ingreso = "active";
            ViewBag.Destacado = "hidden";
            return View();
        }
        
    }
}
