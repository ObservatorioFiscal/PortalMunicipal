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
    
    public partial class Personal_Ano
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal_Ano()
        {
            this.Personal_Adm_Nivel1 = new HashSet<Personal_Adm_Nivel1>();
            this.Personal_Cementerio_Nivel1 = new HashSet<Personal_Cementerio_Nivel1>();
            this.Personal_Educacion_Nivel1 = new HashSet<Personal_Educacion_Nivel1>();
            this.Personal_Salud_Nivel1 = new HashSet<Personal_Salud_Nivel1>();
            this.Personal_Total_Nivel1 = new HashSet<Personal_Total_Nivel1>();
        }
    
        public long IdAno { get; set; }
        public Nullable<int> IdMunicipalidad { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public bool Activo { get; set; }
        public Nullable<decimal> Semestre { get; set; }
        public bool Cargado { get; set; }
    
        public virtual Municipalidad Municipalidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Adm_Nivel1> Personal_Adm_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Cementerio_Nivel1> Personal_Cementerio_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Educacion_Nivel1> Personal_Educacion_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Salud_Nivel1> Personal_Salud_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Total_Nivel1> Personal_Total_Nivel1 { get; set; }
    }
}
