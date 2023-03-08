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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioVoluntario.aspx");
        }
    }
}