using Core;
using GastoTransparenteMunicipal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class FeaturedDataController : BaseController
    {
        [HttpPost]
        public ActionResult Subsidy(int year)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Load(db, idMunicipality,year);
            return View(subsidioModel);
        }

        [HttpPost]
        public string SubsidyAjaxNivel1()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Init(db, idMunicipality);
            return subsidioModel.JsonSubsidio;
        }


        public string SubsidyChartNivel2(int IdAno)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            SubsidioModel subsidioModel = new SubsidioModel();
            //subsidioModel.Load_Nivel2(db, IdAno);
            //var json = JsonConvert.SerializeObject(subsidioModel.Subsidio_Nivel2);
            return "";//json;
        }
        public string SubsidyChartNivel3(int IdNivel2)
        {
            SubsidioModel subsidioModel = new SubsidioModel();
            subsidioModel.Load_Nivel3(db, IdNivel2);
            var json = JsonConvert.SerializeObject(subsidioModel.Subsidio_Nivel3);
            return json;
        }

        [HttpGet]
        public ActionResult Providers()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var takeElements = 20;

            ProveedorModel proveedorModel = new ProveedorModel();
            proveedorModel.Init(db, takeElements, idMunicipality);
            
            return View(proveedorModel);
        }

        [HttpPost]
        public ActionResult Providers(int year,int origenData)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            var takeElements = 20;
            ProveedorModel proveedorModel = new ProveedorModel();
            proveedorModel.WordCloud(db, takeElements, idMunicipality, year,origenData);

            return View(proveedorModel);
        }

        [HttpGet]
        public ActionResult Corporation()
        {   
            return View();
        }


        public string CorporationAjax()
        {
            var idMunicipality = GetCurrentIdMunicipality();
            CorporacionModel corporacion = new CorporacionModel();
            corporacion.Init(db, idMunicipality);
            return corporacion.JsonCorporacion_Nivel1;
        }

        [HttpPost]
        public ActionResult Corporation(int year)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            CorporacionModel corporacion = new CorporacionModel();
            corporacion.Load(db, idMunicipality, year);
            return View(corporacion);
        }

        //****************PERSONAL****************//
        //****************************************//

        public ActionResult PersonalSalary(int year, int origenData)
        {
            var idMunicipality = GetCurrentIdMunicipality();
            
            Personal_Ano personal_Ano = db.Personal_Ano.FirstOrDefault(r => r.IdMunicipalidad == idMunicipality && r.Ano == year);

            switch (origenData)
            {
                case OrigenData.Adm:
                    return this.Json(personal_Ano.Personal_Adm_Nivel1.Select(r =>
                                    new
                                    {
                                        Item = r.CodTipo,
                                        Lista = r.Personal_Adm_Nivel2.Select(l =>
                                        new
                                        {
                                            Nombre = l.Nombre,
                                            CMujer = l.CantidadMujer,
                                            CHombre = l.CantidadHombre,
                                            MMujer = l.MontoMujer,
                                            MHombre = l.MontoHombre
                                        })
                                    }), JsonRequestBehavior.AllowGet);
                case OrigenData.Salud:
                    return this.Json(personal_Ano.Personal_Salud_Nivel1.Select(r =>
                                    new
                                    {
                                        Item = r.CodTipo,
                                        Lista = r.Personal_Salud_Nivel2.Select(l =>
                                        new
                                        {
                                            Nombre = l.Nombre,
                                            CMujer = l.CantidadMujer,
                                            CHombre = l.CantidadHombre,
                                            MMujer = l.MontoMujer,
                                            MHombre = l.MontoHombre
                                        })
                                    }), JsonRequestBehavior.AllowGet);
                case OrigenData.Educacion:
                    return this.Json(personal_Ano.Personal_Educacion_Nivel1.Select(r =>
                                    new
                                    {
                                        Item = r.CodTipo,
                                        Lista = r.Personal_Educacion_Nivel2.Select(l =>
                                        new
                                        {
                                            Nombre = l.Nombre,
                                            CMujer = l.CantidadMujer,
                                            CHombre = l.CantidadHombre,
                                            MMujer = l.MontoMujer,
                                            MHombre = l.MontoHombre
                                        })
                                    }), JsonRequestBehavior.AllowGet);
                case OrigenData.Cementerio:
                    return this.Json(personal_Ano.Personal_Cementerio_Nivel1.Select(r =>
                                    new
                                    {
                                        Item = r.CodTipo,
                                        Lista = r.Personal_Cementerio_Nivel2.Select(l =>
                                        new
                                        {
                                            Nombre = l.Nombre,
                                            CMujer = l.CantidadMujer,
                                            CHombre = l.CantidadHombre,
                                            MMujer = l.MontoMujer,
                                            MHombre = l.MontoHombre
                                        })
                                    }), JsonRequestBehavior.AllowGet);
                case OrigenData.MunicipioTotal:
                    return this.Json(personal_Ano.Personal_Total_Nivel1.Select(r =>
                                    new
                                    {
                                        Item = r.CodTipo,
                                        Lista = r.Personal_Total_Nivel2.Select(l =>
                                        new
                                        {
                                            Nombre = l.Nombre,
                                            CMujer = l.CantidadMujer,
                                            CHombre = l.CantidadHombre,
                                            MMujer = l.MontoMujer,
                                            MHombre = l.MontoHombre
                                        })
                                    }), JsonRequestBehavior.AllowGet);
                default:
                    return this.Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}