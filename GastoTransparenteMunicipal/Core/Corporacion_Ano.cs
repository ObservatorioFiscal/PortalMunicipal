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
    
    public partial class Corporacion_Ano
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corporacion_Ano()
        {
            this.Corporacion_Nivel1 = new HashSet<Corporacion_Nivel1>();
        }
    
        public long IdAno { get; set; }
        public Nullable<int> IdMunicipalidad { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public bool Activo { get; set; }
        public Nullable<decimal> Semestre { get; set; }
        public bool Cargado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporacion_Nivel1> Corporacion_Nivel1 { get; set; }
        public virtual Municipalidad Municipalidad { get; set; }
    }
}
