using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            String query = "select Voluntario.ClaveVoluntario, Tarea.Descripcion from Tarea inner join EventoTareaVoluntario on " +
                "EventoTareaVoluntario.ClaveTarea = Tarea.ClaveTarea inner join Voluntario on " +
                "Voluntario.ClaveVoluntario = EventoTareaVoluntario.ClaveVoluntario where Voluntario.ClaveVoluntario = ?";
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
    }
}