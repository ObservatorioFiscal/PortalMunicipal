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
    
    public partial class Proveedor_Cementerio_Nivel1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor_Cementerio_Nivel1()
        {
            this.Proveedor_Cementerio_Nivel2 = new HashSet<Proveedor_Cementerio_Nivel2>();
        }
    
        public long IdNivel1 { get; set; }
        public Nullable<long> IdAno { get; set; }
        public string Nombre { get; set; }
        public Nullable<long> Monto { get; set; }
    
        public virtual Proveedor_Ano Proveedor_Ano { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor_Cementerio_Nivel2> Proveedor_Cementerio_Nivel2 { get; set; }
    }
}
