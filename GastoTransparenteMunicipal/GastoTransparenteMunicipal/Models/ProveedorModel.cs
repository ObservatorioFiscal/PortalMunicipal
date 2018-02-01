using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Newtonsoft.Json;
using AutoMapper;

namespace GastoTransparenteMunicipal.Models
{
    public class ProveedorModel
    {
        public string JsonProveedor { get; set; }
        public List<Proveedor_Nivel1> Proveedor_Nivel1 { get; set; }
        public List<Proveedor_Nivel2> Proveedor_Nivel2 { get; set; }

        public ProveedorModel()
        {
            this.JsonProveedor = string.Empty;
            this.Proveedor_Nivel1 = new List<Core.Proveedor_Nivel1>();
            this.Proveedor_Nivel2 = new List<Core.Proveedor_Nivel2>();
        }

        public void Init(GastoTransparenteMunicipalEntities db, int takeElements, int idMunicipality)
        {
            var proveedor_Ano = db.Proveedor_Ano.Where(r => r.IdMunicipalidad == idMunicipality).OrderByDescending(r => r.Ano).First();

            LoadNivel1(db, proveedor_Ano, OrigenData.MunicipioTotal, 20);
            LoadNivel2(db, proveedor_Ano, OrigenData.MunicipioTotal, 20);
            LoadJsonNivel1();
        }

        public void WordCloud(GastoTransparenteMunicipalEntities db, int takeElements, int idMunicipality, int year, int origenData)
        {
            var proveedor_Ano = db.Proveedor_Ano.Where(r => r.IdMunicipalidad == idMunicipality && r.Ano == year).First();

            LoadNivel1(db, proveedor_Ano, OrigenData.MunicipioTotal, takeElements);
            LoadNivel2(db, proveedor_Ano, OrigenData.MunicipioTotal, takeElements);

            LoadNivel1(db, proveedor_Ano, OrigenData.MunicipioTotal, takeElements);
            LoadNivel2(db, proveedor_Ano, OrigenData.MunicipioTotal, takeElements);

            LoadJsonNivel1();
        }

        private List<Proveedor_Nivel1> LoadNivel1(GastoTransparenteMunicipalEntities db, Proveedor_Ano proveedor_Ano, int origenData, int takeElements)
        {
            object nivel1;
            switch (origenData)
            {
                case OrigenData.Adm:
                    nivel1 = db.Proveedor_Adm_Nivel1.Where(r => r.IdAno == proveedor_Ano.IdAno).OrderByDescending(r => r.Monto).Take(takeElements).ToList();
                    Mapper.Map((List<Proveedor_Adm_Nivel1>)nivel1, this.Proveedor_Nivel1);
                    return this.Proveedor_Nivel1;

                case OrigenData.Educacion:
                    nivel1 = db.Proveedor_Educacion_Nivel1.Where(r => r.IdAno == proveedor_Ano.IdAno).OrderByDescending(r => r.Monto).Take(takeElements).ToList();
                    Mapper.Map((List<Proveedor_Educacion_Nivel1>)nivel1, this.Proveedor_Nivel1);
                    return this.Proveedor_Nivel1;

                case OrigenData.Salud:
                    nivel1 = db.Proveedor_Salud_Nivel1.Where(r => r.IdAno == proveedor_Ano.IdAno).OrderByDescending(r => r.Monto).Take(takeElements).ToList();
                    Mapper.Map((List<Proveedor_Salud_Nivel1>)nivel1, this.Proveedor_Nivel1);
                    return this.Proveedor_Nivel1;

                case OrigenData.Cementerio:
                    nivel1 = db.Proveedor_Cementerio_Nivel1.Where(r => r.IdAno == proveedor_Ano.IdAno).OrderByDescending(r => r.Monto).Take(takeElements).ToList();
                    Mapper.Map((List<Proveedor_Cementerio_Nivel1>)nivel1, this.Proveedor_Nivel1);
                    return this.Proveedor_Nivel1;

                case OrigenData.MunicipioTotal:
                    nivel1 = db.Proveedor_Total_Nivel1.Where(r => r.IdAno == proveedor_Ano.IdAno).OrderByDescending(r => r.Monto).Take(takeElements).ToList();

                    Mapper.Map((List<Proveedor_Total_Nivel1>)nivel1, this.Proveedor_Nivel1);
                    return this.Proveedor_Nivel1;

                default:
                    nivel1 = db.Proveedor_Total_Nivel1.Where(r => r.IdAno == proveedor_Ano.IdAno).OrderByDescending(r => r.Monto).Take(takeElements).ToList();
                    Mapper.Map((List<Proveedor_Total_Nivel1>)nivel1, this.Proveedor_Nivel1);
                    return this.Proveedor_Nivel1;
            }
        }

        private List<Proveedor_Nivel2> LoadNivel2(GastoTransparenteMunicipalEntities db, Proveedor_Ano proveedor_Ano, int origenData, int takeElements)
        {
            switch (origenData)
            {
                case OrigenData.Adm:
                    foreach (var item in this.Proveedor_Nivel1)
                    {
                        var nivel2 = db.Proveedor_Adm_Nivel2.Where(r => r.IdNIvel1 == item.IdNivel1).OrderByDescending(r => r.Monto).ToList();
                        Mapper.Map(nivel2, this.Proveedor_Nivel2);
                    }
                    return this.Proveedor_Nivel2;

                case OrigenData.Educacion:
                    foreach (var item in this.Proveedor_Nivel1)
                    {
                        var nivel2 = db.Proveedor_Educacion_Nivel2.Where(r => r.IdNIvel1 == item.IdNivel1).OrderByDescending(r => r.Monto).ToList();
                        Mapper.Map(nivel2, this.Proveedor_Nivel2);
                    }
                    return this.Proveedor_Nivel2;

                case OrigenData.Salud:
                    foreach (var item in this.Proveedor_Nivel1)
                    {
                        var nivel2 = db.Proveedor_Salud_Nivel2.Where(r => r.IdNIvel1 == item.IdNivel1).OrderByDescending(r => r.Monto).ToList();
                        Mapper.Map(nivel2, this.Proveedor_Nivel2);
                    }
                    return this.Proveedor_Nivel2;

                case OrigenData.Cementerio:
                    foreach (var item in this.Proveedor_Nivel1)
                    {
                        var nivel2 = db.Proveedor_Cementerio_Nivel2.Where(r => r.IdNIvel1 == item.IdNivel1).OrderByDescending(r => r.Monto).ToList();
                        Mapper.Map(nivel2, this.Proveedor_Nivel2);
                    }
                    return this.Proveedor_Nivel2;

                case OrigenData.MunicipioTotal:
                    foreach (var item in this.Proveedor_Nivel1)
                    {
                        var nivel2 = db.Proveedor_Total_Nivel2.Where(r => r.IdNIvel1 == item.IdNivel1).OrderByDescending(r => r.Monto).ToList();
                        Mapper.Map(nivel2, this.Proveedor_Nivel2);
                    }
                    return this.Proveedor_Nivel2;

                default:
                    foreach (var item in this.Proveedor_Nivel1)
                    {
                        var nivel2 = db.Proveedor_Total_Nivel2.Where(r => r.IdNIvel1 == item.IdNivel1).OrderByDescending(r => r.Monto).ToList();
                        Mapper.Map(nivel2, this.Proveedor_Nivel2);
                    }
                    return this.Proveedor_Nivel2;
            }
        }

        private void LoadJsonNivel1()
        {
            var jsonProveedor = this.Proveedor_Nivel1.Select(r => r.Nombre);
            var jsonMonto = this.Proveedor_Nivel1.Select(r => r.Monto);

            var proveedor = new
            {
                proveedor = jsonProveedor,
                monto = jsonMonto
            };

            this.JsonProveedor = JsonConvert.SerializeObject(proveedor);

        }
    }
}