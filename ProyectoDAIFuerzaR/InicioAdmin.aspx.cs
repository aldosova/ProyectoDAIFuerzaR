using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class InicioAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["claveAdmin"] == null || Session["nombreAdmin"] == null)
            {
                Session.Abandon();
                Response.Redirect("loginAdmin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("VolAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TareasAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventosAdmin.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrganizacionesAdmin.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("loginAdmin.aspx");
        }
    }
}