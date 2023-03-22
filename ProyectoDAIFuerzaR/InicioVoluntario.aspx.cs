using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoDAIFuerzaR
{
    public partial class InicioVoluntario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreVoluntario"] == null || Session["claveVoluntario"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginOrgVol.aspx");
            }
            //ClaveVoluntario --> Session[]
            String query1 = "select Tarea.ClaveTarea, Tarea.Descripcion, Ciudad.Nombre as 'Ciudad', Evento.Nombre as 'Evento' , " +
                " Tarea.Domicilio, TareaVoluntario.FechaInicio from Ciudad " +
                " inner join Evento on Evento.ClaveCiudad = Ciudad.ClaveCiudad " +
                " inner join Tarea on Evento.ClaveEvento = Tarea.ClaveEvento " +
                " inner join TareaVoluntario on TareaVoluntario.ClaveTarea = Tarea.ClaveTarea " +
                " inner join Voluntario on Voluntario.ClaveVoluntario = TareaVoluntario.ClaveVoluntario " +
                " where Voluntario.ClaveVoluntario = ? and TareaVoluntario.FechaFin is null";
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query1, con);
            cmd.Parameters.AddWithValue("claveVol", Session["claveVoluntario"]);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                GridView1.Visible= true;
                GridView1.AutoGenerateSelectButton = true;
                GridView1.DataSource= reader;
                GridView1.DataBind();
            }
            else
            {
                GridView1.Visible= false;
                Label1.Text = "No tienes tareas por hacer";
            }
            String query2 = "select Tarea.ClaveTarea, Tarea.Descripcion, Ciudad.Nombre as 'Ciudad', Evento.Nombre as 'Evento' , Tarea.Domicilio from Ciudad  " +
                " inner join Evento on Evento.ClaveCiudad = Ciudad.ClaveCiudad " +
                " inner join Tarea on Evento.ClaveEvento = Tarea.ClaveEvento" +
                " except " +
                " select Tarea.ClaveTarea, Tarea.Descripcion, Ciudad.Nombre as 'Ciudad', Evento.Nombre as 'Evento' , Tarea.Domicilio from Ciudad  " +
                " inner join Evento on Evento.ClaveCiudad = Ciudad.ClaveCiudad " +
                " inner join Tarea on Evento.ClaveEvento = Tarea.ClaveEvento " +
                " inner join TareaVoluntario on TareaVoluntario.ClaveTarea = Tarea.ClaveTarea " +
                " inner join Voluntario on Voluntario.ClaveVoluntario = TareaVoluntario.ClaveVoluntario " +
                " where Voluntario.ClaveVoluntario = ? ";
            cmd = new OdbcCommand(query2, con);
            cmd.Parameters.AddWithValue("claveVol", Session["claveVoluntario"]);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                GridView2.Visible = true;
                GridView2.AutoGenerateSelectButton = true;
                GridView2.DataSource = reader;
                GridView2.DataBind();
            }
            else
            {
                GridView2.Visible = false;
                Label2.Text = "No hay tareas disponibles";
            }
            con.Close();reader.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("loginOrgVol.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilVol.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialVol.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("claveTarea", GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            Response.Redirect("TareaVol.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("claveTarea", GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text);
            Response.Redirect("TareaDispVol.aspx");
        }
    }
}