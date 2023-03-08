using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoDAIFuerzaR
{
    public partial class loginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select ClaveAdministrador, Nombre from Administrador where Correo = ? and Contrasena = ?";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("email", TextBox1.Text);
            cmd.Parameters.AddWithValue("password",TextBox2.Text);
            OdbcDataReader lector = cmd.ExecuteReader();
            if(lector.HasRows)
            {
                lector.Read();
                Session.Add("claveAdmin", lector.GetInt32(0));
                Session.Add("nombreAdmin", lector.GetString(1));
                Session.Timeout = 10;
                Response.Redirect("InicioAdmin.aspx");
            }
            else
            {
                Session.Abandon();
                Label1.Text = "Correo o contraseña incorrectos";
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            lector.Close();
            con.Close();
        }
    }
}