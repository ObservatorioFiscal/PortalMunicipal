//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proveedor_Ano
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor_Ano()
        {
            this.Proveedor_Adm_Nivel1 = new HashSet<Proveedor_Adm_Nivel1>();
            this.Proveedor_Cementerio_Nivel1 = new HashSet<Proveedor_Cementerio_Nivel1>();
            this.Proveedor_Educacion_Nivel1 = new HashSet<Proveedor_Educacion_Nivel1>();
            this.Proveedor_Salud_Nivel1 = new HashSet<Proveedor_Salud_Nivel1>();
            this.Proveedor_Total_Nivel1 = new HashSet<Proveedor_Total_Nivel1>();
        }
    
        public long IdAno { get; set; }
        public Nullable<int> IdMunicipalidad { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public bool Activo { get; set; }
        public Nullable<decimal> Semestre { get; set; }
        public bool Cargado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Adm_Nivel1> Proveedor_Adm_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Cementerio_Nivel1> Proveedor_Cementerio_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Educacion_Nivel1> Proveedor_Educacion_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Salud_Nivel1> Proveedor_Salud_Nivel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Total_Nivel1> Proveedor_Total_Nivel1 { get; set; }
        public virtual Municipalidad Municipalidad { get; set; }
    }
}
