using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InformeProveedores
    {
        public long IdInformeProveedores { get; set; }
        public Nullable<int> IdMunicipalidad { get; set; }
        public Nullable<System.Guid> IdGroupInformeProveedores { get; set; }
        public Nullable<int> AnoInforme { get; set; }
        public Nullable<int> MesInforme { get; set; }
        public Nullable<long> NumeroOrdenCompra { get; set; }
        public string Glosa { get; set; }
        public string Proveedor { get; set; }
        public string RUT { get; set; }
        public Nullable<long> Monto { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual Municipalidad Municipalidad { get; set; }
    }
}
