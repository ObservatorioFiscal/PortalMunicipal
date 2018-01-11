using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastoTransparenteMunicipal.Helpers
{
    public class d3Object
    {
        public class d3Object_TreeMap
        {
            //public d3Object_TreeMap()
            //{
            //    elementos1 = new List<string>();
            //}
            //private List<string> elementos1;
            //private string json;
            //private string formatter;
            //private string getCabecera()
            //{
            //    string cabecera = @"{
            //                         ""name"": ""flare"",
            //                         ""children"": [";
            //    return cabecera;
            //}
            //private string getPie()
            //{
            //    string pie = @"  ]
            //                    }";
            //    return pie;
            //}
            //private string createNivel1()
            //{
            //    string childrens = "";
            //    for (int i = 0; i < elementos1.Count; i++)
            //    {
            //        string aux = elementos1[i];
            //        if (i + 1 == elementos1.Count)
            //            aux = aux.Substring(0, aux.Length - 1);
            //        childrens += aux;
            //    }
            //    return childrens;
            //}
            //public void setFormato(string formatter)
            //{
            //    this.formatter = formatter;
            //}
            //public void addElementoNV1(string name, string size, string nivel, string tipo, string color, string id, string idRegion)
            //{
            //    int numero = int.Parse(size);
            //    string valueTooltip = string.Format(new System.Globalization.CultureInfo("is-IS"), "{0:N0}", numero);
            //    string auxElem = @"{
            //                 ""name"":" + @"""" + name + @"""" +
            //                     @",""size"":" + @"""" + size + @"""" +
            //                     @",""tipo"":" + @"""" + tipo + @"""" +
            //                     @",""valueTooltip"":" + @"""" + valueTooltip + @"""" +
            //                     @",""nivel"":" + @"""" + nivel + @"""" +
            //                     @",""id"":" + @"""" + id + @"""" +
            //                     @",""idRegion"":" + @"""" + idRegion + @"""" +
            //                     @",""color"":" + @"""" + color + @"""" + "},";
            //    elementos1.Add(auxElem);
            //}
            //public string getJson()
            //{
            //    json = getCabecera() + createNivel1() + getPie();
            //    json = json.Remove(json.Length - 1, 1) + ", \"Format\":\"" + this.formatter + " \"}";
            //    return json;
            //}
            //public void Load(List<Cuadrados_d3Object_TreeMap> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    if (formatter == "percapita")
            //    {
            //        #region percapita
            //        var valores = d3Object.GroupBy(r => r.Titulo).Select(r => new
            //        {
            //            Nombre = r.First().Titulo,
            //            valor = r.Sum(l => l.valorPercapita).ToString(),
            //            Tipo = r.First().Tipo,
            //            Color = r.First().Color,
            //            Id = r.First().IdCuadrado.ToString(),
            //            IdRegion = r.First().IdRegion,
            //        }).ToList();
            //        foreach (var nv1 in valores)
            //        {
            //            addElementoNV1(nv1.Nombre, nv1.valor, "1", nv1.Tipo, nv1.Color, nv1.Id, "1");
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        #region nominal
            //        var valores = d3Object.GroupBy(r => r.Titulo).Select(r => new
            //        {
            //            Nombre = r.First().Titulo,
            //            valor = r.Sum(l => l.valorNominal).ToString(),
            //            Tipo = r.First().Tipo,
            //            Color = r.First().Color,
            //            Id = r.First().IdCuadrado.ToString(),
            //            IdRegion = r.First().IdRegion,
            //        });
            //        foreach (var nv1 in valores)
            //        {
            //            addElementoNV1(nv1.Nombre, nv1.valor, "1", nv1.Tipo, nv1.Color, nv1.Id, "1");
            //        }
            //        #endregion
            //    }
            //}
            //public void Load(List<SubCuadrados_d3Object_TreeMap> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    if (formatter == "percapita")
            //    {
            //        #region percapita
            //        var valores = d3Object.GroupBy(r => r.Titulo).Select(r => new
            //        {
            //            Nombre = r.First().Titulo,
            //            valor = r.Sum(l => l.valorPercapita).ToString(),
            //            Tipo = r.First().Tipo,
            //            Color = r.First().Color,
            //            Id = r.First().IdDato.ToString(),
            //            IdRegion = r.First().IdRegion,
            //        }).ToList();
            //        foreach (var nv1 in valores)
            //        {
            //            addElementoNV1(nv1.Nombre, nv1.valor, "1", nv1.Tipo, nv1.Color, nv1.Id, "1");
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        #region nominal
            //        var valores = d3Object.GroupBy(r => r.Titulo).Select(r => new
            //        {
            //            Nombre = r.First().Titulo,
            //            valor = r.Sum(l => l.valorNominal).ToString(),
            //            Tipo = r.First().Tipo,
            //            Color = r.First().Color,
            //            Id = r.First().IdDato.ToString(),
            //            IdRegion = r.First().IdRegion,
            //        });
            //        foreach (var nv1 in valores)
            //        {
            //            addElementoNV1(nv1.Nombre, nv1.valor, "1", nv1.Tipo, nv1.Color, nv1.Id, "1");
            //        }
            //        #endregion
            //    }
            //}
            //public void Load(List<nivel1> d3Object, string formatter)
            //{
            //    this.formatter = formatter;

            //    foreach (var nv1 in d3Object)
            //    {
            //        addElementoNV1222(
            //            nv1.Nombre,
            //            nv1.Valor.ToString(),
            //            nv1.Valor2.ToString(),
            //            "1",
            //            (nv1.Tipo == false) ? "0" : "1",
            //            "#ea9393",
            //            nv1.IdNivel1.ToString(),
            //            nv1.PorcentajeGastadoAlPapa,
            //            nv1.PorcentajePresupeustadoAlPapa,
            //            nv1.Descripcion);
            //    }
            //}
            //public void Load(List<nivel2> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    foreach (var nv1 in d3Object)
            //    {
            //        addElementoNV1222(
            //            nv1.Nombre,
            //            nv1.Valor.ToString(),
            //            nv1.Valor2.ToString(),
            //            "1",
            //            (nv1.Tipo == false) ? "0" : "1",
            //            "#ea9393",
            //            nv1.IdNivel2.ToString(),
            //            nv1.PorcentajeGastadoAlPapa,
            //            nv1.PorcentajePresupeustadoAlPapa,
            //            nv1.Descripcion
            //        );
            //    }
            //}
            //public void Load(List<nivel3> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    foreach (var nv1 in d3Object)
            //    {
            //        addElementoNV1222(
            //            nv1.Nombre,
            //            nv1.Valor.ToString(),
            //            nv1.Valor2.ToString(),
            //            "1",
            //            (nv1.Tipo == false) ? "0" : "1",
            //            "#ea9393",
            //            nv1.IdNivel3.ToString(),
            //            nv1.PorcentajeGastadoAlPapa,
            //            nv1.PorcentajePresupeustadoAlPapa,
            //            nv1.Descripcion);
            //    }
            //}
            //public void Load(List<nivel4> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    foreach (var nv1 in d3Object)
            //    {
            //        addElementoNV1222(
            //            nv1.Nombre,
            //            nv1.Valor.ToString(),
            //            nv1.Valor2.ToString(),
            //            "1",
            //            (nv1.Tipo == false) ? "0" : "1",
            //            "#ea9393",
            //            nv1.IdNivel4.ToString(),
            //            nv1.PorcentajeGastadoAlPapa,
            //            nv1.PorcentajePresupeustadoAlPapa,
            //            nv1.Descripcion);
            //    }
            //}
            //public void Load(List<nivel11> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    foreach (var nv1 in d3Object)
            //    {
            //        addElementoNV1222(
            //            nv1.Nombre,
            //            nv1.Valor.ToString(),
            //            nv1.Valor2.ToString(),
            //            "1",
            //            (nv1.Tipo == false) ? "0" : "1",
            //            "#ea9393",
            //            nv1.IdNivel11.ToString(),
            //            nv1.PorcentajeGastadoAlPapa,
            //            nv1.PorcentajePresupeustadoAlPapa,
            //            nv1.Descripcion);
            //    }
            //}
            //public void Load(List<nivel22> d3Object, string formatter)
            //{
            //    this.formatter = formatter;
            //    foreach (var nv1 in d3Object)
            //    {
            //        addElementoNV1222(
            //            nv1.Nombre,
            //            nv1.Valor.ToString(),
            //            nv1.Valor2.ToString(),
            //            "1",
            //            (nv1.Tipo == false) ? "0" : "1",
            //            "#ea9393",
            //            nv1.IdNivel22.ToString(),
            //            nv1.PorcentajeGastadoAlPapa,
            //            nv1.PorcentajePresupeustadoAlPapa,
            //            nv1.Descripcion);
            //    }
            //}
            //public void addElementoNV1222(string name, string size, string size2, string nivel, string tipo, string color, string id, string porcentaje1, string porcentaje2, string descripcion)
            //{
            //    int numero = int.Parse(size);
            //    int numero2 = int.Parse(size2);
            //    string valueTooltip = string.Format(new System.Globalization.CultureInfo("is-IS"), "{0:N0}", numero);
            //    string valueTooltip2 = string.Format(new System.Globalization.CultureInfo("is-IS"), "{0:N0}", numero2);
            //    string auxElem = @"{
            //                 ""name"":" + @"""" + name + @"""" +
            //                     @",""size"":" + @"""" + size + @"""" +
            //                     @",""tipo"":" + @"""" + tipo + @"""" +
            //                     @",""valueTooltip1"":" + @"""" + valueTooltip + @"""" +
            //                     @",""valueTooltip2"":" + @"""" + valueTooltip2 + @"""" +
            //                     @",""porcentaje1"":" + @"""" + porcentaje1 + @"""" +
            //                     @",""porcentaje2"":" + @"""" + porcentaje2 + @"""" +
            //                     @",""descripcion"":" + @"""" + descripcion + @"""" +
            //                     @",""nivel"":" + @"""" + nivel + @"""" +
            //                     @",""id"":" + @"""" + id + @"""" +
            //                     @",""color"":" + @"""" + color + @"""" + "},";
            //    elementos1.Add(auxElem);
            //}
        }
    }
}