﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class FeaturedDataController : Controller
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

        public ActionResult Providers()
        {
            return View();
        }

        public ActionResult Corporation()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}