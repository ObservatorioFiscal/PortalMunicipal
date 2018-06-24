using Core;
using GastoTransparenteMunicipal.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GastoTransparenteMunicipal.Controllers
{
    public class BaseController : Controller
    {
        private string connectionString = "Server=tcp:serverobservatorio.database.windows.net,1433;Initial Catalog=GastoTransparenteMunicipal;Persist Security Info=False;User ID=adminserverprueba;Password=Observatori02016;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public GastoTransparenteMunicipalEntities db = new GastoTransparenteMunicipalEntities();        
        //public string SubsidioInforme = "SubsidioInforme";
        //public string Proveedor_SaludInforme = "Proveedor_SaludInforme";
        //public string Proveedor_EducacionInforme = "Proveedor_EducacionInforme";
        //public string Proveedor_CementerioInforme = "Proveedor_CementerioInforme";
        //public string Proveedor_AdmInforme = "Proveedor_AdmInforme";
        //public string Personal_SaludInforme = "Personal_SaludInforme";
        //public string Personal_EducacionInforme = "Personal_EducacionInforme";
        //public string Personal_CementerioInforme = "Personal_CementerioInforme";
        //public string Personal_AdmInforme = "Personal_AdmInforme";
        //public string IngresoInforme = "IngresoInformev2";
        //public string GastoInforme = "GastoInformev2";
        //public string CorporacionInforme = "CorporacionInforme";
        
        public string GetCurrentMunicipality()
        {
            var municipalityName = RouteData.Values["municipality"].ToString();
            return municipalityName;
        }

        public Municipalidad GetCurrentIdMunicipality()
        {
            var municipalityName = RouteData.Values["municipality"].ToString();
            var municipality = db.Municipalidad.SingleOrDefault(r => r.DireccionWeb == municipalityName);
            return municipality;
        }

        public int SaveBulk<T>(List<T> list,string tableName)
        {            
            ConvertTo convert = new ConvertTo();
            using (DataTable table = convert.DataTable<T>(list))
            {
                using (var sqlBulk = new SqlBulkCopy(connectionString))
                {
                    sqlBulk.DestinationTableName = tableName;
                    sqlBulk.WriteToServer(table);
                    return 1;
                }
            }
        }
    }
}