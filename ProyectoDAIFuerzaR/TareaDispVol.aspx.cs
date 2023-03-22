using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class TareaDispVol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreVoluntario"] == null || Session["claveVoluntario"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginOrgVol.aspx");
            }
            if (Session.Count == 2)
            {
                Response.Redirect("InicioVoluntario.aspx");
            }
            String query = "select Tarea.Descripcion, Estado.Nombre as 'Estado', Ciudad.Nombre as 'Ciudad', " +
                " Tarea.Domicilio, Evento.Nombre from Estado inner join Ciudad on Ciudad.ClaveEstado = Estado.ClaveEstado " +
                " inner join Evento on Evento.ClaveCiudad = Ciudad.ClaveCiudad" +
                " inner join Tarea on Tarea.ClaveEvento = Evento.ClaveEvento " +
                " where Tarea.ClaveTarea = ?";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("ClaveTarea", Session["claveTarea"]);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                GridView1.Visible = true;
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
            con.Close(); reader.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String query = "insert into TareaVoluntario values (?,?,CURRENT_TIMESTAMP,null)";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("claveT", Session["claveTarea"]);
            cmd.Parameters.AddWithValue("claveV", Session["claveVoluntario"]);
            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Tarea aceptada exitosamente";
            }
            catch(Exception ex)
            {
                Label1.Text = "No pudimos aceptar la tarea";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("claveTarea");
            Response.Redirect("InicioVoluntario.aspx");
        }
    }
}