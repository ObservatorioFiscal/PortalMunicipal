using GastoTransparenteMunicipal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class FeaturedDataController : BaseController
    {
        [HttpGet]
        public ActionResult Subsidy()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Init(db, idMunicipality);
            return View(subsidioModel);
        }

        [HttpPost]
        public ActionResult Subsidy(int year)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Load(db, idMunicipality,year);
            return View(subsidioModel);
        }

        [HttpPost]
        public string SubsidyAjaxNivel1()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Init(db, idMunicipality);
            return subsidioModel.JsonSubsidio;
        }

        public string SubsidyChartNivel3(int IdNivel2)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Load_Nivel3(db, IdNivel2);
            var json = JsonConvert.SerializeObject(subsidioModel.Subsidio_Nivel3);

            return json;
        }

        [HttpGet]
        public ActionResult Providers()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var takeElements = 20;

            ProveedorModel proveedorModel = new ProveedorModel();
            proveedorModel.Init(db, takeElements, idMunicipality);
            
            return View(proveedorModel);
        }

        [HttpPost]
        public ActionResult Providers(int year,int origenData)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var takeElements = 20;
            ProveedorModel proveedorModel = new ProveedorModel();
            proveedorModel.WordCloud(db, takeElements, idMunicipality, year,origenData);

            return View(proveedorModel);
        }

        [HttpGet]
        public ActionResult Corporation()
        {   
            return View();
        }


        public string CorporationAjax()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            CorporacionModel corporacion = new CorporacionModel();
            corporacion.Init(db, idMunicipality);
            return corporacion.JsonCorporacion_Nivel1;
        }

        [HttpPost]
        public ActionResult Corporation(int year)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            CorporacionModel corporacion = new CorporacionModel();
            corporacion.Load(db, idMunicipality, year);
            return View(corporacion);
        }

        [HttpGet]
        public ActionResult PersonalSalary()
        {
            var idMunicipality = GetCurrentIdMunicipality();

            PersonalModel personalModel = new PersonalModel();
            personalModel.Init(db, idMunicipality);

            return View(personalModel);
        }

        [HttpPost]
        public ActionResult PersonalSalary(int year, int origenData)
        {
            var idMunicipality = GetCurrentIdMunicipality();

            PersonalModel personalModel = new PersonalModel();
            personalModel.LoadPersonal(db, idMunicipality ,year ,origenData);

            return View(personalModel);
        }
    }
}