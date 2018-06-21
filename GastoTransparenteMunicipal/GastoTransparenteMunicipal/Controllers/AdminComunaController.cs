using System;
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
using System.Data;

namespace GastoTransparenteMunicipal.Controllers
{
    //[AuthorizeComuna]
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

        [HttpPost]
        public ActionResult CargaDatos(int id)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.SaveChanges();

            Gasto_Ano gasto = db.Gasto_Ano.Find(id);

            var gastos = db.Gasto_Ano.Where(            r => r.Ano == gasto.Ano && r.Semestre != gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).ToList();
            var ingresos = db.Ingreso_Ano.Where(        r => r.Ano == gasto.Ano && r.Semestre != gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).ToList();
            var proveedors = db.Proveedor_Ano.Where(    r => r.Ano == gasto.Ano && r.Semestre != gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).ToList();
            var subsidios = db.Subsidio_Ano.Where(      r => r.Ano == gasto.Ano && r.Semestre != gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).ToList();
            var corporacions = db.Corporacion_Ano.Where(r => r.Ano == gasto.Ano && r.Semestre != gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).ToList();
            var personals = db.Personal_Ano.Where(      r => r.Ano == gasto.Ano && r.Semestre != gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).ToList();
            if (gastos.Count > 0)
            {
                var gastoAux = gastos.First();
                gastoAux.Activo = true;
                for (int i = 1; i < gastos.Count; i++)
                {
                    gastos[i].Activo = false;
                    db.SP_DeleteGasto(gastos[i].IdAno);
                }
            }
            if (ingresos.Count > 0)
            {
                var ingreso = ingresos.First();
                ingreso.Activo = true;
                for (int i = 1; i < ingresos.Count; i++)
                {
                    ingresos[i].Activo = false;
                    db.SP_DeleteIngreso(ingresos[i].IdAno);
                }
            }
            if (proveedors.Count > 0)
            {
                var proveedor = proveedors.First();
                proveedor.Activo = true;
                for (int i = 1; i < proveedors.Count; i++)
                {
                    proveedors[i].Activo = false;
                    db.SP_DeleteProveedor(proveedors[i].IdAno);
                }
            }
            if (subsidios.Count > 0)
            {
                var subsidio = subsidios.First();
                subsidio.Activo = true;
                for (int i = 1; i < subsidios.Count; i++)
                {
                    subsidios[i].Activo = false;
                    db.SP_DeleteSubsidio(subsidios[i].IdAno);
                }
            }
            if (corporacions.Count > 0)
            {
                var corporacion = corporacions.First();
                corporacion.Activo = true;
                for (int i = 1; i < corporacions.Count; i++)
                {
                    corporacions[i].Activo = false;
                    db.SP_DeleteCorporacion(corporacions[i].IdAno);
                }
            }
            if (personals.Count > 0)
            {
                var personal = personals.First();
                personal.Activo = true;
                for (int i = 1; i < personals.Count; i++)
                {
                    personals[i].Activo = false;
                    db.SP_DeletePersonal(personals[i].IdAno);
                }
            }

            db.SaveChanges();

            if(gasto.Ano==DateTime.Now.Year || gasto.Semestre != 0) { 
                var suma = db.SP_SumaGastoByIdAno(id).First();
                Municipalidad municipalidad = db.Municipalidad.Find(gasto.IdMunicipalidad);
                switch (gasto.Semestre)
                {
                    case 0:
                        municipalidad.Periodo = "El" + gasto.Ano +" "; 
                        break;
                    case 1:
                        municipalidad.Periodo = "A Marzo de " + gasto.Ano + " ";
                        break;
                    case 2:
                        municipalidad.Periodo = "A Junio de " + gasto.Ano + " ";
                        break;
                    case 3:
                        municipalidad.Periodo = "A Septiembre de " + gasto.Ano + " ";
                        break;
                }
                municipalidad.TotalGastado = "$"+ Ppuntos(suma.TotalGastado.Value);
                municipalidad.TotalPresupuestado = "$" + Ppuntos(suma.TotalPresupuestado.Value);
                db.SaveChanges();
            }
            return View();
        }

        string Ppuntos(long aux2 )
        {
            string aux = Convert.ToString(aux2);
            aux.Reverse();
            string puntos = "";
            for (var i=0; i < aux.Length; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    puntos = puntos + i +".";
                }
                else
                {
                    puntos = puntos + i;
                }
            }
            if (puntos[puntos.Length - 1] == '.')
            {
                puntos= puntos.Remove(aux.Length - 1);
            }
            puntos.Reverse();
            return puntos;
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

        public ActionResult Eliminar()
        {
            var municipalidad = GetCurrentIdMunicipality();
            var invisibles = db.Anos_Invisible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad).ToList();
            var visibles = db.Gasto_Ano_Visible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad).ToList();
            foreach(var item in visibles.ToList())
            {
                Anos_Invisible uno = new Anos_Invisible
                {
                    IdAno = item.IdAno,
                    IdMunicipalidad = item.IdMunicipalidad,
                    Nombre = item.Nombre
                };
                invisibles.Add(uno);
            }
            ViewBag.Anos = new SelectList(invisibles.OrderBy(r=>r.Nombre), "IdAno", "Nombre");
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Destacado = "hidden";
            ViewBag.administracion = true;
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(int ano)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.SaveChanges();

            var gasto = db.Gasto_Ano.Find(ano);
            var gastos = db.Gasto_Ano.Where(r => r.Ano == gasto.Ano && r.IdMunicipalidad == gasto.IdMunicipalidad).FirstOrDefault();
            var ingresos = db.Ingreso_Ano.Where(r => r.Ano == gasto.Ano && r.IdMunicipalidad == gasto.IdMunicipalidad).FirstOrDefault();
            var proveedors = db.Proveedor_Ano.Where(r => r.Ano == gasto.Ano && r.IdMunicipalidad == gasto.IdMunicipalidad).FirstOrDefault();
            var subsidios = db.Subsidio_Ano.Where(r => r.Ano == gasto.Ano && r.IdMunicipalidad == gasto.IdMunicipalidad).FirstOrDefault();
            var corporacions = db.Corporacion_Ano.Where(r => r.Ano == gasto.Ano && r.IdMunicipalidad == gasto.IdMunicipalidad).FirstOrDefault();
            var personals = db.Personal_Ano.Where(r => r.Ano == gasto.Ano && r.IdMunicipalidad == gasto.IdMunicipalidad).FirstOrDefault();

            db.SP_DeleteSubsidio(subsidios == null ? 0 : subsidios.IdAno);
            db.SP_DeleteGasto(gastos == null ? 0 : gastos.IdAno);
            db.SP_DeleteIngreso(ingresos == null ? 0 : ingresos.IdAno);
            db.SP_DeleteProveedor(proveedors == null ? 0 : proveedors.IdAno);            
            db.SP_DeleteCorporacion(corporacions == null ? 0 : corporacions.IdAno);
            db.SP_DeletePersonal(personals == null ? 0 : personals.IdAno);


            var municipalidad = GetCurrentIdMunicipality();
            var invisibles = db.Anos_Invisible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad).ToList();
            var visibles = db.Gasto_Ano_Visible.Where(r => r.IdMunicipalidad == municipalidad.IdMunicipalidad).ToList();
            foreach (var item in visibles.ToList())
            {
                Anos_Invisible uno = new Anos_Invisible
                {
                    IdAno = item.IdAno,
                    IdMunicipalidad = item.IdMunicipalidad,
                    Nombre = item.Nombre
                };
                invisibles.Add(uno);
            }
            ViewBag.Anos = new SelectList(invisibles.OrderBy(r => r.Nombre), "IdAno", "Nombre");
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.Destacado = "hidden";
            ViewBag.administracion = true;
            return View();
        }


        #region Ingresos

        public ActionResult CargaIngresos(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Ingreso_Ano ingr = db.Ingreso_Ano.Single(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);

            ViewBag.aviso = ingr.Cargado;
            ViewBag.id = ingr.IdAno;

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
        public ActionResult CargaIngresos(int id,HttpPostedFileBase fileAdm, HttpPostedFileBase fileSalud, HttpPostedFileBase fileEducacion, HttpPostedFileBase fileCementerio)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.Configuration.AutoDetectChangesEnabled = false;
            db.SaveChanges();

            if (fileAdm == null || fileSalud == null || fileEducacion == null)
            {
                return View();
            }

            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            var gasto = db.Gasto_Ano.Find(id);
            var ingresoAno = db.Ingreso_Ano.Where(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).First();                        
            ingresoAno.Cargado = true;
            ingresoAno.UpdatedOn = DateTime.UtcNow;

            LoadReport loadReport = new LoadReport();

            if (fileAdm != null && fileSalud != null && fileEducacion != null)
            {             
                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "ADM. Y SERVICIOS", 1);
                    //db.IngresoInformev2.AddRange(result);
                    SaveBulk(result, "IngresoInformev2");
                }

                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "SALUD", 2);
                    //db.IngresoInformev2.AddRange(result);
                    SaveBulk(result, "IngresoInformev2");
                }

                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "EDUCACION", 3);
                    //db.IngresoInformev2.AddRange(result);
                    SaveBulk(result, "IngresoInformev2");
                }

                if (fileCementerio != null)
                {
                    using (Stream fileStream = fileCementerio.InputStream)
                    {
                        xssfwb = new XSSFWorkbook(fileStream);
                        var result = loadReport.LoadInformeIngresov2(xssfwb, "CEMENTERIO", 4);
                        //db.IngresoInformev2.AddRange(result);
                        SaveBulk(result, "IngresoInformev2");
                    }
                }
            }

            db.SaveChanges();
            db.SP_InformeIngreso(loadReport.IdGroupInforme, ingresoAno.IdAno);

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();

            return RedirectToAction("CargaDatos");
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
                    //SaveBulk(ingresoGlosas, "Ingreso_Glosa");
                    var result = await db.SaveChangesAsync();
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaIngresosAdm()
        {            
            bool isValid = true;
            HttpPostedFileBase fileAdm = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "ADM. Y SERVICIOS", 1);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaIngresosSalud()
        {
            bool isValid = true;
            HttpPostedFileBase fileSalud = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "SALUD", 2);                    
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaIngresosEducacion()
        {
            bool isValid = true;
            HttpPostedFileBase fileEducacion = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "EDUCACION", 3);                    
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorCargaIngresosCementerio()
        {
            bool isValid = true;
            HttpPostedFileBase fileCementerio = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileCementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeIngresov2(xssfwb, "CEMENTERIO", 4);                    
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
                    //SaveBulk(gastoGlosas, "Gasto_Glosa");
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
            ViewBag.id = gasto  .IdAno;
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
        public ActionResult CargaGastos(int id,HttpPostedFileBase fileAdm, HttpPostedFileBase fileSalud, HttpPostedFileBase fileEducacion, HttpPostedFileBase fileCementerio)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.Configuration.AutoDetectChangesEnabled = false;
            db.SaveChanges();

            if (fileAdm == null || fileSalud == null || fileEducacion == null)
            {
                return View();
            }

            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;            
            Gasto_Ano gastoAno = db.Gasto_Ano.Find(id);
            gastoAno.Cargado = true;
            gastoAno.UpdatedOn = DateTime.UtcNow;

            LoadReport loadReport = new LoadReport();

            if (fileAdm != null && fileSalud != null && fileEducacion != null)
            {
                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "ADM. Y SERVICIOS", 1);
                    //db.GastoInformev2.AddRange(result);
                    SaveBulk(result, "GastoInformev2");
                }

                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "SALUD", 2);
                    //db.GastoInformev2.AddRange(result);
                    SaveBulk(result, "GastoInformev2");
                }

                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "EDUCACION", 3);
                    //db.GastoInformev2.AddRange(result);
                    SaveBulk(result, "GastoInformev2");
                }

                if (fileCementerio != null)
                {
                    using (Stream fileStream = fileCementerio.InputStream)
                    {
                        xssfwb = new XSSFWorkbook(fileStream);
                        var result = loadReport.LoadInformeGastov2(xssfwb, "CEMENTERIO", 4);
                        //db.GastoInformev2.AddRange(result);
                        SaveBulk(result, "GastoInformev2");
                    }
                }
            }

            db.SaveChanges();
            db.SP_InformeGasto(loadReport.IdGroupInforme, gastoAno.IdAno);

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
            return RedirectToAction("CargaDatos");
        }
       
        [HttpPost]
        public JsonResult ValidadorGastoIngresosAdm()
        {
            bool isValid = true;
            HttpPostedFileBase fileAdm = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "ADM. Y SERVICIOS", 1);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public JsonResult ValidadorGastoIngresosSalud()
        {
            bool isValid = true;
            HttpPostedFileBase fileSalud = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "SALUD", 2);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }
                                   
        [HttpPost]                 
        public JsonResult ValidadorGastoIngresosEducacion()
        {
            bool isValid = true;
            HttpPostedFileBase fileEducacion = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "EDUCACION", 3);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
        }
                                   
        [HttpPost]                 
        public JsonResult ValidadorGastoIngresosCementerio()
        {
            bool isValid = true;
            HttpPostedFileBase fileCementerio = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileCementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeGastov2(xssfwb, "CEMENTERIO", 4);
                }
                return Json(isValid);
            }
            catch (Exception ex)
            {
                return Json(!isValid);
            }
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
            ViewBag.id = ingr.IdAno;

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
        public ActionResult CargaProveedores(int id,HttpPostedFileBase fileAdm, HttpPostedFileBase fileSalud, HttpPostedFileBase fileEducacion, HttpPostedFileBase fileCementerio)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.Configuration.AutoDetectChangesEnabled = false;
            db.SaveChanges();

            if (fileAdm == null || fileSalud == null || fileEducacion == null)
            {
                return View();
            }

            var gasto = db.Gasto_Ano.Find(id);
            var proveedorAno = db.Proveedor_Ano.Where(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).First();
            proveedorAno.Cargado = true;
            proveedorAno.UpdatedOn = DateTime.UtcNow;

            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;    
            LoadReport loadReport = new LoadReport();                                           

            if (fileAdm != null)
            {
                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);

                    var result = loadReport.LoadInformeProveedoresAdmServicios(xssfwb);
                    //db.Proveedor_AdmInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Proveedor_AdmInforme");
                    db.SP_ProveedorAdm(loadReport.IdGroupInforme, proveedorAno.IdAno);
                }
            }

            if (fileSalud != null)
            {
                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresSalud(xssfwb);
                    //db.Proveedor_SaludInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Proveedor_SaludInforme");
                    db.SP_ProveedorSalud(loadReport.IdGroupInforme, proveedorAno.IdAno);
                }
            }

            if (fileEducacion != null)
            {
                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresEducacion(xssfwb);
                    //db.Proveedor_EducacionInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Proveedor_EducacionInforme");
                    db.SP_ProveedorEducacion(loadReport.IdGroupInforme, proveedorAno.IdAno);
                }
            }

            if (fileCementerio != null)
            {
                using (Stream fileStream = fileCementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformeProveedoresCementerio(xssfwb);
                    //db.Proveedor_CementerioInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Proveedor_CementerioInforme");
                    db.SP_ProveedorCementerio(loadReport.IdGroupInforme, proveedorAno.IdAno);
                }

            }

            db.SaveChanges();
            db.SP_ProveedorTotal(loadReport.IdGroupInforme, proveedorAno.IdAno);

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();

            return RedirectToAction("CargaDatos");
        }

        [HttpPost]
        public JsonResult ValidadorCargaProveedoresAdm()
        {
            bool isValid = true;
            HttpPostedFileBase fileAdm = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileAdm.InputStream)
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
        public JsonResult ValidadorCargaProveedoresSalud()
        {
            bool isValid = true;
            HttpPostedFileBase fileSalud = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();

                using (Stream fileStream = fileSalud.InputStream)
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
        public JsonResult ValidadorCargaProveedoresEducacion()
        {
            bool isValid = true;
            HttpPostedFileBase fileEducacion = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileEducacion.InputStream)
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
        public JsonResult ValidadorCargaProveedoresCementerio()
        {
            bool isValid = true;
            HttpPostedFileBase fileCementerio = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileCementerio.InputStream)
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
            ViewBag.id = ingr.IdAno;

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
        public JsonResult ValidadorCargaSubsidios()
        {
            bool isValid = true;
            HttpPostedFileBase file = Request.Files[0];
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
            catch(Exception ex)
            {
                return Json(!isValid);
            }
        }

        [HttpPost]
        public ActionResult CargaSubsidios(int id,HttpPostedFileBase file)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.Configuration.AutoDetectChangesEnabled = false;
            db.SaveChanges();

            if (file == null)
            {
                return View();
            }

            var gasto = db.Gasto_Ano.Find(id);
            var subsidioAno = db.Subsidio_Ano.Where(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).First();
            subsidioAno.Cargado = true;
            subsidioAno.UpdatedOn = DateTime.UtcNow;

            XSSFWorkbook xssfwb;
            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;            
            
            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeSubsidio(xssfwb);
                //db.SubsidioInforme.AddRange(result);                
                //db.SaveChanges();
                SaveBulk(result, "SubsidioInforme");
                db.SP_InformeSubsidio(loadReport.IdGroupInforme, subsidioAno.IdAno);
            }

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();

            return RedirectToAction("CargaDatos");
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
            ViewBag.id = ingr.IdAno;

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
        public JsonResult ValidadorCargaCorporaciones()
        {
            bool isValid = true;
            HttpPostedFileBase file = Request.Files[0];
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
        public ActionResult CargaCorporaciones(int id,HttpPostedFileBase file)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.Configuration.AutoDetectChangesEnabled = false;
            db.SaveChanges();

            if (file == null)
            {
                return View();
            }

            var gasto = db.Gasto_Ano.Find(id);
            var corporacionAno = db.Corporacion_Ano.Where(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).First();
            corporacionAno.Cargado = true;
            corporacionAno.UpdatedOn = DateTime.UtcNow;

            XSSFWorkbook xssfwb;

            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;         

            using (Stream fileStream = file.InputStream)
            {
                xssfwb = new XSSFWorkbook(fileStream);
                LoadReport loadReport = new LoadReport();
                var result = loadReport.LoadInformeCorporaciones(xssfwb);
                //db.CorporacionInforme.AddRange(result);
                //db.SaveChanges();
                SaveBulk(result, "CorporacionInforme");
                db.SP_InformeCorporaciones(loadReport.IdGroupInforme, corporacionAno.IdAno);
            }

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();

            return RedirectToAction("CargaDatos");
        }
        #endregion

        #region Remuneraciones
        public ActionResult CargaRemuneraciones(int id)
        {
            var municipalidad = GetCurrentIdMunicipality();
            ViewBag.administracion = true;
            ViewBag.logo = municipalidad.DireccionWeb + ".png";
            ViewBag.cementerio = municipalidad.Cementerio;
                                    
            Gasto_Ano gasto = db.Gasto_Ano.Find(id);
            Personal_Ano ingr = db.Personal_Ano.First(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad);
            ViewBag.aviso = ingr.Cargado;
            ViewBag.id = ingr.IdAno;

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
        public JsonResult ValidadorCargaRemuneracionesAdm()
        {
            bool isValid = true;
            HttpPostedFileBase fileAdm = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileAdm.InputStream)
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
        public JsonResult ValidadorCargaRemuneracionesSalud()
        {
            bool isValid = true;
            HttpPostedFileBase fileSalud = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();

                using (Stream fileStream = fileSalud.InputStream)
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
        public JsonResult ValidadorCargaRemuneracionesEducacion()
        {
            bool isValid = true;
            HttpPostedFileBase fileEducacion = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();
                using (Stream fileStream = fileEducacion.InputStream)
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
        public ActionResult ValidadorCargaRemuneracionesCementerio()
        {
            bool isValid = true;
            HttpPostedFileBase fileCementerio = Request.Files[0];
            try
            {
                XSSFWorkbook xssfwb;
                LoadReport loadReport = new LoadReport();

                using (Stream fileStream = fileCementerio.InputStream)
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
        public ActionResult CargaRemuneraciones(int id, HttpPostedFileBase fileAdm, HttpPostedFileBase fileSalud, HttpPostedFileBase fileEducacion, HttpPostedFileBase fileCementerio)
        {
            var timeout = db.Database.CommandTimeout;
            db.Database.CommandTimeout = 2400;
            db.Configuration.AutoDetectChangesEnabled = false;
            db.SaveChanges();

            if (fileAdm == null || fileSalud == null || fileEducacion == null)
            {
                return View();
            }

            int idMunicipality = GetCurrentIdMunicipality().IdMunicipalidad;
            var gasto = db.Gasto_Ano.Find(id);
            var personalAno = db.Personal_Ano.Where(r => r.Ano == gasto.Ano && r.Semestre == gasto.Semestre && r.IdMunicipalidad == gasto.IdMunicipalidad).First();
            personalAno.Cargado = true;
            personalAno.UpdatedOn = DateTime.UtcNow;

            XSSFWorkbook xssfwb;

            LoadReport loadReport = new LoadReport();
            if (fileAdm != null)
            {
                using (Stream fileStream = fileAdm.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);

                    var result = loadReport.LoadInformePersonalAdmServicios(xssfwb);
                    //db.Personal_AdmInforme.AddRange(result);
                    //db.SaveChanges();                    
                    SaveBulk(result, "Personal_AdmInforme");
                    db.SP_InformePersonalAdm(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            if (fileSalud != null)
            {
                using (Stream fileStream = fileSalud.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalSalud(xssfwb);
                    //db.Personal_SaludInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Personal_SaludInforme");
                    db.SP_InformePersonalSalud(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            if (fileEducacion != null)
            {
                using (Stream fileStream = fileEducacion.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalEducacion(xssfwb);
                    //db.Personal_EducacionInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Personal_EducacionInforme");
                    db.SP_InformePersonalEducacion(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            if (fileCementerio != null)
            {
                using (Stream fileStream = fileCementerio.InputStream)
                {
                    xssfwb = new XSSFWorkbook(fileStream);
                    var result = loadReport.LoadInformePersonalCementerio(xssfwb);
                    //db.Personal_CementerioInforme.AddRange(result);
                    //db.SaveChanges();
                    SaveBulk(result, "Personal_CementerioInforme");
                    db.SP_InformePersonalCementerio(loadReport.IdGroupInforme, personalAno.IdAno);
                }
            }

            db.SP_InformePersonalMunicipioTotal(loadReport.IdGroupInforme, personalAno.IdAno);

            db.ChangeTracker.DetectChanges();
            db.SaveChanges();

            return RedirectToAction("CargaDatos");
        }
       
        #endregion

    }

}
