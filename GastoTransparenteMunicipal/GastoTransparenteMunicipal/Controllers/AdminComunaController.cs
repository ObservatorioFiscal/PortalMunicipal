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
            ViewBag.logo = municipalidad.Nombre;
            ViewBag.Anos = new SelectList(db.Anos_Invisible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
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

        public ActionResult CargaIngresos(int id)
        {         
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Ingreso_Ano ingr = db.Ingreso_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
            ViewBag.aviso = ingr.Cargado;
            switch(ingr.Semestre)
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
        public ActionResult CargaIngresos(HttpPostedFileBase file)
        {
            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            int year = 2017;
            int month = 0;

            Ingreso_Ano ingresoAno = new Ingreso_Ano { IdMunicipalidad = idMunicipality, Ano = year, Semestre = month, UpdatedOn = DateTime.Now };
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeIngreso(xssfwb);
                db.IngresoInforme.AddRange(result);
                db.Ingreso_Ano.Add(ingresoAno);

                db.SaveChanges();

                object[] parameters =
                {
                    new SqlParameter("@idGroupReportIngreso", loadReport.IdGroupInforme),
                    new SqlParameter("@idAn", ingresoAno.IdAno)          
                };

                db.Database.ExecuteSqlCommandAsync("EXEC SP_InformeIngreso @idGroupReportIngreso @idAn", parameters);
                db.SP_InformeIngreso(loadReport.IdGroupInforme, ingresoAno.IdAno);                
            }
            return View();
        }

        public ActionResult CargaGastos(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
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
        public ActionResult CargaProveedores(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
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
        public ActionResult CargaSubsidios(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
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
        public ActionResult CargaCorporaciones(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
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
        public ActionResult CargaRemuneraciones(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Personal_Ano ingr = db.Personal_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
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

        public ActionResult AbrirNuevoAno()
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
            ViewBag.Anos = new SelectList(db.Anos_Invisible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            return View();
        }

        public ActionResult AbrirNuevoAno(FormCollection data)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.logo = municipalidad.Nombre;
            ViewBag.Anos = new SelectList(db.Anos_Invisible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad), "IdAno", "Nombre");
            return View();
        }
    }

}
