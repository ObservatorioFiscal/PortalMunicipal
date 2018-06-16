﻿using System;
using System.Collections.Generic;
using GastoTransparenteMunicipal.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Newtonsoft.Json;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using System.IO;
using GastoTransparenteMunicipal.Helpers;
using System.Data.SqlClient;
using NPOI.SS.UserModel;
using System.Data.Entity;

namespace GastoTransparenteMunicipal.Controllers
{
    public class AdminComunaController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CargaDatos()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Destacado = "hidden";
            ViewBag.administracion = true;
            ViewBag.Anos = new SelectList(db.Anos_Invisible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            ViewBag.activos = new List<bool>{
                municipalidad.Act_Proveedor,municipalidad.Act_Subsidio,municipalidad.Act_Corporacion,municipalidad.Act_Personal
            };
            return View();
        }
        
        public JsonResult CargadosPost(int aux)
        {
            Gasto_Ano gasto = db.Gasto_Ano.Find(aux);
            List<bool> lista = new List<bool>
            {
                gasto.Cargado,
                db.Ingreso_Ano.Any(r=>r.Ano==gasto.Ano && r.Semestre==gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad && r.Cargado==true),
                db.Proveedor_Ano.Any(r=>r.Ano==gasto.Ano && r.Semestre==gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad && r.Cargado==true),
                db.Subsidio_Ano.Any(r=>r.Ano==gasto.Ano && r.Semestre==gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad && r.Cargado==true),
                db.Corporacion_Ano.Any(r=>r.Ano==gasto.Ano && r.Semestre==gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad && r.Cargado==true),
                db.Personal_Ano.Any(r=>r.Ano==gasto.Ano && r.Semestre==gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad && r.Cargado==true)
            };
            var auxiliar = lista;
            return Json(auxiliar, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AbrirPeriodo()
        {
            var municipalidad = GetCurrentIdMunicipality();
            var lista = db.Gasto_Ano.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad);
            List<decimal> final = new List<decimal>();
            int anoactual = DateTime.Now.Year;
            for (var item = 2010; item < anoactual; item++)
            {
                if (!lista.Where(r=>r.Semestre==0).Select(r => r.Ano).Contains(item))
                {
                    final.Add(item);
                }
            }
            if (!lista.Select(r => r.Ano).Contains(anoactual))
            {
                if (!lista.Where(r => r.Ano == anoactual).Select(r => r.Semestre).Contains(0))
                {
                    final.Add(anoactual);
                }
            }
            final.Reverse(); // año mas alto.
            decimal ultimoano = final.First();
            List<decimal?> lista2 = lista.Where(r => r.Ano == ultimoano).Select(r => r.Semestre).ToList();
            Dictionary<int, string> dic = new Dictionary<int, string>();
            if (final.First()== DateTime.Now.Year){
                int mes = DateTime.Now.Month;
                if (!lista2.Contains(1) && mes > 3){
                    dic.Add(1, "a Marzo");
                }
                if (!lista2.Contains(2) && mes > 6){
                    dic.Add(1, "a Junio");
                }
                if (!lista2.Contains(3) && mes > 9){
                    dic.Add(1, "a Septiembre");
                }
            }
            else{
                dic.Add(0, "Completo");
            }
            ViewBag.periodo = new SelectList(dic,"key","value");
            ViewBag.ano = new SelectList(final);
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Destacado = "hidden";
            ViewBag.idMuni = municipalidad.IdMunicipalidad;
            return View();
        }

        [HttpPost]
        public ActionResult AbrirPeriodo(int periodo, int ano)
        {
            var municipalidad = GetCurrentIdMunicipality();
            Municipalidad muni = db.Municipalidad.Find(municipalidad.IdMunicipalidad);
            ViewBag.idMuni = muni.IdMunicipalidad;
            Corporacion_Ano corp = new Corporacion_Ano
            {
                IdMunicipalidad = muni.IdMunicipalidad,Ano = ano,UpdatedOn = DateTime.Now,Activo = false,Semestre = periodo,Cargado = false
            };
            Personal_Ano pers = new Personal_Ano
            {
                IdMunicipalidad = muni.IdMunicipalidad,Ano = ano,UpdatedOn = DateTime.Now,Activo = false,Semestre = periodo,Cargado = false
            };
            Proveedor_Ano prov = new Proveedor_Ano
            {
                IdMunicipalidad = muni.IdMunicipalidad,Ano = ano,UpdatedOn = DateTime.Now,Activo = false,Semestre = periodo,Cargado = false
            };
            Subsidio_Ano subs = new Subsidio_Ano
            {
                IdMunicipalidad = muni.IdMunicipalidad,Ano = ano,UpdatedOn = DateTime.Now,Activo = false,Semestre = periodo,Cargado = false
            };
            Ingreso_Ano ingr = new Ingreso_Ano
            {
                IdMunicipalidad = muni.IdMunicipalidad,Ano = ano,UpdatedOn = DateTime.Now,Activo = false,Semestre = periodo,Cargado = false
            };
            Gasto_Ano gast = new Gasto_Ano
            {
                IdMunicipalidad = muni.IdMunicipalidad,Ano = ano,UpdatedOn = DateTime.Now,Activo = false,Semestre = periodo,Cargado = false
            };
            muni.Corporacion_Ano.Add(corp);
            muni.Personal_Ano.Add(pers);
            muni.Proveedor_Ano.Add(prov);
            muni.Subsidio_Ano.Add(subs);
            muni.Ingreso_Ano.Add(ingr);
            muni.Gasto_Ano.Add(gast);
            db.Entry(muni).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CargaDatos");
        }

        public JsonResult FiltroMeses(int ano, int idMuni)
        {
            var lista = db.Gasto_Ano.Where(r => r.Ano == ano && r.IdMunicipalidad == idMuni).Select(r => r.Semestre);
            
            List<decimal> final = new List<decimal>();
            int mes = DateTime.Now.Month;
            
            if (!lista.Contains(1) && mes>3)
            {
                final.Add(1);
            }
            if (!lista.Contains(2) && mes > 6)
            {
                final.Add(2);
            }
            if (!lista.Contains(3) && mes > 9)
            {
                final.Add(3);
            }
            return Json(final, JsonRequestBehavior.AllowGet);
        }

        #region Ingresos

        public ActionResult CargaIngresos(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Ingreso_Ano ingr = db.Ingreso_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
            ViewBag.aviso = ingr.Cargado;
            switch (ingr.Semestre)
            {
                case 1:
                    ViewBag.ano = ingr.Ano + "a marzo";
                    break;
                case 2:
                    ViewBag.ano = ingr.Ano + "a junio";
                    break;
                case 3:
                    ViewBag.ano = ingr.Ano + "a septiembre";
                    break;
                default:
                    ViewBag.ano = ingr.Ano;
                    break;
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CargaIngresos(HttpPostedFileBase fileAdm, HttpPostedFileBase fileSalud, HttpPostedFileBase fileEducacion, HttpPostedFileBase fileCementerio)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;

            Ingreso_Ano ingresoAno = new Ingreso_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };
            LoadReport loadReport = new LoadReport();

            if (fileAdm != null && fileSalud != null && fileEducacion != null)
            {
                db.Ingreso_Ano.Add(ingresoAno);

                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "ADM. Y SERVICIOS", 1);
                    db.IngresoInformev2.AddRange(result);
                }

                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "SALUD", 2);
                    db.IngresoInformev2.AddRange(result);
                }

                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "EDUCACION", 3);
                    db.IngresoInformev2.AddRange(result);
                }

                if (fileCementerio != null)
                {
                    using (Stream fileStream = fileCementerio.InputStream)
                    {
                        xssfwb = new XSSFWorkbook(fileStream);
                        var result = loadReport.LoadInformeIngresov2(xssfwb, "CEMENTERIO", 4);
                        db.IngresoInformev2.AddRange(result);
                    }
                }
            }

            var resultSave = await db.SaveChangesAsync();
            //object[] parameters =
            //{
            //    new SqlParameter("@idGroupReportIngreso", loadReport.IdGroupInforme),
            //    new SqlParameter("@idAn", ingresoAno.IdAno)
            //};

            //db.Database.ExecuteSqlCommandAsync("EXEC SP_InformeIngreso @idGroupReportIngreso @idAn", parameters);
            //db.SP_InformeIngreso(loadReport.IdGroupInforme, ingresoAno.IdAno);
            return View();
        }

        public ActionResult CargaDiccionarioIngresos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CargaDiccionarioIngresos(HttpPostedFileBase file)
        {
            bool isValid = true;
            try
            {
                LoadReport loadReport = new LoadReport();
                XSSFWorkbook excelGlosa;
                using (Stream fileStream = file.InputStream)
                {
                    excelGlosa = new XSSFWorkbook(fileStream);
                    var ingresoGlosas = loadReport.LoadIngresoGlosa(excelGlosa);
                    db.Ingreso_Glosa.AddRange(ingresoGlosas);
                    var result = await db.SaveChangesAsync();
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        #endregion

        #region Gastos

        public ActionResult CargaDiccionarioGastos()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CargaDiccionarioGastos(HttpPostedFileBase file)
        {
            bool isValid = true;
            try
            {
                LoadReport loadReport = new LoadReport();
                XSSFWorkbook excelGlosa;
                using (Stream fileStream = file.InputStream)
                {
                    excelGlosa = new XSSFWorkbook(fileStream);
                    var gastoGlosas = loadReport.LoadGastoGlosa(excelGlosa);
                    db.Gasto_Glosa.AddRange(gastoGlosas);
                    var result = await db.SaveChangesAsync();
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        public ActionResult CargaGastos(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            ViewBag.aviso = gasto.Cargado;
            switch (gasto.Semestre)
            {
                case 1:
                    ViewBag.ano = gasto.Ano + "a marzo";
                    break;
                case 2:
                    ViewBag.ano = gasto.Ano + "a junio";
                    break;
                case 3:
                    ViewBag.ano = gasto.Ano + "a septiembre";
                    break;
                default:
                    ViewBag.ano = gasto.Ano;
                    break;
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CargaGastos(HttpPostedFileBase fileAdm, HttpPostedFileBase fileSalud, HttpPostedFileBase fileEducacion, HttpPostedFileBase fileCementerio)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;

            Gasto_Ano gastoAno = new Gasto_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };
            LoadReport loadReport = new LoadReport();

            if (fileAdm != null && fileSalud != null && fileEducacion != null)
            {
                db.Gasto_Ano.Add(gastoAno);

                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "ADM. Y SERVICIOS", 1);
                    db.GastoInformev2.AddRange(result);
                }

                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "SALUD", 2);
                    db.GastoInformev2.AddRange(result);
                }

                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "EDUCACION", 3);
                    db.GastoInformev2.AddRange(result);
                }

                if (fileCementerio != null)
                {
                    using (Stream fileStream = fileCementerio.InputStream)
                    {
                        xssfwb = new XSSFWorkbook(fileStream);
                        var result = loadReport.LoadInformeGastov2(xssfwb, "CEMENTERIO", 4);
                        db.GastoInformev2.AddRange(result);
                    }
                }
            }
            //object[] parameters =
            //{
            //    new SqlParameter("@idGroupReportIngreso", loadReport.IdGroupInforme),
            //    new SqlParameter("@idAn", ingresoAno.IdAno)
            //};

            //db.Database.ExecuteSqlCommandAsync("EXEC SP_InformeIngreso @idGroupReportIngreso @idAn", parameters);
            //db.SP_InformeIngreso(loadReport.IdGroupInforme, ingresoAno.IdAno);
            var resultSave = await db.SaveChangesAsync();
            return View();
        }
        #endregion

        #region Proveedores
        public ActionResult CargaProveedores(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Proveedor_Ano ingr = db.Proveedor_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
            ViewBag.aviso = ingr.Cargado;
            switch (ingr.Semestre)
            {
                case 1:
                    ViewBag.ano = ingr.Ano + "a marzo";
                    break;
                case 2:
                    ViewBag.ano = ingr.Ano + "a junio";
                    break;
                case 3:
                    ViewBag.ano = ingr.Ano + "a septiembre";
                    break;
                default:
                    ViewBag.ano = ingr.Ano;
                    break;
            }
            return View();
        }

        [HttpPost]
        public JsonResult ValidadorCargaProveedoresAdm(HttpPostedFileBase admServicios)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = admServicios.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresAdmServicios(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaProveedoresSalud(HttpPostedFileBase salud)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();

                using (Stream fileStream = salud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresSalud(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaProveedoresEducacion(HttpPostedFileBase educacion)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = educacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresEducacion(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaProveedoresCementerio(HttpPostedFileBase cementerio)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = cementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresCementerio(xssfwb);
                }
                return Json(isValid);
            }

            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public ActionResult CargaProveedores(HttpPostedFileBase admServicios, HttpPostedFileBase salud, HttpPostedFileBase educacion, HttpPostedFileBase cementerio)
        {
            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;
            LoadReport loadReport = new LoadReport();
            Proveedor_Ano proveedorAno = new Proveedor_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };
            if (admServicios != null || salud != null || educacion != null || cementerio != null)
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

                    db.SP_ProveedorAdm(loadReport.IdGroupInforme, proveedorAno.IdAno);
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

                    db.SP_ProveedorSalud(loadReport.IdGroupInforme, proveedorAno.IdAno);
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

                    db.SP_ProveedorEducacion(loadReport.IdGroupInforme, proveedorAno.IdAno);
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
        #endregion

        #region Subsidios
        public ActionResult CargaSubsidios(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Subsidio_Ano ingr = db.Subsidio_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
            ViewBag.aviso = ingr.Cargado;
            switch (ingr.Semestre)
            {
                case 1:
                    ViewBag.ano = ingr.Ano + "a marzo";
                    break;
                case 2:
                    ViewBag.ano = ingr.Ano + "a junio";
                    break;
                case 3:
                    ViewBag.ano = ingr.Ano + "a septiembre";
                    break;
                default:
                    ViewBag.ano = ingr.Ano;
                    break;
            }
            return View();
        }

        [HttpPost]
        public JsonResult ValidadorCargaSubsidios(HttpPostedFileBase file)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                using (Stream fileStream = file.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    LoadReport loadReport = new LoadReport();
                    var result = loadReport.LoadInformeSubsidio(xssfwb);
                }
                return Json(isValid);
            }
            catch
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public ActionResult CargaSubsidios(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;
            Subsidio_Ano subsidioAno = new Subsidio_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };

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
        #endregion

        #region Corporaciones
        public ActionResult CargaCorporaciones(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Corporacion_Ano ingr = db.Corporacion_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
            ViewBag.aviso = ingr.Cargado;
            switch (ingr.Semestre)
            {
                case 1:
                    ViewBag.ano = ingr.Ano + "a marzo";
                    break;
                case 2:
                    ViewBag.ano = ingr.Ano + "a junio";
                    break;
                case 3:
                    ViewBag.ano = ingr.Ano + "a septiembre";
                    break;
                default:
                    ViewBag.ano = ingr.Ano;
                    break;
            }
            return View();
        }

        [HttpPost]
        public JsonResult ValidadorCargaCorporaciones(HttpPostedFileBase file)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                using (Stream fileStream = file.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    LoadReport loadReport = new LoadReport();
                    var result = loadReport.LoadInformeCorporaciones(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public ActionResult CargaCorporaciones(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;

            DateTime data = DateTime.Now;
            Corporacion_Ano corporacionAno = new Corporacion_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };
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
        #endregion

        #region Remuneraciones
        public ActionResult CargaRemuneraciones(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            ViewBag.aviso = false;
            ViewBag.ano = 2017;

            return View();
        }

        [HttpPost]
        public JsonResult ValidadorCargaRemuneracionesAdm(HttpPostedFileBase admServicios)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = admServicios.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalAdmServicios(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaRemuneracionesSalud(HttpPostedFileBase salud)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();

                using (Stream fileStream = salud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalSalud(xssfwb);
                }

                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaRemuneracionesEducacion(HttpPostedFileBase educacion)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = educacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalEducacion(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public ActionResult ValidadorCargaRemuneracionesCementerio(HttpPostedFileBase cementerio)
        {
            bool isValid = true;
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();

                using (Stream fileStream = cementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalCementerio(xssfwb);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public ActionResult CargaRemuneraciones(HttpPostedFileBase admServicios, HttpPostedFileBase salud, HttpPostedFileBase educacion, HttpPostedFileBase cementerio)
        {
            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;

            DateTime data = DateTime.Now;
            LoadReport loadReport = new LoadReport();
            Personal_Ano personalAno = new Personal_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };

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

            db.SP_InformePersonalMunicipioTotal(loadReport.IdGroupInforme, personalAno.IdAno);

            return View();
        }
        #endregion

    }

}
