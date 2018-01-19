using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class InformeProveedoresResumen
    {
        public long IdInformeProveedoresResumen { get; set; }
        public Nullable<System.Guid> IdGroupInformeProveedores { get; set; }
        public string Proveedor { get; set; }
        public Nullable<long> Monto { get; set; }
    }
}
