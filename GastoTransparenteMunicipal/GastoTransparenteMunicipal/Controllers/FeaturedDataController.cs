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
        // GET: FeaturedData
        public ActionResult Subsidy()
        {
            return View();
        }

        public ActionResult SubsidyAjax()
        {
            var jsonDocument = System.IO.File.ReadAllText(@"C:\Users\Gonzalo\Documents\Visual Studio 2017\Projects\GastoTransparenteMunicipal\GastoTransparenteMunicipal\Scripts\FeaturedData\bubbleDataTest.json");
            //var json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonDocument).ToString();    
            return this.Content(jsonDocument, "application/json");            
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


        public ActionResult Corporation()
        {
            return View();
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

        public ActionResult Test()
        {
            return View();
        }

        public class Tupla
        {
            public string Proveedor { get; set; }
            public long? Monto{ get; set; }
        }
    }
}