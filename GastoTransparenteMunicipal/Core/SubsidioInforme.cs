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
    
    public partial class SubsidioInforme
    {
        public long IdSubsidio { get; set; }
        public Nullable<System.Guid> IdGroupInformeSubsidio { get; set; }
        public string CATEGORIA { get; set; }
        public string ORGANIZACION { get; set; }
        public Nullable<System.DateTime> FECHADECRETO { get; set; }
        public string OBJETIVODELAPORTE { get; set; }
        public Nullable<double> MONTOAPORTE { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}