using System;
using System.Collections.Generic;
using System.Linq;
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
            if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "Tu historial está vacío";
            }
            else
            {
                //ClaveVoluntario --> Session[]
                String query = "select Tarea.Descripcion, Tarea.FechaInicio, Tarea.FechaFin from Tarea inner join " +
                    "EventoTareaVoluntario on EventoTareaVoluntario.ClaveTarea = Tarea.ClaveTarea inner join Voluntario " +
                    "on Voluntario.ClaveVoluntario = EventoTareaVoluntario.ClaveVoluntario where Tarea.FechaFin is not null and " +
                    "Voluntario.ClaveVoluntario = ?";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioVoluntario.aspx");
        }
    }
}