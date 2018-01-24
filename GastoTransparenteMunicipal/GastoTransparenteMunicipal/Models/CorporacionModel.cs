using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using AutoMapper;

namespace GastoTransparenteMunicipal.Models
{
    public class CorporacionModel
    {
        List<Corporacion_N1> Corporacion_Nivel3 { get; set; }

        public CorporacionModel()
        {
            this.Corporacion_Nivel3 = new List<Corporacion_N1>();
        }

        public void Init(GastoTransparenteMunicipalEntities db, int idMunicipality)
        {
            Corporacion_Ano corporacion_Ano = db.Corporacion_Ano.Where(r => r.IdMunicipalidad == idMunicipality).OrderByDescending(r => r.IdAno).First();
            var corporacion_nivel1 = db.Corporacion_Ano.Where(r => r.IdAno == corporacion_Ano.IdAno).ToList();
            Mapper.Map(corporacion_nivel1, this.Corporacion_Nivel3);
        }

        public void Load(GastoTransparenteMunicipalEntities db, int idMunicipality, int year)
        {
            Corporacion_Ano corporacion_Ano = db.Corporacion_Ano.Where(r => r.IdMunicipalidad == idMunicipality && r.Ano == year).First();
            var corporacion_nivel1 = db.Corporacion_Ano.Where(r => r.IdAno == corporacion_Ano.IdAno).ToList();
            Mapper.Map(corporacion_nivel1, this.Corporacion_Nivel3);
        }
    }
}