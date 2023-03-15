using System;
using System.Collections.Generic;
using System.Linq;
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
            //Todo viene del reader
            String query1 = "select * from Voluntario where ClaveVoluntario = ?";
            //ClaveVoluntario --> Session[]
            String query2 = "select Habilidad.Nombre from Habilidad inner join HabilidadVoluntario on " +
                "HabilidadVoluntario.ClaveHabilidad = Habilidad.ClaveHabilidad inner join Voluntario on " +
                "Voluntario.ClaveVoluntario = HabilidadVoluntario.ClaveVoluntario where Voluntario.ClaveVoluntario = ?";
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