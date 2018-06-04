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

                cfg.CreateMap<IRow, Core.IngresoInformev2>()
                 .ForMember(dst => dst.Codigo, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                 .ForMember(dst => dst.MontoPresupuestado, src => src.MapFrom(e => e.GetCell(1).NumericCellValue))
                 .ForMember(dst => dst.MontoGastado, src => src.MapFrom(e => e.GetCell(2).NumericCellValue));                 

                cfg.CreateMap<IRow, Core.GastoInformev2>()
                .ForMember(dst => dst.Codigo, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.Cuenta, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.MontoPresupuestado, src => src.MapFrom(e => e.GetCell(2).NumericCellValue))
                .ForMember(dst => dst.MontoGastado, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));                

                cfg.CreateMap<IRow, Core.IngresoInforme>()
                .ForMember(dst => dst.TIPO, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.AREANIVEL1A, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.AREANIVEL2, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL1, src => src.MapFrom(e => e.GetCell(3).StringCellValue))
                .ForMember(dst => dst.CUENTANIVEL2, src => src.MapFrom(e => e.GetCell(4).StringCellValue))
                .ForMember(dst => dst.MontoPresupuestadoAnual, src => src.MapFrom(e => e.GetCell(5).NumericCellValue))
                .ForMember(dst => dst.MontoGastado, src => src.MapFrom(e => e.GetCell(6).NumericCellValue));

                cfg.CreateMap<IRow, Core.SubsidioInforme>()
                .ForMember(dst => dst.FECHADECRETO, src => src.MapFrom(e => e.GetCell(0).DateCellValue))
                .ForMember(dst => dst.CATEGORIA, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.ORGANIZACION, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.MONTOAPORTE, src => src.MapFrom(e => e.GetCell(3).NumericCellValue))
                .ForMember(dst => dst.OBJETIVODELAPORTE, src => src.MapFrom(e => e.GetCell(4).StringCellValue));
            
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

                cfg.CreateMap<IRow, Core.Proveedor_AdmInforme>()
                .ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                .ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))                
                .ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                cfg.CreateMap<IRow, Core.Proveedor_SaludInforme>()
                .ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                .ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                cfg.CreateMap<IRow, Core.Proveedor_EducacionInforme>()
                .ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                .ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                cfg.CreateMap<IRow, Core.Proveedor_CementerioInforme>()
                .ForMember(dst => dst.NumeroOrdenCompra, src => src.MapFrom(e => e.GetCell(0).NumericCellValue))
                .ForMember(dst => dst.Glosa, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.Proveedor, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.Monto, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));

                cfg.CreateMap<IRow, Core.CorporacionInforme>()
                .ForMember(dst => dst.ObjetivoDelAporte, src => src.MapFrom(e => e.GetCell(0).StringCellValue))
                .ForMember(dst => dst.Origen, src => src.MapFrom(e => e.GetCell(1).StringCellValue))
                .ForMember(dst => dst.Destino, src => src.MapFrom(e => e.GetCell(2).StringCellValue))
                .ForMember(dst => dst.MontoAportado, src => src.MapFrom(e => e.GetCell(3).NumericCellValue));
                #endregion

                #region proveedores

                cfg.CreateMap<Core.Proveedor_Adm_Nivel1 , Proveedor_Nivel1>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Total_Nivel1 , Proveedor_Nivel1>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Salud_Nivel1 , Proveedor_Nivel1>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Educacion_Nivel1 , Proveedor_Nivel1>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Cementerio_Nivel1 , Proveedor_Nivel1>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Adm_Nivel2 , Proveedor_Nivel2>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Total_Nivel2  ,Proveedor_Nivel2>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Salud_Nivel2 , Proveedor_Nivel2>()
                .ReverseMap();                                
                                                             
                cfg.CreateMap<Core.Proveedor_Educacion_Nivel2 , Proveedor_Nivel2>()
                .ReverseMap();                                
                                                              
                cfg.CreateMap<Core.Proveedor_Cementerio_Nivel2 , Proveedor_Nivel2>()
                .ReverseMap();
                #endregion

                #region personal
                cfg.CreateMap<Core.Personal_Adm_Nivel1, Personal_Nivel1>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Salud_Nivel1, Personal_Nivel1>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Total_Nivel1, Personal_Nivel1>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Educacion_Nivel1, Personal_Nivel1>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Cementerio_Nivel1, Personal_Nivel1>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Adm_Nivel2, Personal_Nivel2>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Salud_Nivel2, Personal_Nivel2>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Total_Nivel2, Personal_Nivel2>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Educacion_Nivel2, Personal_Nivel2>()
                .ReverseMap();

                cfg.CreateMap<Core.Personal_Cementerio_Nivel2, Personal_Nivel2>()
                .ReverseMap();

                #endregion

                #region Subsidio
                cfg.CreateMap<Core.Subsidio_Nivel1, Subsidio_N1>()
                .ForMember(dst => dst.subsidio_Nivel2, src => src.Ignore())
                .ReverseMap();

                cfg.CreateMap<Core.Subsidio_Nivel2, Subsidio_N2>()
                .ForMember(dst => dst.subsidio_Nivel3, src => src.Ignore())
                .ReverseMap();

                cfg.CreateMap<Core.Subsidio_Nivel3, Subsidio_N3>()
                .ReverseMap();
                #endregion

                #region corporacion
                cfg.CreateMap<Core.Corporacion_Nivel1, Corporacion_N1>()
                .ReverseMap();
                #endregion

                #region Gasto
                cfg.CreateMap<Core.Gasto_Nivel1, Gasto_N1>()
                .ReverseMap();

                cfg.CreateMap<Core.Gasto_Nivel2, Gasto_N2>()
                .ReverseMap();

                cfg.CreateMap<Core.Gasto_Nivel3, Gasto_N3>()
                .ReverseMap();

                cfg.CreateMap<Core.Gasto_Nivel4, Gasto_N4>()
                .ReverseMap();
                #endregion

                #region Ingreso
                cfg.CreateMap<Core.Ingreso_Nivel1, Ingreso_N1>()
                .ReverseMap();

                cfg.CreateMap<Core.Ingreso_Nivel2, Ingreso_N2>()
                .ReverseMap();

                cfg.CreateMap<Core.Ingreso_Nivel3, Ingreso_N3>()
                .ReverseMap();

                cfg.CreateMap<Core.Ingreso_Nivel4, Ingreso_N4>()
                .ReverseMap();
                #endregion
            });
        }
    }
}
