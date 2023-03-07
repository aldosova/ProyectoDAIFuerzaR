using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoDAIFuerzaR
{
    public partial class loginOrgVol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String queryVol = "select ClaveVoluntario, Nombre from Voluntario where Correo = ? and Contrasena = ? ";
            String queryOrg = "select ClaveOrganizacion, Nombre from Organizacion where Correo = ? and Contrasena = ? ";
            OdbcConnection conexionVol = new ConexionBD().con;
            OdbcConnection conexionOrg = new ConexionBD().con;
            OdbcCommand comandoVol = new OdbcCommand(queryVol, conexionVol);
            OdbcCommand comandoOrg = new OdbcCommand(queryOrg, conexionOrg);
            comandoVol.Parameters.AddWithValue("emailVol", TextBox1.Text);
            comandoVol.Parameters.AddWithValue("passwordVol", TextBox2.Text);
            comandoOrg.Parameters.AddWithValue("emailOrg", TextBox1.Text);
            comandoOrg.Parameters.AddWithValue("passwordOrg", TextBox2.Text);
            OdbcDataReader lectorVol = comandoVol.ExecuteReader();
            OdbcDataReader lectorOrg = comandoOrg.ExecuteReader();
            if (lectorVol.HasRows)
            {
                lectorVol.Read();
                Session.Add("claveVoluntario", lectorVol.GetInt32(0));
                Session.Add("nombreVoluntario", lectorVol.GetString(1));
                Session.Timeout = 10;
                Response.Redirect("InicioVoluntario.aspx");
            }
            else if (lectorOrg.HasRows)
            {
                lectorOrg.Read();
                Session.Add("claveOrganizacion", lectorOrg.GetInt32(0));
                Session.Add("nombreOrganizacion", lectorOrg.GetString(1));
                Session.Timeout = 10;
                Response.Redirect("InicioOrganizacion.aspx");
            }
            else
            {
                Session.Abandon();
                Label1.Text = "Correo o contraseña incorrectos";
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            lectorVol.Close();lectorOrg.Close();
            conexionVol.Close(); conexionOrg.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreacionCuenta.aspx");
        }
    }
}