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
        protected Guid IdGroupInformeGasto { get; set; }

        public LoadReport()
        {            
            this.UpdatedOn = DateTime.UtcNow;
            this.IdGroupInformeGasto = Guid.NewGuid();
        }

        public List<InformeGasto> LoadInformeGasto(IWorkbook excelInformeGasto, int AnoInforme, int IdMunicipalidad, int MesInforme = 0)
        {
            List<InformeGasto> InformeGastos = new List<InformeGasto>();            
            InformeGastos = new List<InformeGasto>();
            ISheet sheet = excelInformeGasto.GetSheetAt(0);
            for (int rowPosition = 1; rowPosition <= sheet.LastRowNum; rowPosition++)
            {
                var row = sheet.GetRow(rowPosition);
                InformeGasto informeGasto = Mapper.Map<IRow, InformeGasto>(row);
                informeGasto.AnoInforme = AnoInforme;
                informeGasto.IdMunicipalidad = IdMunicipalidad;
                informeGasto.MesInforme = MesInforme;
                informeGasto.UpdatedOn = this.UpdatedOn;
                informeGasto.IdGroupInformeGasto = this.IdGroupInformeGasto;

                InformeGastos.Add(informeGasto);
            }

            return InformeGastos;
        }
    }
}