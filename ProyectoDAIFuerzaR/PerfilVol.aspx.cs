using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class PerfilVol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreVoluntario"] == null || Session["claveVoluntario"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginOrgVol.aspx");
            }
            String query = "select Voluntario.Nombre, Voluntario.Edad, Sexo.Nombre, Ciudad.Nombre, " +
                " Estado.Nombre, Voluntario.Telefono, Voluntario.Correo, Voluntario.Contrasena from Estado inner join Ciudad " +
                " on Ciudad.ClaveEstado = Estado.ClaveEstado inner join Voluntario on Voluntario.ClaveCiudad = Ciudad.ClaveCiudad " +
                " inner join Sexo on Sexo.ClaveSexo = Voluntario.ClaveSexo " +
                " where Voluntario.ClaveVoluntario = ?";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("claveVol", Session["claveVoluntario"]);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Label2.Text = reader.GetString(0);
                Label13.Text = reader.GetInt32(1).ToString();
                Label6.Text = reader.GetString(2);
                Label8.Text = reader.GetString(3);
                Label9.Text = reader.GetString(4);
                Label10.Text = reader.GetInt32(5).ToString();
                Label11.Text = reader.GetString(6);
                Label14.Text = reader.GetString(7);
            }
            con.Close();reader.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioVoluntario.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}