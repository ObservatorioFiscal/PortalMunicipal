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

        public List<InformeGasto> LoadInformeGasto(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeGasto> InformeGastos = new List<InformeGasto>();                        
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {                
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeGasto informeGasto = Mapper.Map<IRow, InformeGasto>(row);
                    informeGasto.AnoInforme = AnoInforme;
                    informeGasto.IdMunicipalidad = IdMunicipalidad;
                    informeGasto.MesInforme = MesInforme;
                    informeGasto.UpdatedOn = this.UpdatedOn;
                    informeGasto.IdGroupInformeGasto = this.IdGroupInforme;

                    InformeGastos.Add(informeGasto);
                }
            }

            return InformeGastos;
        }

        public List<InformeIngreso> LoadInformeIngreso(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeIngreso> InformeIngresos = new List<InformeIngreso>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeIngreso informeIngreso = Mapper.Map<IRow, InformeIngreso>(row);
                    informeIngreso.AnoInforme = AnoInforme;
                    informeIngreso.IdMunicipalidad = IdMunicipalidad;
                    informeIngreso.MesInforme = MesInforme;
                    informeIngreso.UpdatedOn = this.UpdatedOn;
                    informeIngreso.IdGroupInformeIngreso = this.IdGroupInforme;

                    InformeIngresos.Add(informeIngreso);
                }
            }

            return InformeIngresos;
        }

        public List<InformeSubsidio> LoadInformeSubsidio(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeSubsidio> InformeSubsidio = new List<InformeSubsidio>();            
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {                
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeSubsidio informeSubsidio = Mapper.Map<IRow, InformeSubsidio>(row);
                    informeSubsidio.AnoInforme = AnoInforme;
                    informeSubsidio.IdMunicipalidad = IdMunicipalidad;
                    informeSubsidio.MesInforme = MesInforme;
                    informeSubsidio.UpdatedOn = this.UpdatedOn;
                    informeSubsidio.IdGroupInformeSubsidio = this.IdGroupInforme;

                    InformeSubsidio.Add(informeSubsidio);
                }
            }

            return InformeSubsidio;
        }

        public List<InformePersonalSalud> LoadInformePersonalSalud(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalSalud> InformeSalud = new List<InformePersonalSalud>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {                
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformePersonalSalud informeSalud = Mapper.Map<IRow, InformePersonalSalud>(row);
                    informeSalud.AnoInforme = AnoInforme;
                    informeSalud.IdMunicipalidad = IdMunicipalidad;
                    informeSalud.MesInforme = MesInforme;
                    informeSalud.UpdatedOn = this.UpdatedOn;
                    informeSalud.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeSalud.Add(informeSalud);
                }
            }

            return InformeSalud;
        }        

        public List<InformePersonalEducacion> LoadInformePersonalEducacion(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalEducacion> InformeEducacion = new List<InformePersonalEducacion>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformePersonalEducacion informeEducacion = Mapper.Map<IRow, InformePersonalEducacion>(row);
                    informeEducacion.AnoInforme = AnoInforme;
                    informeEducacion.IdMunicipalidad = IdMunicipalidad;
                    informeEducacion.MesInforme = MesInforme;
                    informeEducacion.UpdatedOn = this.UpdatedOn;
                    informeEducacion.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeEducacion.Add(informeEducacion);
                }
            }

            return InformeEducacion;
        }

        public List<InformePersonalCementerio> LoadInformePersonalCementerio(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalCementerio> InformeCementerio = new List<InformePersonalCementerio>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformePersonalCementerio informeCementerio = Mapper.Map<IRow, InformePersonalCementerio>(row);
                    informeCementerio.AnoInforme = AnoInforme;
                    informeCementerio.IdMunicipalidad = IdMunicipalidad;
                    informeCementerio.MesInforme = MesInforme;
                    informeCementerio.UpdatedOn = this.UpdatedOn;
                    informeCementerio.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeCementerio.Add(informeCementerio);
                }
            }

            return InformeCementerio;
        }

        public List<InformePersonalAdmServicios> LoadInformePersonalAdmServicios(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalAdmServicios> InformeAdmServicios = new List<InformePersonalAdmServicios>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformePersonalAdmServicios informeAdmServicios = Mapper.Map<IRow, InformePersonalAdmServicios>(row);
                    informeAdmServicios.AnoInforme = AnoInforme;
                    informeAdmServicios.IdMunicipalidad = IdMunicipalidad;
                    informeAdmServicios.MesInforme = MesInforme;
                    informeAdmServicios.UpdatedOn = this.UpdatedOn;
                    informeAdmServicios.IdGroupInformePersonal = this.IdGroupInforme;

                    InformeAdmServicios.Add(informeAdmServicios);
                }
            }

            return InformeAdmServicios;
        }

        public List<InformeProveedoresSalud> LoadInformeProveedoresSalud(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeProveedoresSalud> InformeSalud = new List<InformeProveedoresSalud>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeProveedoresSalud informeSalud = Mapper.Map<IRow, InformeProveedoresSalud>(row);
                    informeSalud.AnoInforme = AnoInforme;
                    informeSalud.IdMunicipalidad = IdMunicipalidad;
                    informeSalud.MesInforme = MesInforme;
                    informeSalud.UpdatedOn = this.UpdatedOn;
                    informeSalud.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeSalud.Add(informeSalud);
                }
            }

            return InformeSalud;
        }

        public List<InformeProveedoresEducacion> LoadInformeProveedoresEducacion(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeProveedoresEducacion> InformeEducacion = new List<InformeProveedoresEducacion>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeProveedoresEducacion informeEducacion = Mapper.Map<IRow, InformeProveedoresEducacion>(row);
                    informeEducacion.AnoInforme = AnoInforme;
                    informeEducacion.IdMunicipalidad = IdMunicipalidad;
                    informeEducacion.MesInforme = MesInforme;
                    informeEducacion.UpdatedOn = this.UpdatedOn;
                    informeEducacion.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeEducacion.Add(informeEducacion);
                }
            }

            return InformeEducacion;
        }
                                 
        public List<InformeProveedoresCementerio> LoadInformeProveedoresCementerio(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeProveedoresCementerio> InformeCementerio = new List<InformeProveedoresCementerio>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeProveedoresCementerio informeCementerio = Mapper.Map<IRow, InformeProveedoresCementerio>(row);
                    informeCementerio.AnoInforme = AnoInforme;
                    informeCementerio.IdMunicipalidad = IdMunicipalidad;
                    informeCementerio.MesInforme = MesInforme;
                    informeCementerio.UpdatedOn = this.UpdatedOn;
                    informeCementerio.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeCementerio.Add(informeCementerio);
                }
            }

            return InformeCementerio;
        }
                                 
        public List<InformeProveedoresAdmServicios> LoadInformeProveedoresAdmServicios(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeProveedoresAdmServicios> InformeAdmServicios = new List<InformeProveedoresAdmServicios>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeProveedoresAdmServicios informeAdmServicios = Mapper.Map<IRow, InformeProveedoresAdmServicios>(row);
                    informeAdmServicios.AnoInforme = AnoInforme;
                    informeAdmServicios.IdMunicipalidad = IdMunicipalidad;
                    informeAdmServicios.MesInforme = MesInforme;
                    informeAdmServicios.UpdatedOn = this.UpdatedOn;
                    informeAdmServicios.IdGroupInformeProveedores = this.IdGroupInforme;

                    InformeAdmServicios.Add(informeAdmServicios);
                }
            }

            return InformeAdmServicios;
        }

        public List<InformeCorporaciones> LoadInformeCorporaciones(IWorkbook excelInforme, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeCorporaciones> InformeCorporaciones = new List<InformeCorporaciones>();
            ISheet sheet = excelInforme.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                if (row != null)
                {
                    InformeCorporaciones informeCorporaciones = Mapper.Map<IRow, InformeCorporaciones>(row);
                    informeCorporaciones.AnoInforme = AnoInforme;
                    informeCorporaciones.IdMunicipalidad = IdMunicipalidad;
                    informeCorporaciones.MesInforme = MesInforme;
                    informeCorporaciones.UpdatedOn = this.UpdatedOn;
                    informeCorporaciones.IdGroupInforme = this.IdGroupInforme;

                    InformeCorporaciones.Add(informeCorporaciones);
                }
            }

            return InformeCorporaciones;
        }

    }
}