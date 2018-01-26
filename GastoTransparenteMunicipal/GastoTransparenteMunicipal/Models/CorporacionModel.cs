using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using AutoMapper;
using Newtonsoft.Json;

namespace GastoTransparenteMunicipal.Models
{
    public class CorporacionModel
    {
        public List<Corporacion_N1> Corporacion_Nivel1 { get; set; }
        public string JsonCorporacion_Nivel1 { get; set; }

        public CorporacionModel()
        {
            this.Corporacion_Nivel1 = new List<Corporacion_N1>();
        }

        public void Init(GastoTransparenteMunicipalEntities db, int idMunicipality)
        {
            Corporacion_Ano corporacion_Ano = db.Corporacion_Ano.Where(r => r.IdMunicipalidad == idMunicipality).OrderByDescending(r => r.IdAno).First();
            var corporacion_nivel1 = db.Corporacion_Nivel1.Where(r => r.IdAno == corporacion_Ano.IdAno).ToList();
            Mapper.Map(corporacion_nivel1, this.Corporacion_Nivel1);
            LoadJson(this.Corporacion_Nivel1);
        }

        public void Load(GastoTransparenteMunicipalEntities db, int idMunicipality, int year)
        {
            Corporacion_Ano corporacion_Ano = db.Corporacion_Ano.Where(r => r.IdMunicipalidad == idMunicipality && r.Ano == year).First();
            var corporacion_nivel1 = db.Corporacion_Ano.Where(r => r.IdAno == corporacion_Ano.IdAno).ToList();
            Mapper.Map(corporacion_nivel1, this.Corporacion_Nivel1);
            LoadJson(this.Corporacion_Nivel1);
        }

        private void LoadJson(List<Corporacion_N1> corporacion_Nivel1)
        {
            var namesOrigen = corporacion_Nivel1.Select(r => new { name = r.Origen, name2 = r.Origen });
            var namesDestino = corporacion_Nivel1.Select(r => new { name = r.Destino, name2 = r.Destino});

            var nodes = namesOrigen.Union(namesDestino);
            var namesArray = nodes.Select( (r, i)  => new { name = r.name, index = i });

            List<object> links = new List<object>();

            foreach(var item in corporacion_Nivel1)
            {
                var _source = namesArray.Where(r => r.name == item.Origen).Select(r => r.index).First();
                var _target = namesArray.Where(r => r.name == item.Destino).Select(r => r.index).First();
                var _value = item.Monto;

                var link = new
                {
                    source = _source
                    ,
                    target = _target
                    ,
                    value = _value
                };

                links.Add(link);
            }

            var jsonData = new
            {
                nodes = nodes,
                links = links
            };

            this.JsonCorporacion_Nivel1 = JsonConvert.SerializeObject(jsonData);          
        }
    }
}