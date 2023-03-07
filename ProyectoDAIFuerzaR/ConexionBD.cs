using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace ProyectoDAIFuerzaR
{
    public class ConexionBD
    {
        public OdbcConnection con { get; set; }
        public ConexionBD() 
        {
            System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/ProyectoDAIFuerzaR");
            System.Configuration.ConnectionStringSettings stringDeCon = webConfig.ConnectionStrings.ConnectionStrings["BDFuerzaR"];
            con = new OdbcConnection(stringDeCon.ToString());
            con.Open();
        }
    }
}