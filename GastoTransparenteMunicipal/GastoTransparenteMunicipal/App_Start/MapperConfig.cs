using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using NPOI.SS.UserModel;

namespace GastoTransparenteMunicipal
{
    public class MapperConfig
    {
        public static void Mapping()
        {
            Mapper.Initialize(cfg => {

                cfg.CreateMap<IRow, Core.InformeGasto>()
                .ForMember(dst => dst.TIPO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.AREANIVEL1A, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.AREANIVEL2, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL1, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL2, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.MontoPresupuestadoAnual, src => src.MapFrom(e => e.GetCell(5).NumericCellValue))
                .ForMember(dst => dst.MontoGastado, src => src.MapFrom(e => e.GetCell(6).NumericCellValue));
            });
        }
    }
}