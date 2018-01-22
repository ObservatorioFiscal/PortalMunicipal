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

                #region Carga de archivo
                cfg.CreateMap<IRow, Core.GastoInforme>()
                .ForMember(dst => dst.TIPO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.AREANIVEL1A, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.AREANIVEL2, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL1, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL2, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.MontoPresupuestadoAnual, src => src.MapFrom(e => e.GetCell(5).NumericCellValue))
                .ForMember(dst => dst.MontoGastado, src => src.MapFrom(e => e.GetCell(6).NumericCellValue));

                cfg.CreateMap<IRow, Core.IngresoInforme>()
                .ForMember(dst => dst.TIPO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.AREANIVEL1A, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.AREANIVEL2, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL1, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL2, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.MontoPresupuestadoAnual, src => src.MapFrom(e => e.GetCell(5).NumericCellValue))
                .ForMember(dst => dst.MontoGastado, src => src.MapFrom(e => e.GetCell(6).NumericCellValue));

                cfg.CreateMap<IRow, Core.SubsidioInforme>()
                .ForMember(dst => dst.CATEGORIA, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.ORGANIZACION, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.FECHADECRETO, src => src.MapFrom(e => e.GetCell(2).DateCellValue))
                .ForMember(dst => dst.OBJETIVODELAPORTE, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.MONTOAPORTE, src => src.MapFrom(e => e.GetCell(4).NumericCellValue));


                cfg.CreateMap<IRow, Core.Personal_AdmInforme>()
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

                cfg.CreateMap<IRow, Core.Personal_SaludInforme>()
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

                cfg.CreateMap<IRow, Core.Personal_EducacionInforme>()
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

                cfg.CreateMap<IRow, Core.Personal_CementerioInforme>()
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

                //cfg.CreateMap<IRow, Core.InformeProveedoresAdmServicios>()
                //.ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                //.ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                //.ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))                
                //.ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                //cfg.CreateMap<IRow, Core.InformeProveedoresSalud>()
                //.ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                //.ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                //.ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                //.ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                //cfg.CreateMap<IRow, Core.InformeProveedoresEducacion>()
                //.ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                //.ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                //.ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                //.ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                //cfg.CreateMap<IRow, Core.InformeProveedoresCementerio>()
                //.ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                //.ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                //.ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                //.ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                //cfg.CreateMap<IRow, Core.InformeCorporaciones>()
                //.ForMember(dst => dst.ObjetivoDelAporte, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                //.ForMember(dst => dst.Origen, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                //.ForMember(dst => dst.Destino, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                //.ForMember(dst => dst.MontoAportado, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));
                #endregion

                #region proveedores
                //cfg.CreateMap<InformeProveedores, Core.InformeProveedoresAdmServicios>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedores, Core.InformeProveedoresEducacion>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedores, Core.InformeProveedoresCementerio>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedores, Core.InformeProveedoresSalud>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedoresResumen, Core.InformeProveedoresResumenAdmServicios>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedoresResumen, Core.InformeProveedoresResumenEducacion>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedoresResumen, Core.InformeProveedoresResumenCementerio>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedoresResumen, Core.InformeProveedoresResumenSalud>()
                //.ReverseMap();

                //cfg.CreateMap<InformeProveedoresResumen, Core.InformeProveedoresResumenMunicipioTotal>()
                //.ReverseMap();
                #endregion 

            });
        }
    }
}
