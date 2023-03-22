using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class TareaVol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreVoluntario"] == null || Session["claveVoluntario"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginOrgVol.aspx");
            }
            if(Session.Count == 2)
            {
                Response.Redirect("InicioVoluntario.aspx");
            }
            String query = "select Tarea.ClaveTarea, Tarea.Descripcion, Tarea.Domicilio, Evento.Nombre, TareaVoluntario.FechaInicio from Evento " +
                " inner join Tarea on Tarea.ClaveEvento = Evento.ClaveEvento inner join " +
                " TareaVoluntario on TareaVoluntario.ClaveTarea = Tarea.ClaveTarea " +
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
            con.Close();reader.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("claveTarea");
            Response.Redirect("InicioVoluntario.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String query = "update TareaVoluntario set FechaFin = CURRENT_TIMESTAMP where TareaVoluntario.ClaveTarea = ?";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("ClaveTarea", Session["claveTarea"]);
            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Tarea completada exitosamente";
            }
            catch(Exception ex)
            {
                Label1.Text = "No pudimos marcar la tarea como completada";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String query = "delete from TareaVoluntario where ClaveTarea = ?";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("ClaveTarea", Session["claveTarea"]);
            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Has renunciado a la tarea exitosamente";
            }
            catch (Exception ex)
            {
                Label1.Text = "No pudimos renunciar a la tarea";
            }
        }
    }
}