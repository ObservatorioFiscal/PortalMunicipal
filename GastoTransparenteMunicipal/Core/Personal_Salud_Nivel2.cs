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
    
    public partial class Personal_Salud_Nivel2
    {
        public long IdNivel2 { get; set; }
        public Nullable<long> IdNivel1 { get; set; }
        public string Nombre { get; set; }
        public Nullable<long> MontoMujer { get; set; }
        public Nullable<long> MontoHombre { get; set; }
        public Nullable<long> CantidadMujer { get; set; }
        public Nullable<long> CantidadHombre { get; set; }
    
        public virtual Personal_Salud_Nivel1 Personal_Salud_Nivel1 { get; set; }
    }
}
