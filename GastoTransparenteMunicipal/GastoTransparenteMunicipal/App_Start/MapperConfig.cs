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

                cfg.CreateMap<IRow, Core.InformeSubsidio>()
                .ForMember(dst => dst.CATEGORIA, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.ORGANIZACION, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.FECHADECRETO, src => src.MapFrom(e => e.GetCell(2).DateCellValue))                
                .ForMember(dst => dst.OBJETIVODELAPORTE, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.MONTOAPORTE, src => src.MapFrom(e => e.GetCell(4).NumericCellValue));


                cfg.CreateMap<IRow, Core.InformePersonalAdmServicios>()
                .ForMember(dst => dst.GENERO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.EDAD, src => src.MapFrom(e => e.GetCell(1).NumericCellValue))
                .ForMember(dst => dst.CALIDADJURIDICA, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.PROFESION, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.NIVELACADEMICO, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.ESTAMENTO, src => src.MapFrom(e => e.GetCell(5).StringCellValue))
                .ForMember(dst => dst.GRADO, src => src.MapFrom(e => e.GetCell(6).NumericCellValue))
                .ForMember(dst => dst.ANTIGUEDAD, src => src.MapFrom(e => e.GetCell(7).CellType == CellType.String ? e.GetCell(7).StringCellValue : e.GetCell(7).NumericCellValue.ToString()))
                .ForMember(dst => dst.AREA, src => src.MapFrom(e => e.GetCell(8).StringCellValue))
                .ForMember(dst => dst.SUELDOHABERES, src => src.MapFrom(e => e.GetCell(9).NumericCellValue));

                cfg.CreateMap<IRow, Core.InformePersonalSalud>()
                .ForMember(dst => dst.GENERO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.EDAD, src => src.MapFrom(e => e.GetCell(1).NumericCellValue))
                .ForMember(dst => dst.CALIDADJURIDICA, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.PROFESION, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.NIVELACADEMICO, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.ESTAMENTO, src => src.MapFrom(e => e.GetCell(5).StringCellValue))
                .ForMember(dst => dst.GRADO, src => src.MapFrom(e => e.GetCell(6).NumericCellValue))
                .ForMember(dst => dst.ANTIGUEDAD, src => src.MapFrom(e => e.GetCell(7).CellType == CellType.String ? e.GetCell(7).StringCellValue : e.GetCell(7).NumericCellValue.ToString()))
                .ForMember(dst => dst.AREA, src => src.MapFrom(e => e.GetCell(8).StringCellValue))
                .ForMember(dst => dst.SUELDOHABERES, src => src.MapFrom(e => e.GetCell(9).NumericCellValue));

                cfg.CreateMap<IRow, Core.InformePersonalEducacion>()
                .ForMember(dst => dst.GENERO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.EDAD, src => src.MapFrom(e => e.GetCell(1).NumericCellValue))
                .ForMember(dst => dst.CALIDADJURIDICA, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.PROFESION, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.NIVELACADEMICO, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.ESTAMENTO, src => src.MapFrom(e => e.GetCell(5).StringCellValue))
                .ForMember(dst => dst.GRADO, src => src.MapFrom(e => e.GetCell(6).NumericCellValue))
                .ForMember(dst => dst.ANTIGUEDAD, src => src.MapFrom(e => e.GetCell(7).CellType == CellType.String ? e.GetCell(7).StringCellValue : e.GetCell(7).NumericCellValue.ToString()))
                .ForMember(dst => dst.AREA, src => src.MapFrom(e => e.GetCell(8).StringCellValue))
                .ForMember(dst => dst.SUELDOHABERES, src => src.MapFrom(e => e.GetCell(9).NumericCellValue));

                cfg.CreateMap<IRow, Core.InformePersonalCementerio>()
                .ForMember(dst => dst.GENERO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.EDAD, src => src.MapFrom(e => e.GetCell(1).NumericCellValue))
                .ForMember(dst => dst.CALIDADJURIDICA, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.PROFESION, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.NIVELACADEMICO, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.ESTAMENTO, src => src.MapFrom(e => e.GetCell(5).StringCellValue))
                .ForMember(dst => dst.GRADO, src => src.MapFrom(e => e.GetCell(6).NumericCellValue))
                .ForMember(dst => dst.ANTIGUEDAD, src => src.MapFrom(e => e.GetCell(7).CellType == CellType.String ? e.GetCell(7).StringCellValue : e.GetCell(7).NumericCellValue.ToString() ))
                .ForMember(dst => dst.AREA, src => src.MapFrom(e => e.GetCell(8).StringCellValue))
                .ForMember(dst => dst.SUELDOHABERES, src => src.MapFrom(e => e.GetCell(9).NumericCellValue));
            });
        }
    }
}
