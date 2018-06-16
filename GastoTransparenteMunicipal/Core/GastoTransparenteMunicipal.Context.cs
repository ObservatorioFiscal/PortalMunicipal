﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GastoTransparenteMunicipalEntities : DbContext
    {
        public GastoTransparenteMunicipalEntities()
            : base("name=GastoTransparenteMunicipalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comunas> Comunas { get; set; }
        public virtual DbSet<Corporacion_Ano> Corporacion_Ano { get; set; }
        public virtual DbSet<Corporacion_Nivel1> Corporacion_Nivel1 { get; set; }
        public virtual DbSet<CorporacionInforme> CorporacionInforme { get; set; }
        public virtual DbSet<Gasto_Ano> Gasto_Ano { get; set; }
        public virtual DbSet<Gasto_Glosa> Gasto_Glosa { get; set; }
        public virtual DbSet<Gasto_GlosaCodigo> Gasto_GlosaCodigo { get; set; }
        public virtual DbSet<Gasto_Nivel1> Gasto_Nivel1 { get; set; }
        public virtual DbSet<Gasto_Nivel2> Gasto_Nivel2 { get; set; }
        public virtual DbSet<Gasto_Nivel3> Gasto_Nivel3 { get; set; }
        public virtual DbSet<Gasto_Nivel4> Gasto_Nivel4 { get; set; }
        public virtual DbSet<GastoInforme> GastoInforme { get; set; }
        public virtual DbSet<GastoInformev2> GastoInformev2 { get; set; }
        public virtual DbSet<Ingreso_Ano> Ingreso_Ano { get; set; }
        public virtual DbSet<Ingreso_Glosa> Ingreso_Glosa { get; set; }
        public virtual DbSet<Ingreso_GlosaCodigo> Ingreso_GlosaCodigo { get; set; }
        public virtual DbSet<Ingreso_Nivel1> Ingreso_Nivel1 { get; set; }
        public virtual DbSet<Ingreso_Nivel2> Ingreso_Nivel2 { get; set; }
        public virtual DbSet<Ingreso_Nivel3> Ingreso_Nivel3 { get; set; }
        public virtual DbSet<Ingreso_Nivel4> Ingreso_Nivel4 { get; set; }
        public virtual DbSet<IngresoInforme> IngresoInforme { get; set; }
        public virtual DbSet<IngresoInformev2> IngresoInformev2 { get; set; }
        public virtual DbSet<Municipalidad> Municipalidad { get; set; }
        public virtual DbSet<Personal_Adm_Nivel1> Personal_Adm_Nivel1 { get; set; }
        public virtual DbSet<Personal_Adm_Nivel2> Personal_Adm_Nivel2 { get; set; }
        public virtual DbSet<Personal_AdmInforme> Personal_AdmInforme { get; set; }
        public virtual DbSet<Personal_Ano> Personal_Ano { get; set; }
        public virtual DbSet<Personal_Cementerio_Nivel1> Personal_Cementerio_Nivel1 { get; set; }
        public virtual DbSet<Personal_Cementerio_Nivel2> Personal_Cementerio_Nivel2 { get; set; }
        public virtual DbSet<Personal_CementerioInforme> Personal_CementerioInforme { get; set; }
        public virtual DbSet<Personal_Educacion_Nivel1> Personal_Educacion_Nivel1 { get; set; }
        public virtual DbSet<Personal_Educacion_Nivel2> Personal_Educacion_Nivel2 { get; set; }
        public virtual DbSet<Personal_EducacionInforme> Personal_EducacionInforme { get; set; }
        public virtual DbSet<Personal_Salud_Nivel1> Personal_Salud_Nivel1 { get; set; }
        public virtual DbSet<Personal_Salud_Nivel2> Personal_Salud_Nivel2 { get; set; }
        public virtual DbSet<Personal_SaludInforme> Personal_SaludInforme { get; set; }
        public virtual DbSet<Personal_Total_Nivel1> Personal_Total_Nivel1 { get; set; }
        public virtual DbSet<Personal_Total_Nivel2> Personal_Total_Nivel2 { get; set; }
        public virtual DbSet<Proveedor_Adm_Nivel1> Proveedor_Adm_Nivel1 { get; set; }
        public virtual DbSet<Proveedor_Adm_Nivel2> Proveedor_Adm_Nivel2 { get; set; }
        public virtual DbSet<Proveedor_AdmInforme> Proveedor_AdmInforme { get; set; }
        public virtual DbSet<Proveedor_Ano> Proveedor_Ano { get; set; }
        public virtual DbSet<Proveedor_Cementerio_Nivel1> Proveedor_Cementerio_Nivel1 { get; set; }
        public virtual DbSet<Proveedor_Cementerio_Nivel2> Proveedor_Cementerio_Nivel2 { get; set; }
        public virtual DbSet<Proveedor_CementerioInforme> Proveedor_CementerioInforme { get; set; }
        public virtual DbSet<Proveedor_Educacion_Nivel1> Proveedor_Educacion_Nivel1 { get; set; }
        public virtual DbSet<Proveedor_Educacion_Nivel2> Proveedor_Educacion_Nivel2 { get; set; }
        public virtual DbSet<Proveedor_EducacionInforme> Proveedor_EducacionInforme { get; set; }
        public virtual DbSet<Proveedor_Salud_Nivel1> Proveedor_Salud_Nivel1 { get; set; }
        public virtual DbSet<Proveedor_Salud_Nivel2> Proveedor_Salud_Nivel2 { get; set; }
        public virtual DbSet<Proveedor_SaludInforme> Proveedor_SaludInforme { get; set; }
        public virtual DbSet<Proveedor_Total_Nivel1> Proveedor_Total_Nivel1 { get; set; }
        public virtual DbSet<Proveedor_Total_Nivel2> Proveedor_Total_Nivel2 { get; set; }
        public virtual DbSet<Subsidio_Ano> Subsidio_Ano { get; set; }
        public virtual DbSet<Subsidio_Nivel1> Subsidio_Nivel1 { get; set; }
        public virtual DbSet<Subsidio_Nivel2> Subsidio_Nivel2 { get; set; }
        public virtual DbSet<Subsidio_Nivel3> Subsidio_Nivel3 { get; set; }
        public virtual DbSet<SubsidioInforme> SubsidioInforme { get; set; }
        public virtual DbSet<Anos_Invisible> Anos_Invisible { get; set; }
        public virtual DbSet<Corporacion_Ano_Visible> Corporacion_Ano_Visible { get; set; }
        public virtual DbSet<Gasto_Ano_Visible> Gasto_Ano_Visible { get; set; }
        public virtual DbSet<Ingreso_Ano_Visible> Ingreso_Ano_Visible { get; set; }
        public virtual DbSet<Personal_Ano_Visible> Personal_Ano_Visible { get; set; }
        public virtual DbSet<Proveedor_Ano_Visible> Proveedor_Ano_Visible { get; set; }
        public virtual DbSet<Subsidio_Ano_Visible> Subsidio_Ano_Visible { get; set; }
    
        public virtual int SP_InformeCorporaciones(Nullable<System.Guid> idGroupInforme, Nullable<long> idAno)
        {
            var idGroupInformeParameter = idGroupInforme.HasValue ?
                new ObjectParameter("IdGroupInforme", idGroupInforme) :
                new ObjectParameter("IdGroupInforme", typeof(System.Guid));
    
            var idAnoParameter = idAno.HasValue ?
                new ObjectParameter("IdAno", idAno) :
                new ObjectParameter("IdAno", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformeCorporaciones", idGroupInformeParameter, idAnoParameter);
        }
    
        public virtual int SP_InformeGasto(Nullable<System.Guid> idGroupReportGasto, Nullable<long> idAn)
        {
            var idGroupReportGastoParameter = idGroupReportGasto.HasValue ?
                new ObjectParameter("IdGroupReportGasto", idGroupReportGasto) :
                new ObjectParameter("IdGroupReportGasto", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformeGasto", idGroupReportGastoParameter, idAnParameter);
        }
    
        public virtual int SP_InformeIngreso(Nullable<System.Guid> idGroupReportIngreso, Nullable<long> idAn)
        {
            var idGroupReportIngresoParameter = idGroupReportIngreso.HasValue ?
                new ObjectParameter("IdGroupReportIngreso", idGroupReportIngreso) :
                new ObjectParameter("IdGroupReportIngreso", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformeIngreso", idGroupReportIngresoParameter, idAnParameter);
        }
    
        public virtual int SP_InformePersonalAdm(Nullable<System.Guid> idGroupInformePersona, Nullable<long> idAn)
        {
            var idGroupInformePersonaParameter = idGroupInformePersona.HasValue ?
                new ObjectParameter("IdGroupInformePersona", idGroupInformePersona) :
                new ObjectParameter("IdGroupInformePersona", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformePersonalAdm", idGroupInformePersonaParameter, idAnParameter);
        }
    
        public virtual int SP_InformePersonalCementerio(Nullable<System.Guid> idGroupInformePersona, Nullable<long> idAn)
        {
            var idGroupInformePersonaParameter = idGroupInformePersona.HasValue ?
                new ObjectParameter("IdGroupInformePersona", idGroupInformePersona) :
                new ObjectParameter("IdGroupInformePersona", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformePersonalCementerio", idGroupInformePersonaParameter, idAnParameter);
        }
    
        public virtual int SP_InformePersonalEducacion(Nullable<System.Guid> idGroupInformePersona, Nullable<long> idAn)
        {
            var idGroupInformePersonaParameter = idGroupInformePersona.HasValue ?
                new ObjectParameter("IdGroupInformePersona", idGroupInformePersona) :
                new ObjectParameter("IdGroupInformePersona", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformePersonalEducacion", idGroupInformePersonaParameter, idAnParameter);
        }
    
        public virtual int SP_InformePersonalMunicipioTotal(Nullable<System.Guid> idGroupInformePersona, Nullable<long> idAn)
        {
            var idGroupInformePersonaParameter = idGroupInformePersona.HasValue ?
                new ObjectParameter("IdGroupInformePersona", idGroupInformePersona) :
                new ObjectParameter("IdGroupInformePersona", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformePersonalMunicipioTotal", idGroupInformePersonaParameter, idAnParameter);
        }
    
        public virtual int SP_InformePersonalSalud(Nullable<System.Guid> idGroupInformePersona, Nullable<long> idAn)
        {
            var idGroupInformePersonaParameter = idGroupInformePersona.HasValue ?
                new ObjectParameter("IdGroupInformePersona", idGroupInformePersona) :
                new ObjectParameter("IdGroupInformePersona", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformePersonalSalud", idGroupInformePersonaParameter, idAnParameter);
        }
    
        public virtual int SP_InformeSubsidio(Nullable<System.Guid> idGroupReportSubsidio, Nullable<long> idAn)
        {
            var idGroupReportSubsidioParameter = idGroupReportSubsidio.HasValue ?
                new ObjectParameter("IdGroupReportSubsidio", idGroupReportSubsidio) :
                new ObjectParameter("IdGroupReportSubsidio", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_InformeSubsidio", idGroupReportSubsidioParameter, idAnParameter);
        }
    
        public virtual int SP_ProveedorAdm(Nullable<System.Guid> idGroupReportGasto, Nullable<long> idAn)
        {
            var idGroupReportGastoParameter = idGroupReportGasto.HasValue ?
                new ObjectParameter("IdGroupReportGasto", idGroupReportGasto) :
                new ObjectParameter("IdGroupReportGasto", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ProveedorAdm", idGroupReportGastoParameter, idAnParameter);
        }
    
        public virtual int SP_ProveedorCementerio(Nullable<System.Guid> idGroupReportGasto, Nullable<long> idAn)
        {
            var idGroupReportGastoParameter = idGroupReportGasto.HasValue ?
                new ObjectParameter("IdGroupReportGasto", idGroupReportGasto) :
                new ObjectParameter("IdGroupReportGasto", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ProveedorCementerio", idGroupReportGastoParameter, idAnParameter);
        }
    
        public virtual int SP_ProveedorEducacion(Nullable<System.Guid> idGroupReportGasto, Nullable<long> idAn)
        {
            var idGroupReportGastoParameter = idGroupReportGasto.HasValue ?
                new ObjectParameter("IdGroupReportGasto", idGroupReportGasto) :
                new ObjectParameter("IdGroupReportGasto", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ProveedorEducacion", idGroupReportGastoParameter, idAnParameter);
        }
    
        public virtual int SP_ProveedorSalud(Nullable<System.Guid> idGroupReportGasto, Nullable<long> idAn)
        {
            var idGroupReportGastoParameter = idGroupReportGasto.HasValue ?
                new ObjectParameter("IdGroupReportGasto", idGroupReportGasto) :
                new ObjectParameter("IdGroupReportGasto", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ProveedorSalud", idGroupReportGastoParameter, idAnParameter);
        }
    
        public virtual int SP_ProveedorTotal(Nullable<System.Guid> idGroupReportGasto, Nullable<long> idAn)
        {
            var idGroupReportGastoParameter = idGroupReportGasto.HasValue ?
                new ObjectParameter("IdGroupReportGasto", idGroupReportGasto) :
                new ObjectParameter("IdGroupReportGasto", typeof(System.Guid));
    
            var idAnParameter = idAn.HasValue ?
                new ObjectParameter("IdAn", idAn) :
                new ObjectParameter("IdAn", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ProveedorTotal", idGroupReportGastoParameter, idAnParameter);
        }
    }
}
