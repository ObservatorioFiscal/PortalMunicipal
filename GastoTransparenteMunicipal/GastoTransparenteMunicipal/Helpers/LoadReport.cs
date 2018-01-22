﻿using AutoMapper;
using Core;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastoTransparenteMunicipal.Helpers
{
    public class LoadReport
    {
        protected DateTime UpdatedOn { get; set; }
        public Guid IdGroupInforme { get; }
        
        public LoadReport()
        {            
            this.UpdatedOn = DateTime.UtcNow;
            this.IdGroupInforme = Guid.NewGuid();
        }

        public List<GastoInforme> LoadInformeGasto(IWorkbook excelInforme)
        {
            List<GastoInforme> InformeGastos = new List<GastoInforme>();                        
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {                
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    GastoInforme informeGasto = Mapper.Map<IRow, GastoInforme>(row);                    
                    informeGasto.UpdatedOn = this.UpdatedOn;
                    informeGasto.IdGroupInformeGasto = this.IdGroupInforme;

                    InformeGastos.Add(informeGasto);
                }
            }

            return InformeGastos;
        }

        public List<IngresoInforme> LoadInformeIngreso(IWorkbook excelInforme)
        {
            List<IngresoInforme> InformeIngresos = new List<IngresoInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    IngresoInforme informeIngreso = Mapper.Map<IRow, IngresoInforme>(row);
    
                    informeIngreso.UpdatedOn = this.UpdatedOn;
                    informeIngreso.IdGroupInformeIngreso = this.IdGroupInforme;

                    InformeIngresos.Add(informeIngreso);
                }
            }

            return InformeIngresos;
        }

        public List<SubsidioInforme> LoadInformeSubsidio(IWorkbook excelInforme)
        {
            List<SubsidioInforme> InformeSubsidio = new List<SubsidioInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    SubsidioInforme informeSubsidio = Mapper.Map<IRow, SubsidioInforme>(row);              
                    informeSubsidio.UpdatedOn = this.UpdatedOn;
                    informeSubsidio.IdGroupInformeSubsidio = this.IdGroupInforme;

                    InformeSubsidio.Add(informeSubsidio);
                }
            }

            return InformeSubsidio;
        }

        public List<Personal_SaludInforme> LoadInformePersonalSalud(IWorkbook excelInforme)
        {
            List<Personal_SaludInforme> InformeSalud = new List<Personal_SaludInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Personal_SaludInforme informeSalud = Mapper.Map<IRow, Personal_SaludInforme>(row);    
                    informeSalud.UpdatedOn = this.UpdatedOn;
                    informeSalud.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeSalud.Add(informeSalud);
                }
            }

            return InformeSalud;
        }

        public List<Personal_EducacionInforme> LoadInformePersonalEducacion(IWorkbook excelInforme)
        {
            List<Personal_EducacionInforme> InformeEducacion = new List<Personal_EducacionInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Personal_EducacionInforme informeEducacion = Mapper.Map<IRow, Personal_EducacionInforme>(row);                    
                    informeEducacion.UpdatedOn = this.UpdatedOn;
                    informeEducacion.IdGroupInformePersonal = this.IdGroupInforme;
                    InformeEducacion.Add(informeEducacion);
                }
            }

            return InformeEducacion;
        }

        public List<Personal_CementerioInforme> LoadInformePersonalCementerio(IWorkbook excelInforme)
        {
            List<Personal_CementerioInforme> InformeCementerio = new List<Personal_CementerioInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Personal_CementerioInforme informeCementerio = Mapper.Map<IRow, Personal_CementerioInforme>(row);
                    informeCementerio.UpdatedOn = this.UpdatedOn;
                    informeCementerio.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeCementerio.Add(informeCementerio);
                }
            }

            return InformeCementerio;
        }

        public List<Personal_AdmInforme> LoadInformePersonalAdmServicios(IWorkbook excelInforme)
        {
            List<Personal_AdmInforme> InformeAdmServicios = new List<Personal_AdmInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Personal_AdmInforme informeAdmServicios = Mapper.Map<IRow, Personal_AdmInforme>(row);
                    informeAdmServicios.UpdatedOn = this.UpdatedOn;
                    informeAdmServicios.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeAdmServicios.Add(informeAdmServicios);
                }
            }

            return InformeAdmServicios;
        }

        //public List<InformeProveedoresSalud> LoadInformeProveedoresSalud(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        //{
        //    List<InformeProveedoresSalud> InformeSalud = new List<InformeProveedoresSalud>();
        //    ISheet sheet = excelInforme.GetSheetAt(0);
        //    for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
        //    {
        //        var row = sheet.GetRow(rowPosition);
        //        if (row != null)
        //        {
        //            InformeProveedoresSalud informeSalud = Mapper.Map<IRow, InformeProveedoresSalud>(row);
        //            informeSalud.AnoInforme = AnoInforme;
        //            informeSalud.IdMunicipalidad = IdMunicipalidad;
        //            informeSalud.MesInforme = MesInforme;
        //            informeSalud.UpdatedOn = this.UpdatedOn;
        //            informeSalud.IdGroupInformeProveedores = this.IdGroupInforme;

        //            InformeSalud.Add(informeSalud);
        //        }
        //    }

        //    return InformeSalud;
        //}

        //public List<InformeProveedoresEducacion> LoadInformeProveedoresEducacion(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        //{
        //    List<InformeProveedoresEducacion> InformeEducacion = new List<InformeProveedoresEducacion>();
        //    ISheet sheet = excelInforme.GetSheetAt(0);
        //    for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
        //    {
        //        var row = sheet.GetRow(rowPosition);
        //        if (row != null)
        //        {
        //            InformeProveedoresEducacion informeEducacion = Mapper.Map<IRow, InformeProveedoresEducacion>(row);
        //            informeEducacion.AnoInforme = AnoInforme;
        //            informeEducacion.IdMunicipalidad = IdMunicipalidad;
        //            informeEducacion.MesInforme = MesInforme;
        //            informeEducacion.UpdatedOn = this.UpdatedOn;
        //            informeEducacion.IdGroupInformeProveedores = this.IdGroupInforme;

        //            InformeEducacion.Add(informeEducacion);
        //        }
        //    }

        //    return InformeEducacion;
        //}

        //public List<InformeProveedoresCementerio> LoadInformeProveedoresCementerio(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        //{
        //    List<InformeProveedoresCementerio> InformeCementerio = new List<InformeProveedoresCementerio>();
        //    ISheet sheet = excelInforme.GetSheetAt(0);
        //    for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
        //    {
        //        var row = sheet.GetRow(rowPosition);
        //        if (row != null)
        //        {
        //            InformeProveedoresCementerio informeCementerio = Mapper.Map<IRow, InformeProveedoresCementerio>(row);
        //            informeCementerio.AnoInforme = AnoInforme;
        //            informeCementerio.IdMunicipalidad = IdMunicipalidad;
        //            informeCementerio.MesInforme = MesInforme;
        //            informeCementerio.UpdatedOn = this.UpdatedOn;
        //            informeCementerio.IdGroupInformeProveedores = this.IdGroupInforme;

        //            InformeCementerio.Add(informeCementerio);
        //        }
        //    }

        //    return InformeCementerio;
        //}

        //public List<InformeProveedoresAdmServicios> LoadInformeProveedoresAdmServicios(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        //{
        //    List<InformeProveedoresAdmServicios> InformeAdmServicios = new List<InformeProveedoresAdmServicios>();
        //    ISheet sheet = excelInforme.GetSheetAt(0);
        //    for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
        //    {
        //        var row = sheet.GetRow(rowPosition);
        //        if (row != null)
        //        {
        //            InformeProveedoresAdmServicios informeAdmServicios = Mapper.Map<IRow, InformeProveedoresAdmServicios>(row);
        //            informeAdmServicios.AnoInforme = AnoInforme;
        //            informeAdmServicios.IdMunicipalidad = IdMunicipalidad;
        //            informeAdmServicios.MesInforme = MesInforme;
        //            informeAdmServicios.UpdatedOn = this.UpdatedOn;
        //            informeAdmServicios.IdGroupInformeProveedores = this.IdGroupInforme;

        //            InformeAdmServicios.Add(informeAdmServicios);
        //        }
        //    }

        //    return InformeAdmServicios;
        //}

        //public List<InformeCorporaciones> LoadInformeCorporaciones(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        //{
        //    List<InformeCorporaciones> InformeCorporaciones = new List<InformeCorporaciones>();
        //    ISheet sheet = excelInforme.GetSheetAt(0);
        //    for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
        //    {
        //        var row = sheet.GetRow(rowPosition);
        //        if (row != null)
        //        {
        //            InformeCorporaciones informeCorporaciones = Mapper.Map<IRow, InformeCorporaciones>(row);
        //            informeCorporaciones.AnoInforme = AnoInforme;
        //            informeCorporaciones.IdMunicipalidad = IdMunicipalidad;
        //            informeCorporaciones.MesInforme = MesInforme;
        //            informeCorporaciones.UpdatedOn = this.UpdatedOn;
        //            informeCorporaciones.IdGroupInforme = this.IdGroupInforme;

        //            InformeCorporaciones.Add(informeCorporaciones);
        //        }
        //    }

        //    return InformeCorporaciones;
        //}

    }
}