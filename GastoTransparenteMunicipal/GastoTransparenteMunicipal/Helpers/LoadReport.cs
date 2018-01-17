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

        public List<InformeGasto> LoadInformeGasto(IWorkbook excelInformeGasto, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeGasto> InformeGastos = new List<InformeGasto>();                        
            ISheet sheet = excelInformeGasto.GetSheetAt(0);
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

        public List<InformeSubsidio> LoadInformeSubsidio(IWorkbook excelInformeSubsidio, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeSubsidio> InformeSubsidio = new List<InformeSubsidio>();            
            ISheet sheet = excelInformeSubsidio.GetSheetAt(0);
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

        public List<InformePersonalSalud> LoadInformePersonalSalud(IWorkbook excelInformeSubsidio, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalSalud> InformeSalud = new List<InformePersonalSalud>();
            ISheet sheet = excelInformeSubsidio.GetSheetAt(0);
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

        public List<InformePersonalEducacion> LoadInformePersonalEducacion(IWorkbook excelInformeSubsidio, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalEducacion> InformeEducacion = new List<InformePersonalEducacion>();
            ISheet sheet = excelInformeSubsidio.GetSheetAt(0);
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

        public List<InformePersonalCementerio> LoadInformePersonalCementerio(IWorkbook excelInformeSubsidio, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalCementerio> InformeCementerio = new List<InformePersonalCementerio>();
            ISheet sheet = excelInformeSubsidio.GetSheetAt(0);
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

        public List<InformePersonalAdmServicios> LoadInformePersonalAdmServicios(IWorkbook excelInformeSubsidio, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformePersonalAdmServicios> InformeAdmServicios = new List<InformePersonalAdmServicios>();
            ISheet sheet = excelInformeSubsidio.GetSheetAt(0);
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
    }
}