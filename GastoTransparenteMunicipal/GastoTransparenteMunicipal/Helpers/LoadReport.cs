using AutoMapper;
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

        public List<Proveedor_SaludInforme> LoadInformeProveedoresSalud(IWorkbook excelInforme)
        {
            List<Proveedor_SaludInforme> InformeSalud = new List<Proveedor_SaludInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Proveedor_SaludInforme informeSalud = Mapper.Map<IRow, Proveedor_SaludInforme>(row);
                    informeSalud.UpdatedOn = this.UpdatedOn;
                    informeSalud.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeSalud.Add(informeSalud);
                }
            }

            return InformeSalud;
        }

        public List<Proveedor_EducacionInforme> LoadInformeProveedoresEducacion(IWorkbook excelInforme)
        {
            List<Proveedor_EducacionInforme> InformeEducacion = new List<Proveedor_EducacionInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Proveedor_EducacionInforme informeEducacion = Mapper.Map<IRow, Proveedor_EducacionInforme>(row);
                    informeEducacion.UpdatedOn = this.UpdatedOn;
                    informeEducacion.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeEducacion.Add(informeEducacion);
                }
            }

            return InformeEducacion;
        }

        public List<Proveedor_CementerioInforme> LoadInformeProveedoresCementerio(IWorkbook excelInforme)
        {
            List<Proveedor_CementerioInforme> InformeCementerio = new List<Proveedor_CementerioInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Proveedor_CementerioInforme informeCementerio = Mapper.Map<IRow, Proveedor_CementerioInforme>(row);
                    informeCementerio.UpdatedOn = this.UpdatedOn;
                    informeCementerio.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeCementerio.Add(informeCementerio);
                }
            }

            return InformeCementerio;
        }

        public List<Proveedor_AdmInforme> LoadInformeProveedoresAdmServicios(IWorkbook excelInforme)
        {
            List<Proveedor_AdmInforme> InformeAdmServicios = new List<Proveedor_AdmInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    Proveedor_AdmInforme informeAdmServicios = Mapper.Map<IRow, Proveedor_AdmInforme>(row);          
                    informeAdmServicios.UpdatedOn = this.UpdatedOn;
                    informeAdmServicios.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeAdmServicios.Add(informeAdmServicios);
                }
            }

            return InformeAdmServicios;
        }

        public List<CorporacionInforme> LoadInformeCorporaciones(IWorkbook excelInforme)
        {
            List<CorporacionInforme> InformeCorporaciones = new List<CorporacionInforme>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    CorporacionInforme informeCorporaciones = Mapper.Map<IRow, CorporacionInforme>(row);
                    informeCorporaciones.UpdatedOn = this.UpdatedOn;
                    informeCorporaciones.IdGroupInforme = this.IdGroupInforme;

                    InformeCorporaciones.Add(informeCorporaciones);
                }
            }

            return InformeCorporaciones;
        }

    }
}