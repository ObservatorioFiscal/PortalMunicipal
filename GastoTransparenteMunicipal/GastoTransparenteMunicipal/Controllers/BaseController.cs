using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class BaseController : Controller
    {
        public string GetCurrentMunicipality()
        {
            var municipality = RouteData.Values["municipality"].ToString();
            return municipality;
        }
    }
}