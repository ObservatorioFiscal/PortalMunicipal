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
    
    public partial class Proveedor_Adm_Nivel2
    {
        public long IdNivel2 { get; set; }
        public Nullable<long> IdNIvel1 { get; set; }
        public string Nombre { get; set; }
        public Nullable<long> Monto { get; set; }
        public string Area { get; set; }
        public string Glosa { get; set; }
    
        public virtual Proveedor_Adm_Nivel1 Proveedor_Adm_Nivel1 { get; set; }
    }
}