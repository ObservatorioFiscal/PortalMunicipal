
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/25/2018 12:05:32
-- Generated from EDMX file: C:\Users\METRICARTS06\Documents\Visual Studio 2015\Projects\Others\PortalMunicipal\GastoTransparenteMunicipal\Core\GastoTransparenteMunicipal.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GastoTransparenteMunicipal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Corporaci__IdAno__71D1E811]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Corporacion_Nivel1] DROP CONSTRAINT [FK__Corporaci__IdAno__71D1E811];
GO
IF OBJECT_ID(N'[dbo].[FK__Corporaci__IdMun__70DDC3D8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Corporacion_Ano] DROP CONSTRAINT [FK__Corporaci__IdMun__70DDC3D8];
GO
IF OBJECT_ID(N'[dbo].[FK__Gasto_Ano__IdMun__72C60C4A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gasto_Ano] DROP CONSTRAINT [FK__Gasto_Ano__IdMun__72C60C4A];
GO
IF OBJECT_ID(N'[dbo].[FK__Gasto_Niv__IdAno__73BA3083]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gasto_Nivel1] DROP CONSTRAINT [FK__Gasto_Niv__IdAno__73BA3083];
GO
IF OBJECT_ID(N'[dbo].[FK__Gasto_Niv__IdNiv__74AE54BC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gasto_Nivel2] DROP CONSTRAINT [FK__Gasto_Niv__IdNiv__74AE54BC];
GO
IF OBJECT_ID(N'[dbo].[FK__Gasto_Niv__IdNiv__75A278F5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gasto_Nivel3] DROP CONSTRAINT [FK__Gasto_Niv__IdNiv__75A278F5];
GO
IF OBJECT_ID(N'[dbo].[FK__Gasto_Niv__IdNiv__76969D2E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gasto_Nivel4] DROP CONSTRAINT [FK__Gasto_Niv__IdNiv__76969D2E];
GO
IF OBJECT_ID(N'[dbo].[FK__Ingreso_A__IdMun__778AC167]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingreso_Ano] DROP CONSTRAINT [FK__Ingreso_A__IdMun__778AC167];
GO
IF OBJECT_ID(N'[dbo].[FK__Ingreso_N__IdAno__787EE5A0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingreso_Nivel1] DROP CONSTRAINT [FK__Ingreso_N__IdAno__787EE5A0];
GO
IF OBJECT_ID(N'[dbo].[FK__Ingreso_N__IdNiv__797309D9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingreso_Nivel2] DROP CONSTRAINT [FK__Ingreso_N__IdNiv__797309D9];
GO
IF OBJECT_ID(N'[dbo].[FK__Ingreso_N__IdNiv__7A672E12]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingreso_Nivel3] DROP CONSTRAINT [FK__Ingreso_N__IdNiv__7A672E12];
GO
IF OBJECT_ID(N'[dbo].[FK__Ingreso_N__IdNiv__7B5B524B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingreso_Nivel4] DROP CONSTRAINT [FK__Ingreso_N__IdNiv__7B5B524B];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdAno__01142BA1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Educacion_Nivel1] DROP CONSTRAINT [FK__Personal___IdAno__01142BA1];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdAno__02FC7413]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Salud_Nivel1] DROP CONSTRAINT [FK__Personal___IdAno__02FC7413];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdAno__04E4BC85]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Total_Nivel1] DROP CONSTRAINT [FK__Personal___IdAno__04E4BC85];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdAno__7C4F7684]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Adm_Nivel1] DROP CONSTRAINT [FK__Personal___IdAno__7C4F7684];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdAno__7F2BE32F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Cementerio_Nivel1] DROP CONSTRAINT [FK__Personal___IdAno__7F2BE32F];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdMun__7E37BEF6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Ano] DROP CONSTRAINT [FK__Personal___IdMun__7E37BEF6];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdNiv__00200768]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Cementerio_Nivel2] DROP CONSTRAINT [FK__Personal___IdNiv__00200768];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdNiv__02084FDA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Educacion_Nivel2] DROP CONSTRAINT [FK__Personal___IdNiv__02084FDA];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdNiv__03F0984C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Salud_Nivel2] DROP CONSTRAINT [FK__Personal___IdNiv__03F0984C];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdNiv__05D8E0BE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Total_Nivel2] DROP CONSTRAINT [FK__Personal___IdNiv__05D8E0BE];
GO
IF OBJECT_ID(N'[dbo].[FK__Personal___IdNiv__7D439ABD]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Adm_Nivel2] DROP CONSTRAINT [FK__Personal___IdNiv__7D439ABD];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdAno__06CD04F7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Adm_Nivel1] DROP CONSTRAINT [FK__Proveedor__IdAno__06CD04F7];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdAno__09A971A2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Cementerio_Nivel1] DROP CONSTRAINT [FK__Proveedor__IdAno__09A971A2];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdAno__0B91BA14]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Educacion_Nivel1] DROP CONSTRAINT [FK__Proveedor__IdAno__0B91BA14];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdAno__0D7A0286]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Salud_Nivel1] DROP CONSTRAINT [FK__Proveedor__IdAno__0D7A0286];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdAno__0F624AF8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Total_Nivel1] DROP CONSTRAINT [FK__Proveedor__IdAno__0F624AF8];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdMun__08B54D69]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Ano] DROP CONSTRAINT [FK__Proveedor__IdMun__08B54D69];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdNIv__07C12930]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Adm_Nivel2] DROP CONSTRAINT [FK__Proveedor__IdNIv__07C12930];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdNIv__0A9D95DB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Cementerio_Nivel2] DROP CONSTRAINT [FK__Proveedor__IdNIv__0A9D95DB];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdNIv__0C85DE4D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Educacion_Nivel2] DROP CONSTRAINT [FK__Proveedor__IdNIv__0C85DE4D];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdNIv__0E6E26BF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Salud_Nivel2] DROP CONSTRAINT [FK__Proveedor__IdNIv__0E6E26BF];
GO
IF OBJECT_ID(N'[dbo].[FK__Proveedor__IdNIv__10566F31]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedor_Total_Nivel2] DROP CONSTRAINT [FK__Proveedor__IdNIv__10566F31];
GO
IF OBJECT_ID(N'[dbo].[FK__Subsidio___IdAno__123EB7A3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subsidio_Nivel1] DROP CONSTRAINT [FK__Subsidio___IdAno__123EB7A3];
GO
IF OBJECT_ID(N'[dbo].[FK__Subsidio___IdAno__1332DBDC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subsidio_Nivel2] DROP CONSTRAINT [FK__Subsidio___IdAno__1332DBDC];
GO
IF OBJECT_ID(N'[dbo].[FK__Subsidio___IdMun__114A936A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subsidio_Ano] DROP CONSTRAINT [FK__Subsidio___IdMun__114A936A];
GO
IF OBJECT_ID(N'[dbo].[FK__Subsidio___IdNiv__14270015]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subsidio_Nivel2] DROP CONSTRAINT [FK__Subsidio___IdNiv__14270015];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Corporacion_Ano]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Corporacion_Ano];
GO
IF OBJECT_ID(N'[dbo].[Corporacion_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Corporacion_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[CorporacionInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CorporacionInforme];
GO
IF OBJECT_ID(N'[dbo].[Gasto_Ano]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gasto_Ano];
GO
IF OBJECT_ID(N'[dbo].[Gasto_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gasto_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Gasto_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gasto_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Gasto_Nivel3]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gasto_Nivel3];
GO
IF OBJECT_ID(N'[dbo].[Gasto_Nivel4]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gasto_Nivel4];
GO
IF OBJECT_ID(N'[dbo].[GastoInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GastoInforme];
GO
IF OBJECT_ID(N'[dbo].[Ingreso_Ano]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingreso_Ano];
GO
IF OBJECT_ID(N'[dbo].[Ingreso_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingreso_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Ingreso_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingreso_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Ingreso_Nivel3]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingreso_Nivel3];
GO
IF OBJECT_ID(N'[dbo].[Ingreso_Nivel4]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingreso_Nivel4];
GO
IF OBJECT_ID(N'[dbo].[IngresoInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IngresoInforme];
GO
IF OBJECT_ID(N'[dbo].[Municipalidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Municipalidad];
GO
IF OBJECT_ID(N'[dbo].[Personal_Adm_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Adm_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Personal_Adm_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Adm_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Personal_AdmInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_AdmInforme];
GO
IF OBJECT_ID(N'[dbo].[Personal_Ano]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Ano];
GO
IF OBJECT_ID(N'[dbo].[Personal_Cementerio_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Cementerio_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Personal_Cementerio_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Cementerio_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Personal_CementerioInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_CementerioInforme];
GO
IF OBJECT_ID(N'[dbo].[Personal_Educacion_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Educacion_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Personal_Educacion_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Educacion_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Personal_EducacionInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_EducacionInforme];
GO
IF OBJECT_ID(N'[dbo].[Personal_Salud_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Salud_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Personal_Salud_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Salud_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Personal_SaludInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_SaludInforme];
GO
IF OBJECT_ID(N'[dbo].[Personal_Total_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Total_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Personal_Total_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Total_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Adm_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Adm_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Adm_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Adm_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_AdmInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_AdmInforme];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Ano]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Ano];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Cementerio_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Cementerio_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Cementerio_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Cementerio_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_CementerioInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_CementerioInforme];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Educacion_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Educacion_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Educacion_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Educacion_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_EducacionInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_EducacionInforme];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Salud_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Salud_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Salud_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Salud_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_SaludInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_SaludInforme];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Total_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Total_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Proveedor_Total_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedor_Total_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Subsidio_Ano]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subsidio_Ano];
GO
IF OBJECT_ID(N'[dbo].[Subsidio_Nivel1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subsidio_Nivel1];
GO
IF OBJECT_ID(N'[dbo].[Subsidio_Nivel2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subsidio_Nivel2];
GO
IF OBJECT_ID(N'[dbo].[Subsidio_Nivel3]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subsidio_Nivel3];
GO
IF OBJECT_ID(N'[dbo].[SubsidioInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubsidioInforme];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Corporacion_Ano'
CREATE TABLE [dbo].[Corporacion_Ano] (
    [IdAno] bigint IDENTITY(1,1) NOT NULL,
    [IdMunicipalidad] int  NULL,
    [Ano] int  NULL,
    [UpdatedOn] datetime  NULL,
    [Mes] int  NULL
);
GO

-- Creating table 'Corporacion_Nivel1'
CREATE TABLE [dbo].[Corporacion_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Origen] nvarchar(600)  NULL,
    [Destino] nvarchar(600)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'CorporacionInforme'
CREATE TABLE [dbo].[CorporacionInforme] (
    [IdInformeCorporacion] bigint IDENTITY(1,1) NOT NULL,
    [UpdatedOn] datetime  NULL,
    [IdGroupInforme] uniqueidentifier  NULL,
    [ObjetivoDelAporte] nvarchar(600)  NULL,
    [Origen] nvarchar(600)  NULL,
    [Destino] nvarchar(600)  NULL,
    [MontoAportado] bigint  NULL
);
GO

-- Creating table 'Gasto_Ano'
CREATE TABLE [dbo].[Gasto_Ano] (
    [IdAno] bigint IDENTITY(1,1) NOT NULL,
    [IdMunicipalidad] int  NULL,
    [Ano] int  NULL,
    [UpdatedOn] datetime  NULL,
    [Mes] int  NULL
);
GO

-- Creating table 'Gasto_Nivel1'
CREATE TABLE [dbo].[Gasto_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'Gasto_Nivel2'
CREATE TABLE [dbo].[Gasto_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'Gasto_Nivel3'
CREATE TABLE [dbo].[Gasto_Nivel3] (
    [IdNivel3] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel2] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'Gasto_Nivel4'
CREATE TABLE [dbo].[Gasto_Nivel4] (
    [IdNivel4] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel3] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'GastoInforme'
CREATE TABLE [dbo].[GastoInforme] (
    [IdGastoInforme] bigint IDENTITY(1,1) NOT NULL,
    [TIPO] nvarchar(200)  NULL,
    [AREANIVEL1A] nvarchar(200)  NULL,
    [AREANIVEL2] nvarchar(200)  NULL,
    [CUENTANIVEL1] nvarchar(200)  NULL,
    [CUENTANIVEL2] nvarchar(200)  NULL,
    [MontoPresupuestadoAnual] float  NULL,
    [MontoGastado] float  NULL,
    [UpdatedOn] datetime  NULL,
    [IdGroupInformeGasto] uniqueidentifier  NULL
);
GO

-- Creating table 'Ingreso_Ano'
CREATE TABLE [dbo].[Ingreso_Ano] (
    [IdAno] bigint IDENTITY(1,1) NOT NULL,
    [IdMunicipalidad] int  NULL,
    [Ano] int  NULL,
    [UpdatedOn] datetime  NULL,
    [Mes] int  NULL
);
GO

-- Creating table 'Ingreso_Nivel1'
CREATE TABLE [dbo].[Ingreso_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'Ingreso_Nivel2'
CREATE TABLE [dbo].[Ingreso_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'Ingreso_Nivel3'
CREATE TABLE [dbo].[Ingreso_Nivel3] (
    [IdNivel3] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel2] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'Ingreso_Nivel4'
CREATE TABLE [dbo].[Ingreso_Nivel4] (
    [IdNivel4] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel3] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Tipo] nvarchar(10)  NULL,
    [MontoGastado] bigint  NULL,
    [MontoPresupuestado] bigint  NULL,
    [PorcentajeGastado] float  NULL,
    [PorcentajePresupuestado] float  NULL,
    [Descripcion] nvarchar(300)  NULL
);
GO

-- Creating table 'IngresoInforme'
CREATE TABLE [dbo].[IngresoInforme] (
    [IdIngresoInforme] bigint IDENTITY(1,1) NOT NULL,
    [TIPO] nvarchar(200)  NULL,
    [AREANIVEL1A] nvarchar(200)  NULL,
    [AREANIVEL2] nvarchar(200)  NULL,
    [CUENTANIVEL1] nvarchar(200)  NULL,
    [CUENTANIVEL2] nvarchar(200)  NULL,
    [MontoPresupuestadoAnual] float  NULL,
    [MontoGastado] float  NULL,
    [UpdatedOn] datetime  NULL,
    [IdGroupInformeIngreso] uniqueidentifier  NULL
);
GO

-- Creating table 'Municipalidad'
CREATE TABLE [dbo].[Municipalidad] (
    [IdMunicipalidad] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(300)  NULL,
    [Descripcion] nvarchar(1000)  NULL
);
GO

-- Creating table 'Personal_Adm_Nivel1'
CREATE TABLE [dbo].[Personal_Adm_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [CodTipo] nvarchar(30)  NULL
);
GO

-- Creating table 'Personal_Adm_Nivel2'
CREATE TABLE [dbo].[Personal_Adm_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [MontoMujer] bigint  NULL,
    [MontoHombre] bigint  NULL,
    [CantidadMujer] bigint  NULL,
    [CantidadHombre] bigint  NULL
);
GO

-- Creating table 'Personal_AdmInforme'
CREATE TABLE [dbo].[Personal_AdmInforme] (
    [IdInformePersonal] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformePersonal] uniqueidentifier  NULL,
    [GENERO] nvarchar(30)  NULL,
    [EDAD] int  NULL,
    [CALIDADJURIDICA] nvarchar(20)  NULL,
    [PROFESION] nvarchar(100)  NULL,
    [NIVELACADEMICO] nvarchar(100)  NULL,
    [ESTAMENTO] nvarchar(20)  NULL,
    [GRADO] int  NULL,
    [ANTIGUEDAD] nvarchar(3)  NULL,
    [AREA] nvarchar(500)  NULL,
    [SUELDOHABERES] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Personal_Ano'
CREATE TABLE [dbo].[Personal_Ano] (
    [IdAno] bigint IDENTITY(1,1) NOT NULL,
    [IdMunicipalidad] int  NULL,
    [Ano] int  NULL,
    [UpdatedOn] datetime  NULL,
    [Mes] int  NULL
);
GO

-- Creating table 'Personal_Cementerio_Nivel1'
CREATE TABLE [dbo].[Personal_Cementerio_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [CodTipo] nvarchar(30)  NULL
);
GO

-- Creating table 'Personal_Cementerio_Nivel2'
CREATE TABLE [dbo].[Personal_Cementerio_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [MontoMujer] bigint  NULL,
    [MontoHombre] bigint  NULL,
    [CantidadMujer] bigint  NULL,
    [CantidadHombre] bigint  NULL
);
GO

-- Creating table 'Personal_CementerioInforme'
CREATE TABLE [dbo].[Personal_CementerioInforme] (
    [IdInformePersonal] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformePersonal] uniqueidentifier  NULL,
    [GENERO] nvarchar(30)  NULL,
    [EDAD] int  NULL,
    [CALIDADJURIDICA] nvarchar(20)  NULL,
    [PROFESION] nvarchar(100)  NULL,
    [NIVELACADEMICO] nvarchar(100)  NULL,
    [ESTAMENTO] nvarchar(20)  NULL,
    [GRADO] int  NULL,
    [ANTIGUEDAD] nvarchar(3)  NULL,
    [AREA] nvarchar(500)  NULL,
    [SUELDOHABERES] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Personal_Educacion_Nivel1'
CREATE TABLE [dbo].[Personal_Educacion_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [CodTipo] nvarchar(30)  NULL
);
GO

-- Creating table 'Personal_Educacion_Nivel2'
CREATE TABLE [dbo].[Personal_Educacion_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [MontoMujer] bigint  NULL,
    [MontoHombre] bigint  NULL,
    [CantidadMujer] bigint  NULL,
    [CantidadHombre] bigint  NULL
);
GO

-- Creating table 'Personal_EducacionInforme'
CREATE TABLE [dbo].[Personal_EducacionInforme] (
    [IdInformePersonal] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformePersonal] uniqueidentifier  NULL,
    [GENERO] nvarchar(30)  NULL,
    [EDAD] int  NULL,
    [CALIDADJURIDICA] nvarchar(20)  NULL,
    [PROFESION] nvarchar(100)  NULL,
    [NIVELACADEMICO] nvarchar(100)  NULL,
    [ESTAMENTO] nvarchar(20)  NULL,
    [GRADO] int  NULL,
    [ANTIGUEDAD] nvarchar(3)  NULL,
    [AREA] nvarchar(500)  NULL,
    [SUELDOHABERES] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Personal_Salud_Nivel1'
CREATE TABLE [dbo].[Personal_Salud_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [CodTipo] nvarchar(30)  NULL
);
GO

-- Creating table 'Personal_Salud_Nivel2'
CREATE TABLE [dbo].[Personal_Salud_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [MontoMujer] bigint  NULL,
    [MontoHombre] bigint  NULL,
    [CantidadMujer] bigint  NULL,
    [CantidadHombre] bigint  NULL
);
GO

-- Creating table 'Personal_SaludInforme'
CREATE TABLE [dbo].[Personal_SaludInforme] (
    [IdInformePersonal] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformePersonal] uniqueidentifier  NULL,
    [GENERO] nvarchar(30)  NULL,
    [EDAD] int  NULL,
    [CALIDADJURIDICA] nvarchar(20)  NULL,
    [PROFESION] nvarchar(100)  NULL,
    [NIVELACADEMICO] nvarchar(100)  NULL,
    [ESTAMENTO] nvarchar(20)  NULL,
    [GRADO] int  NULL,
    [ANTIGUEDAD] nvarchar(3)  NULL,
    [AREA] nvarchar(500)  NULL,
    [SUELDOHABERES] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Personal_Total_Nivel1'
CREATE TABLE [dbo].[Personal_Total_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [CodTipo] nvarchar(30)  NULL
);
GO

-- Creating table 'Personal_Total_Nivel2'
CREATE TABLE [dbo].[Personal_Total_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [MontoMujer] bigint  NULL,
    [MontoHombre] bigint  NULL,
    [CantidadMujer] bigint  NULL,
    [CantidadHombre] bigint  NULL
);
GO

-- Creating table 'Proveedor_Adm_Nivel1'
CREATE TABLE [dbo].[Proveedor_Adm_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'Proveedor_Adm_Nivel2'
CREATE TABLE [dbo].[Proveedor_Adm_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNIvel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL,
    [Area] nvarchar(50)  NULL,
    [Glosa] nvarchar(1000)  NULL
);
GO

-- Creating table 'Proveedor_AdmInforme'
CREATE TABLE [dbo].[Proveedor_AdmInforme] (
    [IdInformeProveedores] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformeProveedores] uniqueidentifier  NULL,
    [NumeroOrdenCompra] bigint  NULL,
    [Glosa] nvarchar(1000)  NULL,
    [Proveedor] nvarchar(500)  NULL,
    [RUT] nvarchar(20)  NULL,
    [Monto] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Proveedor_Ano'
CREATE TABLE [dbo].[Proveedor_Ano] (
    [IdAno] bigint IDENTITY(1,1) NOT NULL,
    [IdMunicipalidad] int  NULL,
    [Ano] int  NULL,
    [UpdatedOn] datetime  NULL,
    [Mes] int  NULL
);
GO

-- Creating table 'Proveedor_Cementerio_Nivel1'
CREATE TABLE [dbo].[Proveedor_Cementerio_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'Proveedor_Cementerio_Nivel2'
CREATE TABLE [dbo].[Proveedor_Cementerio_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNIvel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL,
    [Area] nvarchar(50)  NULL,
    [Glosa] nvarchar(1000)  NULL
);
GO

-- Creating table 'Proveedor_CementerioInforme'
CREATE TABLE [dbo].[Proveedor_CementerioInforme] (
    [IdInformeProveedores] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformeProveedores] uniqueidentifier  NULL,
    [NumeroOrdenCompra] bigint  NULL,
    [Glosa] nvarchar(1000)  NULL,
    [Proveedor] nvarchar(500)  NULL,
    [RUT] nvarchar(20)  NULL,
    [Monto] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Proveedor_Educacion_Nivel1'
CREATE TABLE [dbo].[Proveedor_Educacion_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'Proveedor_Educacion_Nivel2'
CREATE TABLE [dbo].[Proveedor_Educacion_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNIvel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL,
    [Area] nvarchar(50)  NULL,
    [Glosa] nvarchar(1000)  NULL
);
GO

-- Creating table 'Proveedor_EducacionInforme'
CREATE TABLE [dbo].[Proveedor_EducacionInforme] (
    [IdInformeProveedores] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformeProveedores] uniqueidentifier  NULL,
    [NumeroOrdenCompra] bigint  NULL,
    [Glosa] nvarchar(1000)  NULL,
    [Proveedor] nvarchar(500)  NULL,
    [RUT] nvarchar(20)  NULL,
    [Monto] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Proveedor_Salud_Nivel1'
CREATE TABLE [dbo].[Proveedor_Salud_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'Proveedor_Salud_Nivel2'
CREATE TABLE [dbo].[Proveedor_Salud_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNIvel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL,
    [Area] nvarchar(50)  NULL,
    [Glosa] nvarchar(1000)  NULL
);
GO

-- Creating table 'Proveedor_SaludInforme'
CREATE TABLE [dbo].[Proveedor_SaludInforme] (
    [IdInformeProveedores] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformeProveedores] uniqueidentifier  NULL,
    [NumeroOrdenCompra] bigint  NULL,
    [Glosa] nvarchar(1000)  NULL,
    [Proveedor] nvarchar(500)  NULL,
    [RUT] nvarchar(20)  NULL,
    [Monto] bigint  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- Creating table 'Proveedor_Total_Nivel1'
CREATE TABLE [dbo].[Proveedor_Total_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'Proveedor_Total_Nivel2'
CREATE TABLE [dbo].[Proveedor_Total_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNIvel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL,
    [Area] nvarchar(50)  NULL,
    [Glosa] nvarchar(1000)  NULL
);
GO

-- Creating table 'Subsidio_Ano'
CREATE TABLE [dbo].[Subsidio_Ano] (
    [IdAno] bigint IDENTITY(1,1) NOT NULL,
    [IdMunicipalidad] int  NULL,
    [Ano] int  NULL,
    [UpdatedOn] datetime  NULL,
    [Mes] int  NULL
);
GO

-- Creating table 'Subsidio_Nivel1'
CREATE TABLE [dbo].[Subsidio_Nivel1] (
    [IdNivel1] bigint IDENTITY(1,1) NOT NULL,
    [IdAno] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'Subsidio_Nivel2'
CREATE TABLE [dbo].[Subsidio_Nivel2] (
    [IdNivel2] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel1] bigint  NULL,
    [Nombre] nvarchar(300)  NULL,
    [Monto] bigint  NULL,
    [IdAno] bigint  NULL
);
GO

-- Creating table 'Subsidio_Nivel3'
CREATE TABLE [dbo].[Subsidio_Nivel3] (
    [IdNivel3] bigint IDENTITY(1,1) NOT NULL,
    [IdNivel2] bigint  NULL,
    [Nombre] nvarchar(800)  NULL,
    [Monto] bigint  NULL
);
GO

-- Creating table 'SubsidioInforme'
CREATE TABLE [dbo].[SubsidioInforme] (
    [IdSubsidio] bigint IDENTITY(1,1) NOT NULL,
    [IdGroupInformeSubsidio] uniqueidentifier  NULL,
    [CATEGORIA] nvarchar(300)  NULL,
    [ORGANIZACION] nvarchar(300)  NULL,
    [FECHADECRETO] datetime  NULL,
    [OBJETIVODELAPORTE] nvarchar(600)  NULL,
    [MONTOAPORTE] float  NULL,
    [UpdatedOn] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAno] in table 'Corporacion_Ano'
ALTER TABLE [dbo].[Corporacion_Ano]
ADD CONSTRAINT [PK_Corporacion_Ano]
    PRIMARY KEY CLUSTERED ([IdAno] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Corporacion_Nivel1'
ALTER TABLE [dbo].[Corporacion_Nivel1]
ADD CONSTRAINT [PK_Corporacion_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdInformeCorporacion] in table 'CorporacionInforme'
ALTER TABLE [dbo].[CorporacionInforme]
ADD CONSTRAINT [PK_CorporacionInforme]
    PRIMARY KEY CLUSTERED ([IdInformeCorporacion] ASC);
GO

-- Creating primary key on [IdAno] in table 'Gasto_Ano'
ALTER TABLE [dbo].[Gasto_Ano]
ADD CONSTRAINT [PK_Gasto_Ano]
    PRIMARY KEY CLUSTERED ([IdAno] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Gasto_Nivel1'
ALTER TABLE [dbo].[Gasto_Nivel1]
ADD CONSTRAINT [PK_Gasto_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Gasto_Nivel2'
ALTER TABLE [dbo].[Gasto_Nivel2]
ADD CONSTRAINT [PK_Gasto_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdNivel3] in table 'Gasto_Nivel3'
ALTER TABLE [dbo].[Gasto_Nivel3]
ADD CONSTRAINT [PK_Gasto_Nivel3]
    PRIMARY KEY CLUSTERED ([IdNivel3] ASC);
GO

-- Creating primary key on [IdNivel4] in table 'Gasto_Nivel4'
ALTER TABLE [dbo].[Gasto_Nivel4]
ADD CONSTRAINT [PK_Gasto_Nivel4]
    PRIMARY KEY CLUSTERED ([IdNivel4] ASC);
GO

-- Creating primary key on [IdGastoInforme] in table 'GastoInforme'
ALTER TABLE [dbo].[GastoInforme]
ADD CONSTRAINT [PK_GastoInforme]
    PRIMARY KEY CLUSTERED ([IdGastoInforme] ASC);
GO

-- Creating primary key on [IdAno] in table 'Ingreso_Ano'
ALTER TABLE [dbo].[Ingreso_Ano]
ADD CONSTRAINT [PK_Ingreso_Ano]
    PRIMARY KEY CLUSTERED ([IdAno] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Ingreso_Nivel1'
ALTER TABLE [dbo].[Ingreso_Nivel1]
ADD CONSTRAINT [PK_Ingreso_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Ingreso_Nivel2'
ALTER TABLE [dbo].[Ingreso_Nivel2]
ADD CONSTRAINT [PK_Ingreso_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdNivel3] in table 'Ingreso_Nivel3'
ALTER TABLE [dbo].[Ingreso_Nivel3]
ADD CONSTRAINT [PK_Ingreso_Nivel3]
    PRIMARY KEY CLUSTERED ([IdNivel3] ASC);
GO

-- Creating primary key on [IdNivel4] in table 'Ingreso_Nivel4'
ALTER TABLE [dbo].[Ingreso_Nivel4]
ADD CONSTRAINT [PK_Ingreso_Nivel4]
    PRIMARY KEY CLUSTERED ([IdNivel4] ASC);
GO

-- Creating primary key on [IdIngresoInforme] in table 'IngresoInforme'
ALTER TABLE [dbo].[IngresoInforme]
ADD CONSTRAINT [PK_IngresoInforme]
    PRIMARY KEY CLUSTERED ([IdIngresoInforme] ASC);
GO

-- Creating primary key on [IdMunicipalidad] in table 'Municipalidad'
ALTER TABLE [dbo].[Municipalidad]
ADD CONSTRAINT [PK_Municipalidad]
    PRIMARY KEY CLUSTERED ([IdMunicipalidad] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Personal_Adm_Nivel1'
ALTER TABLE [dbo].[Personal_Adm_Nivel1]
ADD CONSTRAINT [PK_Personal_Adm_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Personal_Adm_Nivel2'
ALTER TABLE [dbo].[Personal_Adm_Nivel2]
ADD CONSTRAINT [PK_Personal_Adm_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformePersonal] in table 'Personal_AdmInforme'
ALTER TABLE [dbo].[Personal_AdmInforme]
ADD CONSTRAINT [PK_Personal_AdmInforme]
    PRIMARY KEY CLUSTERED ([IdInformePersonal] ASC);
GO

-- Creating primary key on [IdAno] in table 'Personal_Ano'
ALTER TABLE [dbo].[Personal_Ano]
ADD CONSTRAINT [PK_Personal_Ano]
    PRIMARY KEY CLUSTERED ([IdAno] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Personal_Cementerio_Nivel1'
ALTER TABLE [dbo].[Personal_Cementerio_Nivel1]
ADD CONSTRAINT [PK_Personal_Cementerio_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Personal_Cementerio_Nivel2'
ALTER TABLE [dbo].[Personal_Cementerio_Nivel2]
ADD CONSTRAINT [PK_Personal_Cementerio_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformePersonal] in table 'Personal_CementerioInforme'
ALTER TABLE [dbo].[Personal_CementerioInforme]
ADD CONSTRAINT [PK_Personal_CementerioInforme]
    PRIMARY KEY CLUSTERED ([IdInformePersonal] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Personal_Educacion_Nivel1'
ALTER TABLE [dbo].[Personal_Educacion_Nivel1]
ADD CONSTRAINT [PK_Personal_Educacion_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Personal_Educacion_Nivel2'
ALTER TABLE [dbo].[Personal_Educacion_Nivel2]
ADD CONSTRAINT [PK_Personal_Educacion_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformePersonal] in table 'Personal_EducacionInforme'
ALTER TABLE [dbo].[Personal_EducacionInforme]
ADD CONSTRAINT [PK_Personal_EducacionInforme]
    PRIMARY KEY CLUSTERED ([IdInformePersonal] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Personal_Salud_Nivel1'
ALTER TABLE [dbo].[Personal_Salud_Nivel1]
ADD CONSTRAINT [PK_Personal_Salud_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Personal_Salud_Nivel2'
ALTER TABLE [dbo].[Personal_Salud_Nivel2]
ADD CONSTRAINT [PK_Personal_Salud_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformePersonal] in table 'Personal_SaludInforme'
ALTER TABLE [dbo].[Personal_SaludInforme]
ADD CONSTRAINT [PK_Personal_SaludInforme]
    PRIMARY KEY CLUSTERED ([IdInformePersonal] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Personal_Total_Nivel1'
ALTER TABLE [dbo].[Personal_Total_Nivel1]
ADD CONSTRAINT [PK_Personal_Total_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Personal_Total_Nivel2'
ALTER TABLE [dbo].[Personal_Total_Nivel2]
ADD CONSTRAINT [PK_Personal_Total_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Proveedor_Adm_Nivel1'
ALTER TABLE [dbo].[Proveedor_Adm_Nivel1]
ADD CONSTRAINT [PK_Proveedor_Adm_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Proveedor_Adm_Nivel2'
ALTER TABLE [dbo].[Proveedor_Adm_Nivel2]
ADD CONSTRAINT [PK_Proveedor_Adm_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformeProveedores] in table 'Proveedor_AdmInforme'
ALTER TABLE [dbo].[Proveedor_AdmInforme]
ADD CONSTRAINT [PK_Proveedor_AdmInforme]
    PRIMARY KEY CLUSTERED ([IdInformeProveedores] ASC);
GO

-- Creating primary key on [IdAno] in table 'Proveedor_Ano'
ALTER TABLE [dbo].[Proveedor_Ano]
ADD CONSTRAINT [PK_Proveedor_Ano]
    PRIMARY KEY CLUSTERED ([IdAno] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Proveedor_Cementerio_Nivel1'
ALTER TABLE [dbo].[Proveedor_Cementerio_Nivel1]
ADD CONSTRAINT [PK_Proveedor_Cementerio_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Proveedor_Cementerio_Nivel2'
ALTER TABLE [dbo].[Proveedor_Cementerio_Nivel2]
ADD CONSTRAINT [PK_Proveedor_Cementerio_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformeProveedores] in table 'Proveedor_CementerioInforme'
ALTER TABLE [dbo].[Proveedor_CementerioInforme]
ADD CONSTRAINT [PK_Proveedor_CementerioInforme]
    PRIMARY KEY CLUSTERED ([IdInformeProveedores] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Proveedor_Educacion_Nivel1'
ALTER TABLE [dbo].[Proveedor_Educacion_Nivel1]
ADD CONSTRAINT [PK_Proveedor_Educacion_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Proveedor_Educacion_Nivel2'
ALTER TABLE [dbo].[Proveedor_Educacion_Nivel2]
ADD CONSTRAINT [PK_Proveedor_Educacion_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformeProveedores] in table 'Proveedor_EducacionInforme'
ALTER TABLE [dbo].[Proveedor_EducacionInforme]
ADD CONSTRAINT [PK_Proveedor_EducacionInforme]
    PRIMARY KEY CLUSTERED ([IdInformeProveedores] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Proveedor_Salud_Nivel1'
ALTER TABLE [dbo].[Proveedor_Salud_Nivel1]
ADD CONSTRAINT [PK_Proveedor_Salud_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Proveedor_Salud_Nivel2'
ALTER TABLE [dbo].[Proveedor_Salud_Nivel2]
ADD CONSTRAINT [PK_Proveedor_Salud_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdInformeProveedores] in table 'Proveedor_SaludInforme'
ALTER TABLE [dbo].[Proveedor_SaludInforme]
ADD CONSTRAINT [PK_Proveedor_SaludInforme]
    PRIMARY KEY CLUSTERED ([IdInformeProveedores] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Proveedor_Total_Nivel1'
ALTER TABLE [dbo].[Proveedor_Total_Nivel1]
ADD CONSTRAINT [PK_Proveedor_Total_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Proveedor_Total_Nivel2'
ALTER TABLE [dbo].[Proveedor_Total_Nivel2]
ADD CONSTRAINT [PK_Proveedor_Total_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdAno] in table 'Subsidio_Ano'
ALTER TABLE [dbo].[Subsidio_Ano]
ADD CONSTRAINT [PK_Subsidio_Ano]
    PRIMARY KEY CLUSTERED ([IdAno] ASC);
GO

-- Creating primary key on [IdNivel1] in table 'Subsidio_Nivel1'
ALTER TABLE [dbo].[Subsidio_Nivel1]
ADD CONSTRAINT [PK_Subsidio_Nivel1]
    PRIMARY KEY CLUSTERED ([IdNivel1] ASC);
GO

-- Creating primary key on [IdNivel2] in table 'Subsidio_Nivel2'
ALTER TABLE [dbo].[Subsidio_Nivel2]
ADD CONSTRAINT [PK_Subsidio_Nivel2]
    PRIMARY KEY CLUSTERED ([IdNivel2] ASC);
GO

-- Creating primary key on [IdNivel3] in table 'Subsidio_Nivel3'
ALTER TABLE [dbo].[Subsidio_Nivel3]
ADD CONSTRAINT [PK_Subsidio_Nivel3]
    PRIMARY KEY CLUSTERED ([IdNivel3] ASC);
GO

-- Creating primary key on [IdSubsidio] in table 'SubsidioInforme'
ALTER TABLE [dbo].[SubsidioInforme]
ADD CONSTRAINT [PK_SubsidioInforme]
    PRIMARY KEY CLUSTERED ([IdSubsidio] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAno] in table 'Corporacion_Nivel1'
ALTER TABLE [dbo].[Corporacion_Nivel1]
ADD CONSTRAINT [FK__Corporaci__IdAno__71D1E811]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Corporacion_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Corporaci__IdAno__71D1E811'
CREATE INDEX [IX_FK__Corporaci__IdAno__71D1E811]
ON [dbo].[Corporacion_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdMunicipalidad] in table 'Corporacion_Ano'
ALTER TABLE [dbo].[Corporacion_Ano]
ADD CONSTRAINT [FK__Corporaci__IdMun__70DDC3D8]
    FOREIGN KEY ([IdMunicipalidad])
    REFERENCES [dbo].[Municipalidad]
        ([IdMunicipalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Corporaci__IdMun__70DDC3D8'
CREATE INDEX [IX_FK__Corporaci__IdMun__70DDC3D8]
ON [dbo].[Corporacion_Ano]
    ([IdMunicipalidad]);
GO

-- Creating foreign key on [IdMunicipalidad] in table 'Gasto_Ano'
ALTER TABLE [dbo].[Gasto_Ano]
ADD CONSTRAINT [FK__Gasto_Ano__IdMun__72C60C4A]
    FOREIGN KEY ([IdMunicipalidad])
    REFERENCES [dbo].[Municipalidad]
        ([IdMunicipalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Gasto_Ano__IdMun__72C60C4A'
CREATE INDEX [IX_FK__Gasto_Ano__IdMun__72C60C4A]
ON [dbo].[Gasto_Ano]
    ([IdMunicipalidad]);
GO

-- Creating foreign key on [IdAno] in table 'Gasto_Nivel1'
ALTER TABLE [dbo].[Gasto_Nivel1]
ADD CONSTRAINT [FK__Gasto_Niv__IdAno__73BA3083]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Gasto_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Gasto_Niv__IdAno__73BA3083'
CREATE INDEX [IX_FK__Gasto_Niv__IdAno__73BA3083]
ON [dbo].[Gasto_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdNivel1] in table 'Gasto_Nivel2'
ALTER TABLE [dbo].[Gasto_Nivel2]
ADD CONSTRAINT [FK__Gasto_Niv__IdNiv__74AE54BC]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Gasto_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Gasto_Niv__IdNiv__74AE54BC'
CREATE INDEX [IX_FK__Gasto_Niv__IdNiv__74AE54BC]
ON [dbo].[Gasto_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdNivel2] in table 'Gasto_Nivel3'
ALTER TABLE [dbo].[Gasto_Nivel3]
ADD CONSTRAINT [FK__Gasto_Niv__IdNiv__75A278F5]
    FOREIGN KEY ([IdNivel2])
    REFERENCES [dbo].[Gasto_Nivel2]
        ([IdNivel2])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Gasto_Niv__IdNiv__75A278F5'
CREATE INDEX [IX_FK__Gasto_Niv__IdNiv__75A278F5]
ON [dbo].[Gasto_Nivel3]
    ([IdNivel2]);
GO

-- Creating foreign key on [IdNivel3] in table 'Gasto_Nivel4'
ALTER TABLE [dbo].[Gasto_Nivel4]
ADD CONSTRAINT [FK__Gasto_Niv__IdNiv__76969D2E]
    FOREIGN KEY ([IdNivel3])
    REFERENCES [dbo].[Gasto_Nivel3]
        ([IdNivel3])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Gasto_Niv__IdNiv__76969D2E'
CREATE INDEX [IX_FK__Gasto_Niv__IdNiv__76969D2E]
ON [dbo].[Gasto_Nivel4]
    ([IdNivel3]);
GO

-- Creating foreign key on [IdMunicipalidad] in table 'Ingreso_Ano'
ALTER TABLE [dbo].[Ingreso_Ano]
ADD CONSTRAINT [FK__Ingreso_A__IdMun__778AC167]
    FOREIGN KEY ([IdMunicipalidad])
    REFERENCES [dbo].[Municipalidad]
        ([IdMunicipalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ingreso_A__IdMun__778AC167'
CREATE INDEX [IX_FK__Ingreso_A__IdMun__778AC167]
ON [dbo].[Ingreso_Ano]
    ([IdMunicipalidad]);
GO

-- Creating foreign key on [IdAno] in table 'Ingreso_Nivel1'
ALTER TABLE [dbo].[Ingreso_Nivel1]
ADD CONSTRAINT [FK__Ingreso_N__IdAno__787EE5A0]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Ingreso_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ingreso_N__IdAno__787EE5A0'
CREATE INDEX [IX_FK__Ingreso_N__IdAno__787EE5A0]
ON [dbo].[Ingreso_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdNivel1] in table 'Ingreso_Nivel2'
ALTER TABLE [dbo].[Ingreso_Nivel2]
ADD CONSTRAINT [FK__Ingreso_N__IdNiv__797309D9]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Ingreso_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ingreso_N__IdNiv__797309D9'
CREATE INDEX [IX_FK__Ingreso_N__IdNiv__797309D9]
ON [dbo].[Ingreso_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdNivel2] in table 'Ingreso_Nivel3'
ALTER TABLE [dbo].[Ingreso_Nivel3]
ADD CONSTRAINT [FK__Ingreso_N__IdNiv__7A672E12]
    FOREIGN KEY ([IdNivel2])
    REFERENCES [dbo].[Ingreso_Nivel2]
        ([IdNivel2])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ingreso_N__IdNiv__7A672E12'
CREATE INDEX [IX_FK__Ingreso_N__IdNiv__7A672E12]
ON [dbo].[Ingreso_Nivel3]
    ([IdNivel2]);
GO

-- Creating foreign key on [IdNivel3] in table 'Ingreso_Nivel4'
ALTER TABLE [dbo].[Ingreso_Nivel4]
ADD CONSTRAINT [FK__Ingreso_N__IdNiv__7B5B524B]
    FOREIGN KEY ([IdNivel3])
    REFERENCES [dbo].[Ingreso_Nivel3]
        ([IdNivel3])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ingreso_N__IdNiv__7B5B524B'
CREATE INDEX [IX_FK__Ingreso_N__IdNiv__7B5B524B]
ON [dbo].[Ingreso_Nivel4]
    ([IdNivel3]);
GO

-- Creating foreign key on [IdMunicipalidad] in table 'Personal_Ano'
ALTER TABLE [dbo].[Personal_Ano]
ADD CONSTRAINT [FK__Personal___IdMun__7E37BEF6]
    FOREIGN KEY ([IdMunicipalidad])
    REFERENCES [dbo].[Municipalidad]
        ([IdMunicipalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdMun__7E37BEF6'
CREATE INDEX [IX_FK__Personal___IdMun__7E37BEF6]
ON [dbo].[Personal_Ano]
    ([IdMunicipalidad]);
GO

-- Creating foreign key on [IdMunicipalidad] in table 'Proveedor_Ano'
ALTER TABLE [dbo].[Proveedor_Ano]
ADD CONSTRAINT [FK__Proveedor__IdMun__08B54D69]
    FOREIGN KEY ([IdMunicipalidad])
    REFERENCES [dbo].[Municipalidad]
        ([IdMunicipalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdMun__08B54D69'
CREATE INDEX [IX_FK__Proveedor__IdMun__08B54D69]
ON [dbo].[Proveedor_Ano]
    ([IdMunicipalidad]);
GO

-- Creating foreign key on [IdMunicipalidad] in table 'Subsidio_Ano'
ALTER TABLE [dbo].[Subsidio_Ano]
ADD CONSTRAINT [FK__Subsidio___IdMun__114A936A]
    FOREIGN KEY ([IdMunicipalidad])
    REFERENCES [dbo].[Municipalidad]
        ([IdMunicipalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Subsidio___IdMun__114A936A'
CREATE INDEX [IX_FK__Subsidio___IdMun__114A936A]
ON [dbo].[Subsidio_Ano]
    ([IdMunicipalidad]);
GO

-- Creating foreign key on [IdAno] in table 'Personal_Adm_Nivel1'
ALTER TABLE [dbo].[Personal_Adm_Nivel1]
ADD CONSTRAINT [FK__Personal___IdAno__7C4F7684]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Personal_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdAno__7C4F7684'
CREATE INDEX [IX_FK__Personal___IdAno__7C4F7684]
ON [dbo].[Personal_Adm_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdNivel1] in table 'Personal_Adm_Nivel2'
ALTER TABLE [dbo].[Personal_Adm_Nivel2]
ADD CONSTRAINT [FK__Personal___IdNiv__7D439ABD]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Personal_Adm_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdNiv__7D439ABD'
CREATE INDEX [IX_FK__Personal___IdNiv__7D439ABD]
ON [dbo].[Personal_Adm_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdAno] in table 'Personal_Educacion_Nivel1'
ALTER TABLE [dbo].[Personal_Educacion_Nivel1]
ADD CONSTRAINT [FK__Personal___IdAno__01142BA1]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Personal_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdAno__01142BA1'
CREATE INDEX [IX_FK__Personal___IdAno__01142BA1]
ON [dbo].[Personal_Educacion_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Personal_Salud_Nivel1'
ALTER TABLE [dbo].[Personal_Salud_Nivel1]
ADD CONSTRAINT [FK__Personal___IdAno__02FC7413]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Personal_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdAno__02FC7413'
CREATE INDEX [IX_FK__Personal___IdAno__02FC7413]
ON [dbo].[Personal_Salud_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Personal_Total_Nivel1'
ALTER TABLE [dbo].[Personal_Total_Nivel1]
ADD CONSTRAINT [FK__Personal___IdAno__04E4BC85]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Personal_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdAno__04E4BC85'
CREATE INDEX [IX_FK__Personal___IdAno__04E4BC85]
ON [dbo].[Personal_Total_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Personal_Cementerio_Nivel1'
ALTER TABLE [dbo].[Personal_Cementerio_Nivel1]
ADD CONSTRAINT [FK__Personal___IdAno__7F2BE32F]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Personal_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdAno__7F2BE32F'
CREATE INDEX [IX_FK__Personal___IdAno__7F2BE32F]
ON [dbo].[Personal_Cementerio_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdNivel1] in table 'Personal_Cementerio_Nivel2'
ALTER TABLE [dbo].[Personal_Cementerio_Nivel2]
ADD CONSTRAINT [FK__Personal___IdNiv__00200768]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Personal_Cementerio_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdNiv__00200768'
CREATE INDEX [IX_FK__Personal___IdNiv__00200768]
ON [dbo].[Personal_Cementerio_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdNivel1] in table 'Personal_Educacion_Nivel2'
ALTER TABLE [dbo].[Personal_Educacion_Nivel2]
ADD CONSTRAINT [FK__Personal___IdNiv__02084FDA]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Personal_Educacion_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdNiv__02084FDA'
CREATE INDEX [IX_FK__Personal___IdNiv__02084FDA]
ON [dbo].[Personal_Educacion_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdNivel1] in table 'Personal_Salud_Nivel2'
ALTER TABLE [dbo].[Personal_Salud_Nivel2]
ADD CONSTRAINT [FK__Personal___IdNiv__03F0984C]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Personal_Salud_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdNiv__03F0984C'
CREATE INDEX [IX_FK__Personal___IdNiv__03F0984C]
ON [dbo].[Personal_Salud_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdNivel1] in table 'Personal_Total_Nivel2'
ALTER TABLE [dbo].[Personal_Total_Nivel2]
ADD CONSTRAINT [FK__Personal___IdNiv__05D8E0BE]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Personal_Total_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Personal___IdNiv__05D8E0BE'
CREATE INDEX [IX_FK__Personal___IdNiv__05D8E0BE]
ON [dbo].[Personal_Total_Nivel2]
    ([IdNivel1]);
GO

-- Creating foreign key on [IdAno] in table 'Proveedor_Adm_Nivel1'
ALTER TABLE [dbo].[Proveedor_Adm_Nivel1]
ADD CONSTRAINT [FK__Proveedor__IdAno__06CD04F7]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Proveedor_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdAno__06CD04F7'
CREATE INDEX [IX_FK__Proveedor__IdAno__06CD04F7]
ON [dbo].[Proveedor_Adm_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdNIvel1] in table 'Proveedor_Adm_Nivel2'
ALTER TABLE [dbo].[Proveedor_Adm_Nivel2]
ADD CONSTRAINT [FK__Proveedor__IdNIv__07C12930]
    FOREIGN KEY ([IdNIvel1])
    REFERENCES [dbo].[Proveedor_Adm_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdNIv__07C12930'
CREATE INDEX [IX_FK__Proveedor__IdNIv__07C12930]
ON [dbo].[Proveedor_Adm_Nivel2]
    ([IdNIvel1]);
GO

-- Creating foreign key on [IdAno] in table 'Proveedor_Cementerio_Nivel1'
ALTER TABLE [dbo].[Proveedor_Cementerio_Nivel1]
ADD CONSTRAINT [FK__Proveedor__IdAno__09A971A2]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Proveedor_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdAno__09A971A2'
CREATE INDEX [IX_FK__Proveedor__IdAno__09A971A2]
ON [dbo].[Proveedor_Cementerio_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Proveedor_Educacion_Nivel1'
ALTER TABLE [dbo].[Proveedor_Educacion_Nivel1]
ADD CONSTRAINT [FK__Proveedor__IdAno__0B91BA14]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Proveedor_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdAno__0B91BA14'
CREATE INDEX [IX_FK__Proveedor__IdAno__0B91BA14]
ON [dbo].[Proveedor_Educacion_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Proveedor_Salud_Nivel1'
ALTER TABLE [dbo].[Proveedor_Salud_Nivel1]
ADD CONSTRAINT [FK__Proveedor__IdAno__0D7A0286]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Proveedor_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdAno__0D7A0286'
CREATE INDEX [IX_FK__Proveedor__IdAno__0D7A0286]
ON [dbo].[Proveedor_Salud_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Proveedor_Total_Nivel1'
ALTER TABLE [dbo].[Proveedor_Total_Nivel1]
ADD CONSTRAINT [FK__Proveedor__IdAno__0F624AF8]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Proveedor_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdAno__0F624AF8'
CREATE INDEX [IX_FK__Proveedor__IdAno__0F624AF8]
ON [dbo].[Proveedor_Total_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdNIvel1] in table 'Proveedor_Cementerio_Nivel2'
ALTER TABLE [dbo].[Proveedor_Cementerio_Nivel2]
ADD CONSTRAINT [FK__Proveedor__IdNIv__0A9D95DB]
    FOREIGN KEY ([IdNIvel1])
    REFERENCES [dbo].[Proveedor_Cementerio_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdNIv__0A9D95DB'
CREATE INDEX [IX_FK__Proveedor__IdNIv__0A9D95DB]
ON [dbo].[Proveedor_Cementerio_Nivel2]
    ([IdNIvel1]);
GO

-- Creating foreign key on [IdNIvel1] in table 'Proveedor_Educacion_Nivel2'
ALTER TABLE [dbo].[Proveedor_Educacion_Nivel2]
ADD CONSTRAINT [FK__Proveedor__IdNIv__0C85DE4D]
    FOREIGN KEY ([IdNIvel1])
    REFERENCES [dbo].[Proveedor_Educacion_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdNIv__0C85DE4D'
CREATE INDEX [IX_FK__Proveedor__IdNIv__0C85DE4D]
ON [dbo].[Proveedor_Educacion_Nivel2]
    ([IdNIvel1]);
GO

-- Creating foreign key on [IdNIvel1] in table 'Proveedor_Salud_Nivel2'
ALTER TABLE [dbo].[Proveedor_Salud_Nivel2]
ADD CONSTRAINT [FK__Proveedor__IdNIv__0E6E26BF]
    FOREIGN KEY ([IdNIvel1])
    REFERENCES [dbo].[Proveedor_Salud_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdNIv__0E6E26BF'
CREATE INDEX [IX_FK__Proveedor__IdNIv__0E6E26BF]
ON [dbo].[Proveedor_Salud_Nivel2]
    ([IdNIvel1]);
GO

-- Creating foreign key on [IdNIvel1] in table 'Proveedor_Total_Nivel2'
ALTER TABLE [dbo].[Proveedor_Total_Nivel2]
ADD CONSTRAINT [FK__Proveedor__IdNIv__10566F31]
    FOREIGN KEY ([IdNIvel1])
    REFERENCES [dbo].[Proveedor_Total_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Proveedor__IdNIv__10566F31'
CREATE INDEX [IX_FK__Proveedor__IdNIv__10566F31]
ON [dbo].[Proveedor_Total_Nivel2]
    ([IdNIvel1]);
GO

-- Creating foreign key on [IdAno] in table 'Subsidio_Nivel1'
ALTER TABLE [dbo].[Subsidio_Nivel1]
ADD CONSTRAINT [FK__Subsidio___IdAno__123EB7A3]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Subsidio_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Subsidio___IdAno__123EB7A3'
CREATE INDEX [IX_FK__Subsidio___IdAno__123EB7A3]
ON [dbo].[Subsidio_Nivel1]
    ([IdAno]);
GO

-- Creating foreign key on [IdAno] in table 'Subsidio_Nivel2'
ALTER TABLE [dbo].[Subsidio_Nivel2]
ADD CONSTRAINT [FK__Subsidio___IdAno__1332DBDC]
    FOREIGN KEY ([IdAno])
    REFERENCES [dbo].[Subsidio_Ano]
        ([IdAno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Subsidio___IdAno__1332DBDC'
CREATE INDEX [IX_FK__Subsidio___IdAno__1332DBDC]
ON [dbo].[Subsidio_Nivel2]
    ([IdAno]);
GO

-- Creating foreign key on [IdNivel1] in table 'Subsidio_Nivel2'
ALTER TABLE [dbo].[Subsidio_Nivel2]
ADD CONSTRAINT [FK__Subsidio___IdNiv__14270015]
    FOREIGN KEY ([IdNivel1])
    REFERENCES [dbo].[Subsidio_Nivel1]
        ([IdNivel1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Subsidio___IdNiv__14270015'
CREATE INDEX [IX_FK__Subsidio___IdNiv__14270015]
ON [dbo].[Subsidio_Nivel2]
    ([IdNivel1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------