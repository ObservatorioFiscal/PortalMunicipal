using System;
using System.Collections.Generic;
using GastoTransparenteMunicipal.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Newtonsoft.Json;

namespace GastoTransparenteMunicipal.Controllers
{
    public class AdminComunaController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CargaDatos()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.Anos = new SelectList(db.Gasto_Ano.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            return View();
        }
    }

}
