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
    
    public partial class InformePersonalCategoriaSalud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InformePersonalCategoriaSalud()
        {
            this.InformePersonalResultadoSalud = new HashSet<InformePersonalResultadoSalud>();
        }
    
        public long IdInformePersonalCategoria { get; set; }
        public Nullable<System.Guid> IdGroupInformePersonal { get; set; }
        public Nullable<int> IdMunicipalidad { get; set; }
        public Nullable<int> AnoInforme { get; set; }
        public Nullable<int> MesInforme { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformePersonalResultadoSalud> InformePersonalResultadoSalud { get; set; }
    }
}
