using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class AdminComunaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CargaDatos()
        {
            return View();
        }
    }

}
