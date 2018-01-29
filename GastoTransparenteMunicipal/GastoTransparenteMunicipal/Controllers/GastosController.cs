using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GastoTransparenteMunicipal.Models;

namespace GastoTransparenteMunicipal.Controllers
{
    public class GastosController : BaseController
    {
        // GET: Gastos
        public ActionResult Index()
        {
            ViewBag.Gasto = "active";
            ViewBag.Destacado = "hidden";
            return View();
        }

        public string JsonGastoNivelX(string tipo, int? idNivel ,int? profundidad,int? year)
        {
            if (tipo == null)
            {
                tipo = "AREA";
            }

            if (idNivel == null && profundidad == null && year == null)
            {                
                var idMunicipality = GetCurrentIdMunicipality();
                GastoModel gastos = new Models.GastoModel();
                gastos.Init(db, idMunicipality, tipo);
                return gastos.JsonNivel1;
            }

            if (profundidad == null && year != null)
            {
                var idMunicipality = GetCurrentIdMunicipality();
                GastoModel gastos = new Models.GastoModel();
                gastos.LoadNivel1(db, idMunicipality, tipo, year.Value);
                return gastos.JsonNivel1;
            }

            if (profundidad == 2)
            {
                var idMunicipality = GetCurrentIdMunicipality();
                GastoModel gastos = new Models.GastoModel();
                gastos.LoadNivel2(db, idMunicipality, tipo, year.Value, idNivel.Value);
                return gastos.JsonNivel2;
            }

            if (profundidad == 3)
            {
                var idMunicipality = GetCurrentIdMunicipality();
                GastoModel gastos = new Models.GastoModel();
                gastos.LoadNivel3(db, idMunicipality, tipo, year.Value, idNivel.Value);
                return gastos.JsonNivel3;

            }

            if (profundidad == 4)
            {
                var idMunicipality = GetCurrentIdMunicipality();
                GastoModel gastos = new Models.GastoModel();
                gastos.LoadNivel3(db, idMunicipality, tipo, year.Value, idNivel.Value);
                return gastos.JsonNivel4;

            }

            return "";
        }


        #region
        //public ActionResult GetDatosQuienInvierte29999nivel1(string id)
        //{
        //    #region FINAL
        //    d3Object_TreeMap d3 = new d3Object_TreeMap();
        //    string[] array;
        //    bool FUNCIONALECONOMICO f = false;
        //    string NIVEL = "";
        //    int PADRE = 0;
        //    #region parseo Datos
        //    try
        //    {
        //        array = id.Split(';');
        //        FUNCIONALECONOMICO = (array[0] == "0") ? false : true;
        //        NIVEL = array[1];
        //        PADRE = Convert.ToInt32(array[2]);
        //    }
        //    catch { }
        //    #endregion
        //    switch (NIVEL)
        //    {
        //        case "1":
        //            List<nivel1> lista1 = _context.nivel1.Where(r => r.Tipo == FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();

        //            d3.Load(lista1, "0");
        //            break;
        //        case "2":
        //            List<nivel2> lista2 = _context.nivel2.Where(r => r.Fk_IdNivel1 == PADRE && r.Tipo == FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();
        //            if (lista2.Count < 1)
        //            {
        //                lista2 = _context.nivel2.Where(r => r.Fk_IdNivel1 == PADRE && r.Tipo != FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();
        //                if (lista2.Count < 1)
        //                {
        //                    d3.Load(lista2, "2");// 2= NO hay mas detalle
        //                }
        //                else
        //                {
        //                    d3.Load(lista2, "1");// 1= Hay pero en otra categoria
        //                }

        //            }
        //            else
        //            {
        //                if (!_context.nivel2.Any(r => r.Fk_IdNivel1 == PADRE && r.Tipo != FUNCIONALECONOMICO))
        //                {
        //                    d3.Load(lista2, "3"); // 1= Solo hay en la que eligio
        //                }
        //                else
        //                {
        //                    d3.Load(lista2, "0");// 0= Hay normal
        //                }
        //            }
        //            break;
        //        case "3":
        //            List<nivel3> lista3 = _context.nivel3.Where(r => r.Fk_IdNivel2 == PADRE && r.Tipo == FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();
        //            if (lista3.Count < 1)
        //            {
        //                lista3 = _context.nivel3.Where(r => r.Fk_IdNivel2 == PADRE && r.Tipo != FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();
        //                if (lista3.Count < 1)
        //                {
        //                    d3.Load(lista3, "2");// 2= NO hay mas detalle
        //                }
        //                else
        //                {
        //                    d3.Load(lista3, "1");
        //                }
        //            }
        //            else
        //            {
        //                if (!_context.nivel3.Any(r => r.Fk_IdNivel2 == PADRE && r.Tipo != FUNCIONALECONOMICO))
        //                {
        //                    d3.Load(lista3, "3");
        //                }
        //                else
        //                {
        //                    d3.Load(lista3, "0");
        //                }
        //            }
        //            break;
        //        case "4":
        //            List<nivel4> lista4 = _context.nivel4.Where(r => r.Fk_IdNivel3 == PADRE && r.Tipo == FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();
        //            if (lista4.Count < 1)
        //            {
        //                lista4 = _context.nivel4.Where(r => r.Fk_IdNivel3 == PADRE && r.Tipo != FUNCIONALECONOMICO).OrderByDescending(r => r.Valor).ToList();
        //                if (lista4.Count < 1)
        //                {
        //                    d3.Load(lista4, "2");// 2= NO hay mas detalle
        //                }
        //                else
        //                {
        //                    d3.Load(lista4, "1");
        //                }
        //            }
        //            else
        //            {
        //                if (!_context.nivel4.Any(r => r.Fk_IdNivel3 == PADRE && r.Tipo != FUNCIONALECONOMICO))
        //                {
        //                    d3.Load(lista4, "3");
        //                }
        //                else
        //                {
        //                    d3.Load(lista4, "0");
        //                }
        //            }
        //            break;
        //    }
        //    string json = d3.getJson();
        //    return this.Content(json, "application/json");
        //    #endregion
        //}
        #endregion
    }
}
