using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Newtonsoft.Json;
using AutoMapper;

namespace GastoTransparenteMunicipal.Models
{
    public class InformeProveedorModel
    {
        //private InformeProveedoresSalud _InformeProveedoresSalud                                 { get; set; }
        //private InformeProveedoresEducacion _InformeProveedoresEducacion                         { get; set; }
        //private InformeProveedoresCementerio _IinformeProveedoresCementerio                      { get; set; }
        //private InformeProveedoresAdmServicios _InformeProveedoresAdmServicios                   { get; set; }

        //private InformeProveedoresResumenSalud _InformeProveedoresResumenSalud                   { get; set; }
        //private InformeProveedoresResumenEducacion _InformeProveedoresResumenEducacion           { get; set; }
        //private InformeProveedoresResumenCementerio _InformeProveedoresResumenCementerio         { get; set; }
        //private InformeProveedoresResumenAdmServicios _InformeProveedoresResumenAdmServicios     { get; set; }
        //private InformeProveedoresResumenMunicipioTotal _InformeProveedoresResumenMunicipioTotal { get; set; }

        public string JsonMonto { get; set; }
        public string JsonProveedor { get; set; }        
        List<InformeProveedoresResumen> InformeProveedoresResumen { get; set; }

        //public List<InformeProveedoresResumen> InitWordCloudData(GastoTransparenteMunicipalEntities db, int TakeElements)
        //{
        //    var query = db.InformeProveedoresResumenMunicipioTotal.OrderByDescending(r => r.Monto).Take(20);
        //    var result = query.ToList();

        //    this.JsonProveedor = JsonConvert.SerializeObject(result.Select(r => r.Proveedor));
        //    this.JsonMonto = JsonConvert.SerializeObject(result.Select(r => r.Monto));

        //    this.InformeProveedoresResumen = Mapper.Map< List<InformeProveedoresResumenMunicipioTotal>, List<InformeProveedoresResumen> > (result);

        //    return this.InformeProveedoresResumen;
        //}        
    }
}