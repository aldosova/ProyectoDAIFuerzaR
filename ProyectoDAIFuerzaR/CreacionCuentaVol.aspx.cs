using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class CreacionCuentaVol : System.Web.UI.Page
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
            String query1 = "select max(ClaveVoluntario) from Voluntario";
            //ClaveVoluntario --> llave
            String query2 = "select ClaveVoluntario from Voluntario where ClaveVoluntario = ?";
            //ClaveVoluntario --> llave
            //Correo --> TextBox10
            //Contrasena --> TextBox12
            //Nombre --> TextBox1
            //Edad --> TextBox4
            //Sexo --> DropDownList3
            //Telefono --> TextBox9
            //CURP --> TextBox10
            //ClaveCiudad --> DropDownList1
            String query3 = "insert into Voluntario values(?,?,?,?,?,?,?,?,?)";
            int llave = 1;
        }
    }
}