﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Ingreso_N3
    {
        public long IdNivel3 { get; set; }
        public Nullable<long> IdNivel2 { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public Nullable<long> MontoGastado { get; set; }
        public Nullable<long> MontoPresupuestado { get; set; }
        public Nullable<double> PorcentajeGastado { get; set; }
        public Nullable<double> PorcentajePresupuestado { get; set; }
        public string Descripcion { get; set; }
    }
}
