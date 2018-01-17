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
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();                
                var result = loadReport.LoadInformeGasto( xssfwb, year, idMunicipality);
                db.InformeGasto.AddRange(result);
                db.SaveChanges();
                
                db.SP_InformeGasto(loadReport.IdGroupInforme);
            }            
            return View();
        }

        public ActionResult CargaInformeSubsidio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformeSubsidio(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            DateTime data = DateTime.Now;
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeSubsidio(xssfwb, year, idMunicipality);
                db.InformeSubsidio.AddRange(result);
                db.SaveChanges();
                
                db.SP_InformeSubsidio(loadReport.IdGroupInforme);
            }            
            return View();
        }

        public ActionResult CargaInformePersonal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformePersonal(HttpPostedFileBase admServicios, HttpPostedFileBase salud, HttpPostedFileBase educacion, HttpPostedFileBase cementerio = null)
        {
            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            DateTime data = DateTime.Now;
            LoadReport loadReport = new LoadReport();

            if (admServicios != null)
            {
                using (Stream fileStream = admServicios.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    
                    var result = loadReport.LoadInformePersonalAdmServicios(xssfwb, year, idMunicipality);
                    db.InformePersonalAdmServicios.AddRange(result);
                    db.SaveChanges();

                    db.SP_InformePersonalAdmServicios(loadReport.IdGroupInforme);
                    db.SP_PersonalAdmServicios_RangoAntiguedad(loadReport.IdGroupInforme);
                }
            }

            if (salud != null)
            {
                using (Stream fileStream = salud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);                    
                    var result = loadReport.LoadInformePersonalSalud(xssfwb, year, idMunicipality);
                    db.InformePersonalSalud.AddRange(result);
                    db.SaveChanges();

                    db.SP_InformePersonalSalud(loadReport.IdGroupInforme);
                    db.SP_PersonalSalud_RangoAntiguedad(loadReport.IdGroupInforme);
                }
            }
            
            if (educacion != null)
            {
                using (Stream fileStream = educacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);                    
                    var result = loadReport.LoadInformePersonalEducacion(xssfwb, year, idMunicipality);
                    db.InformePersonalEducacion.AddRange(result);
                    db.SaveChanges();

                    db.SP_InformePersonalEducacion(loadReport.IdGroupInforme);
                    db.SP_PersonalEducacion_RangoAntiguedad(loadReport.IdGroupInforme);
                }
            }

            if (cementerio != null)
            {
                using (Stream fileStream = cementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);                    
                    var result = loadReport.LoadInformePersonalCementerio(xssfwb, year, idMunicipality);
                    db.InformePersonalCementerio.AddRange(result);
                    db.SaveChanges();

                    db.SP_InformePersonalCementerio(loadReport.IdGroupInforme);
                    db.SP_PersonalCementerio_RangoAntiguedad(loadReport.IdGroupInforme);
                }

            }

            db.SP_InformePersonalMunicipioTotal(loadReport.IdGroupInforme);
            db.SP_PersonalMunicipioTotal_RangoAntiguedad(loadReport.IdGroupInforme);

            return View();
        }
    }
}