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
            var municipalidad = GetCurrentIdMunicipality();
            if(municipalidad != null)
            {
                ViewBag.activos = new List<bool>
                {
                    municipalidad.Act_Proveedor,municipalidad.Act_Subsidio,municipalidad.Act_Corporacion,municipalidad.Act_Personal
                };
                ViewBag.logo = municipalidad.DireccionWeb + ".png";
                ViewBag.Inicio = "active";
                ViewBag.Destacado = "hidden";
                ViewBag.texto1 = municipalidad.Periodo;
                ViewBag.texto2 = municipalidad.TotalGastado;
                ViewBag.texto3 = municipalidad.TotalPresupuestado;
                return View();
            }
            else
            {
                return RedirectToAction("NoExiste");
            }
            
        }

        public ActionResult About()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.activos = new List<bool>
            {
                municipalidad.Act_Proveedor,municipalidad.Act_Subsidio,municipalidad.Act_Corporacion,municipalidad.Act_Personal
            };
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Destacado = "hidden";
            return View();
        }
    }
}