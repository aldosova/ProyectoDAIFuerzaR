using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class HistorialVol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreVoluntario"] == null || Session["claveVoluntario"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginOrgVol.aspx");
            }
            //ClaveVoluntario --> Session[]
            String query = "select Tarea.Descripcion, Ciudad.Nombre as 'Ciudad', Tarea.Domicilio, Evento.Nombre as 'Evento', TareaVoluntario.FechaInicio, TareaVoluntario.FechaFin " +
                " from Ciudad inner join Evento on Ciudad.ClaveCiudad = Evento.ClaveCiudad" +
                " inner join Tarea on Tarea.ClaveEvento = Evento.ClaveEvento inner join " +
                " TareaVoluntario on TareaVoluntario.ClaveTarea = Tarea.ClaveTarea " +
                " where TareaVoluntario.ClaveVoluntario = ?";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query, con);
            cmd.Parameters.AddWithValue("claveVol", Session["claveVoluntario"]);
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                GridView1.Visible = true;
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
            con.Close(); dr.Close();
            if (GridView1.Rows.Count == 0)
            {
                GridView1.Visible= false;
                Label1.Text = "Tu historial está vacío";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioVoluntario.aspx");
        }
    }
}