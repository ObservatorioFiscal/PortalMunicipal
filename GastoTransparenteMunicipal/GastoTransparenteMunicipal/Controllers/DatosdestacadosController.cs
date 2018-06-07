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
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.DireccionWeb+".png";
            ViewBag.Anos = new SelectList(db.Personal_Ano_Visible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            ViewBag.Sueldos = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Proveedores()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Anos = new SelectList(db.Proveedor_Ano_Visible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            ViewBag.Proveedores = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Subsidios()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Anos = new SelectList(db.Subsidio_Ano_Visible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            ViewBag.Subsidios = "active";
            return View();
        }

        // GET: Datosdestacados
        public ActionResult Corporaciones()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Anos = new SelectList(db.Corporacion_Ano_Visible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            ViewBag.Corporaciones = "active";
            return View();
        }

    }
}
