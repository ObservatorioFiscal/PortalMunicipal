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
    
    public partial class Corporacion_Nivel1
    {
        public long IdNivel1 { get; set; }
        public Nullable<long> IdAno { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public Nullable<long> Monto { get; set; }
    
        public virtual Corporacion_Ano Corporacion_Ano { get; set; }
    }
}
