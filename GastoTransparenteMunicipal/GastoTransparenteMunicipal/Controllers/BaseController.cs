using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class BaseController : Controller
    {
        public GastoTransparenteMunicipalEntities db = new GastoTransparenteMunicipalEntities();

        public string GetCurrentMunicipality()
        {
            var municipalityName = RouteData.Values["municipality"].ToString();
            return municipalityName;
        }

        public Municipalidad GetCurrentIdMunicipality()
        {
            var municipalityName = RouteData.Values["municipality"].ToString();
            var municipality = db.Municipalidad.SingleOrDefault(r => r.DireccionWeb == municipalityName);
            return municipality;
        }        
    }
}