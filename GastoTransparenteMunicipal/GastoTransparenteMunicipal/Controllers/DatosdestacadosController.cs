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
    public class DatosdestacadosController : BaseController
    {                
        // GET: Datosdestacados
        public ActionResult Sueldos()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var value = GetCurrentMunicipality();
            ViewBag.logo = value;
            ViewBag.Anos = new SelectList(db.Personal_Ano.Where(r => r.IdMunicipalidad == idMunicipality), "IdAno", "Ano");
            ViewBag.Sueldos = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Proveedores()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var value = GetCurrentMunicipality();
            ViewBag.logo = value;
            ViewBag.Anos = new SelectList(db.Proveedor_Ano.Where(r => r.IdMunicipalidad == idMunicipality), "IdAno", "Ano");
            ViewBag.Proveedores = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Subsidios()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var value = GetCurrentMunicipality();
            ViewBag.logo = value;
            ViewBag.Anos = new SelectList(db.Subsidio_Ano.Where(r => r.IdMunicipalidad == idMunicipality), "IdAno", "Ano");
            ViewBag.Subsidios = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Corporaciones()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var value = GetCurrentMunicipality();
            ViewBag.logo = value;
            ViewBag.Anos = new SelectList(db.Corporacion_Ano.Where(r => r.IdMunicipalidad == idMunicipality), "IdAno", "Ano");
            ViewBag.Corporaciones = "active";
            return View();
        }

    }
}
