using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class CreacionCuentaOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginOrgVol.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query1 = "select max(ClaveOrganizacion) from Organizacion";
            //ClaveOrganizacion --> llave
            String query2 = "select ClaveOrganizacion from Organizacion where ClaveOrganizacion = ?";
            //ClaveOrganizacion --> llave
            //Correo --> TextBox7
            //Contrasena --> TextBox9
            //Nombre --> TextBox1
            //Telefono --> TextBox6
            //Domicilio --> TextBox2
            //ClaveCiudad --> DropDownList1
            String query3 = "insert into Organizacion values (?,?,?,?,?,?,?)";
            int llave = 1;
        }
    }
}