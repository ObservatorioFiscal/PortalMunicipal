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
    
    public partial class CorporacionInforme
    {
        public long IdInformeCorporacion { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.Guid> IdGroupInforme { get; set; }
        public string ObjetivoDelAporte { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public Nullable<long> MontoAportado { get; set; }
    }
}
