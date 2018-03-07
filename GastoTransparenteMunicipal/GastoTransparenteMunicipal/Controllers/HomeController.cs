using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var value = GetCurrentMunicipality();
            ViewBag.logo = value;
            ViewBag.Inicio = "active";
            ViewBag.Destacado = "hidden";
            return View();
        }
        
    }
}