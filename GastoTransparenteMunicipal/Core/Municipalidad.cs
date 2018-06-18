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
    
    public partial class Municipalidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Municipalidad()
        {
            this.Corporacion_Ano = new HashSet<Corporacion_Ano>();
            this.Gasto_Ano = new HashSet<Gasto_Ano>();
            this.Ingreso_Ano = new HashSet<Ingreso_Ano>();
            this.Personal_Ano = new HashSet<Personal_Ano>();
            this.Proveedor_Ano = new HashSet<Proveedor_Ano>();
            this.Subsidio_Ano = new HashSet<Subsidio_Ano>();
        }
    
        public int IdMunicipalidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
        public string DireccionWeb { get; set; }
        public bool Cementerio { get; set; }
        public bool Act_Personal { get; set; }
        public bool Act_Proveedor { get; set; }
        public bool Act_Subsidio { get; set; }
        public bool Act_Corporacion { get; set; }
        public Nullable<double> TotalGastado { get; set; }
        public Nullable<double> TotalPresupuestado { get; set; }
        public string Periodo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Corporacion_Ano> Corporacion_Ano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gasto_Ano> Gasto_Ano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingreso_Ano> Ingreso_Ano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal_Ano> Personal_Ano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Ano> Proveedor_Ano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subsidio_Ano> Subsidio_Ano { get; set; }
    }
}
