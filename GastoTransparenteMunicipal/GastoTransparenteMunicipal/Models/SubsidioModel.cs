using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using AutoMapper;

namespace GastoTransparenteMunicipal.Models
{
    public class SubsidioModel
    {
        public List<Subsidio_N1> Subsidio_Nivel1 { get; set; }
        
       

        public SubsidioModel()
        {
            this.Subsidio_Nivel1 = new List<Core.Subsidio_N1>();
            
        }

        public void Init(GastoTransparenteMunicipalEntities db, int idMunicipality)
        {
            Subsidio_Ano subsidio_Ano = db.Subsidio_Ano.Where(r => r.IdMunicipalidad == idMunicipality).OrderByDescending(r => r.IdAno).First();
            var subsidio_Nivel1 = db.Subsidio_Nivel1.Where(r => r.IdAno == subsidio_Ano.IdAno).ToList();


            foreach (var subsidio_nivel1 in this.Subsidio_Nivel1)
            {
                var subsidio_nivel2 = db.Subsidio_Nivel2.Where(r => r.IdNivel1 == subsidio_nivel1.IdNivel1).ToList();

                var subsidio_n1 = new Core.Subsidio_N1();
                for (int i = 0; i < subsidio_nivel2.Count; i++ )
                {
                                      
                    var subsidio_N2 = new Core.Subsidio_N2();

                    var subN2 = subsidio_nivel2[i];
                    var subsidio_nivel3 = db.Subsidio_Nivel3.Where(r => r.IdNivel2 == subN2.IdNivel2).ToList();

                    subsidio_N2.subsidio_Nivel3 = Mapper.Map<List<Core.Subsidio_Nivel3>, List<Subsidio_N3>>(subsidio_nivel3);
                    Mapper.Map(subN2, subsidio_N2);
                    subsidio_n1.subsidio_Nivel2.Add(subsidio_N2);
                }
                Mapper.Map(subsidio_nivel1, subsidio_n1);
                this.Subsidio_Nivel1.Add(subsidio_n1);
            }
        }
    }
}