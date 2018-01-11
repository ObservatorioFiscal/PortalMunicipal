using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class GastosController : Controller
    {
        // GET: Gastos
        public ActionResult Index()
        {
            ViewBag.Gasto = "active";
            ViewBag.Destacado = "hidden";
            return View();
        }

        
    }
}
