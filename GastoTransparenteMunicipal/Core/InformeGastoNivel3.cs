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
    
    public partial class InformeGastoNivel3
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InformeGastoNivel3()
        {
            this.InformeGastoNivel4 = new HashSet<InformeGastoNivel4>();
        }
    
        public System.Guid IdInformeGastoNivel3 { get; set; }
        public System.Guid IdInformeGastoNivel2 { get; set; }
        public string Nombre { get; set; }
        public string NombreGrupo { get; set; }
        public Nullable<double> TotalDePresupuestoNV3 { get; set; }
        public Nullable<double> TotalDeGastoNV3 { get; set; }
        public Nullable<double> PorcentajeDelTotalDePresupuesto { get; set; }
        public Nullable<double> PorcentajeDelTotalDeGasto { get; set; }
        public string Descripcion { get; set; }
    
        public virtual InformeGastoNivel2 InformeGastoNivel2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformeGastoNivel4> InformeGastoNivel4 { get; set; }
    }
}
