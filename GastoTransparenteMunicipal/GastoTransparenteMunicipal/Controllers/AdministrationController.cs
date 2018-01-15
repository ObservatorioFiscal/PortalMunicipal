using GastoTransparenteMunicipal.Helpers;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class AdministrationController : BaseController
    {
        // GET: Administration
        public ActionResult CargaInformeGasto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformeGasto(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            DateTime data = DateTime.Now;
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();                
                var result = loadReport.LoadInformeGasto( xssfwb, year, idMunicipality);
                db.InformeGasto.AddRange(result);
                db.SaveChanges();

                Guid loadReportGuid = result.First().IdGroupInformeGasto.Value;
                db.SP_InformeGasto(loadReportGuid);
            }
            DateTime data2 = DateTime.Now;
            return View();
        }
    }
}