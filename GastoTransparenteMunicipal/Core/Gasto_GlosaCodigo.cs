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
    
    public partial class Gasto_GlosaCodigo
    {
        public long GlosaCodigoId { get; set; }
        public Nullable<long> GlosaId { get; set; }
        public string Codigo { get; set; }
    
        public virtual Gasto_Glosa Gasto_Glosa { get; set; }
    }
}
