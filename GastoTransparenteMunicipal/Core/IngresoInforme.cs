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
    
    public partial class IngresoInforme
    {
        public long IdIngresoInforme { get; set; }
        public string TIPO { get; set; }
        public string AREANIVEL1A { get; set; }
        public string AREANIVEL2 { get; set; }
        public string CUENTANIVEL1 { get; set; }
        public string CUENTANIVEL2 { get; set; }
        public Nullable<double> MontoPresupuestadoAnual { get; set; }
        public Nullable<double> MontoGastado { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<System.Guid> IdGroupInformeIngreso { get; set; }
    }
}
