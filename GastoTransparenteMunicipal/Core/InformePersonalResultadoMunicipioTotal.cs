//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class InformePersonalResultadoMunicipioTotal
    {
        public long IdInformePersonalResultado { get; set; }
        public Nullable<long> IdInformePersonalCategoria { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public Nullable<long> SueldoPromedio { get; set; }
        public Nullable<int> CantidadFuncionarios { get; set; }
    
        public virtual InformePersonalCategoriaMunicipioTotal InformePersonalCategoriaMunicipioTotal { get; set; }
    }
}
