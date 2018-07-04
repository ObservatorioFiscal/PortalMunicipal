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
            if (municipalidad == null)
                return RedirectToAction("List");

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
            ViewBag.nombre = municipalidad.Nombre;
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewBag.Destacado = "hidden";
            ViewBag.administracion = true;
            ViewBag.logo = "municipio.png";

            var municipios = db.Municipalidad.Where(r => r.Activa == true).ToList();
            return View(municipios);
        }

        public ActionResult List2()
        {
            return View();
        }
    }
}