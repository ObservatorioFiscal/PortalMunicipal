using GastoTransparenteMunicipal.Helpers;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;

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
            int month = 0;
            Gasto_Ano gastoAno = new Gasto_Ano { IdMunicipalidad = idMunicipality, Ano = year, Mes = month, UpdatedOn = DateTime.Now };
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeGasto(xssfwb);
                db.GastoInforme.AddRange(result);                
                db.Gasto_Ano.Add(gastoAno);

                db.SaveChanges();                
                db.SP_InformeGasto(loadReport.IdGroupInforme,gastoAno.IdAno);
            }            
            return View();
        }

        public ActionResult CargaInformeIngreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformeIngreso(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            int month = 0;

            Ingreso_Ano ingresoAno = new Ingreso_Ano { IdMunicipalidad = idMunicipality, Ano = year, Mes = month, UpdatedOn = DateTime.Now };
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeIngreso(xssfwb);
                db.IngresoInforme.AddRange(result);
                db.Ingreso_Ano.Add(ingresoAno);

                db.SaveChanges();

                db.SP_InformeIngreso(loadReport.IdGroupInforme, ingresoAno.IdAno);
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
            int month = 0;
            Subsidio_Ano subsidioAno = new Subsidio_Ano { IdMunicipalidad = idMunicipality, Ano = year, Mes = month, UpdatedOn = DateTime.Now };

            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeSubsidio(xssfwb);
                db.SubsidioInforme.AddRange(result);
                db.Subsidio_Ano.Add(subsidioAno);
                db.SaveChanges();

                db.SP_InformeSubsidio(loadReport.IdGroupInforme, subsidioAno.IdAno);
            }
            return View();
        }

        public ActionResult CargaInformePersonal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformePersonal(HttpPostedFileBase admServicios, HttpPostedFileBase salud, HttpPostedFileBase educacion, HttpPostedFileBase cementerio)
        {
            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            int month = 0;

            DateTime data = DateTime.Now;
            LoadReport loadReport = new LoadReport();
            Personal_Ano personalAno = new Personal_Ano { IdMunicipalidad = idMunicipality, Ano = year, Mes = month, UpdatedOn = DateTime.Now };

            if (admServicios != null || salud != null || educacion != null || cementerio != null)
            {
                db.Personal_Ano.Add(personalAno);
                db.SaveChanges();
            }
            else
            {
                return View();
            }

            if (admServicios != null)
            {
                using (Stream fileStream = admServicios.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);

                    var result = loadReport.LoadInformePersonalAdmServicios(xssfwb);
                    db.Personal_AdmInforme.AddRange(result);                    

                    db.SaveChanges();
                    db.SP_InformePersonalAdm(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            if (salud != null)
            {
                using (Stream fileStream = salud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalSalud(xssfwb);
                    db.Personal_SaludInforme.AddRange(result);                    

                    db.SaveChanges();
                    db.SP_InformePersonalSalud(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            if (educacion != null)
            {
                using (Stream fileStream = educacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalEducacion(xssfwb);
                    db.Personal_EducacionInforme.AddRange(result);                                        

                    db.SaveChanges();
                    db.SP_InformePersonalEducacion(loadReport.IdGroupInforme, personalAno.IdAno);                    
                }
            }

            if (cementerio != null)
            {
                using (Stream fileStream = cementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalCementerio(xssfwb);
                    db.Personal_CementerioInforme.AddRange(result);                    

                    db.SaveChanges();
                    db.SP_InformePersonalCementerio(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            db.SP_InformePersonalMunicipioTotal(loadReport.IdGroupInforme,personalAno.IdAno);            

            return View();
        }

        public ActionResult CargaInformeProveedores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformeProveedores(HttpPostedFileBase admServicios, HttpPostedFileBase salud, HttpPostedFileBase educacion, HttpPostedFileBase cementerio)
        {
            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            int month = 0;
            LoadReport loadReport = new LoadReport();
            Proveedor_Ano proveedorAno = new Proveedor_Ano { IdMunicipalidad = idMunicipality, Ano = year, Mes = month, UpdatedOn = DateTime.Now };
            if (admServicios != null || salud  != null || educacion != null || cementerio != null)
            {
                db.Proveedor_Ano.Add(proveedorAno);
                db.SaveChanges();
            }
            else
            {
                return View();
            }

            if (admServicios != null)
            {
                using (Stream fileStream = admServicios.InputStream)
                {                    
                    xssfwb = new XSSFWorkbook(fileStream);

                    var result = loadReport.LoadInformeProveedoresAdmServicios(xssfwb);
                    db.Proveedor_AdmInforme.AddRange(result);                    
                    db.SaveChanges();

                    db.SP_ProveedorAdm(loadReport.IdGroupInforme,proveedorAno.IdAno);
                }
            }

            if (salud != null)
            {
                using (Stream fileStream = salud.InputStream)
                {                    
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresSalud(xssfwb);
                    db.Proveedor_SaludInforme.AddRange(result);                    
                    db.SaveChanges();

                    db.SP_ProveedorSalud(loadReport.IdGroupInforme,proveedorAno.IdAno);
                }
            }

            if (educacion != null)
            {
                using (Stream fileStream = educacion.InputStream)
                {                    
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresEducacion(xssfwb);
                    db.Proveedor_EducacionInforme.AddRange(result);                    
                    db.SaveChanges();

                    db.SP_ProveedorEducacion(loadReport.IdGroupInforme,proveedorAno.IdAno);
                }
            }

            if (cementerio != null)
            {
                using (Stream fileStream = cementerio.InputStream)
                {                    
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresCementerio(xssfwb);
                    db.Proveedor_CementerioInforme.AddRange(result);                    
                    db.SaveChanges();

                    db.SP_ProveedorCementerio(loadReport.IdGroupInforme, proveedorAno.IdAno);
                }

            }
            
            db.SaveChanges();
            db.SP_ProveedorTotal(loadReport.IdGroupInforme, proveedorAno.IdAno);

            return View();
        }

        public ActionResult CargaInformeCorporaciones()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaInformeCorporaciones(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality();
            int year = 2017;
            int month = 0;

            DateTime data = DateTime.Now;
            Corporacion_Ano corporacionAno = new Corporacion_Ano { IdMunicipalidad = idMunicipality, Ano = year, Mes = month, UpdatedOn = DateTime.Now };
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeCorporaciones(xssfwb);
                db.CorporacionInforme.AddRange(result);
                db.Corporacion_Ano.Add(corporacionAno);
                db.SaveChanges();

                db.SP_InformeCorporaciones(loadReport.IdGroupInforme, corporacionAno.IdAno);
            }
            return View();
        }
    }
}