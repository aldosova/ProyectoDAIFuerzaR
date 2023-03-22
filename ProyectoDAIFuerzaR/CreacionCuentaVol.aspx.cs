using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoDAIFuerzaR
{
    public partial class CreacionCuentaVol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count == 0)
            {
                String query = "select ClaveCiudad, Nombre from Ciudad";
                OdbcConnection con = new ConexionBD().con;
                OdbcCommand cmd = new OdbcCommand(query, con);
                OdbcDataReader dr = cmd.ExecuteReader();
                DropDownList1.DataSource= dr;
                DropDownList1.DataValueField = "ClaveCiudad";
                DropDownList1.DataTextField = "Nombre";
                DropDownList1.DataBind();
                dr.Close();con.Close();
            }
            if (DropDownList3.Items.Count == 0)
            {
                String query = "select ClaveSexo, Nombre from Sexo";
                OdbcConnection con = new ConexionBD().con;
                OdbcCommand cmd = new OdbcCommand(query, con);
                OdbcDataReader dr = cmd.ExecuteReader();
                DropDownList3.DataSource = dr;
                DropDownList3.DataValueField = "ClaveSexo";
                DropDownList3.DataTextField = "Nombre";
                DropDownList3.DataBind();
                dr.Close(); con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginOrgVol.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query1 = "select max(ClaveVoluntario) from Voluntario";
            //ClaveVoluntario --> llave
            //Correo --> TextBox10
            //Contrasena --> TextBox12
            //Nombre --> TextBox1
            //Edad --> TextBox4
            //Sexo --> DropDownList3
            //Telefono --> TextBox9
            //ClaveCiudad --> DropDownList1
            String query2 = "insert into Voluntario values(?,?,?,?,?,?,?,?)";
            int llave = 1;
            OdbcConnection con = new ConexionBD().con;
            OdbcCommand cmd = new OdbcCommand(query1, con);
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                llave = dr.GetInt32(0);
                llave++;
            }
            dr.Close();
            cmd = new OdbcCommand(query2, con);
            cmd.Parameters.AddWithValue("ClaveVoluntario", llave);
            cmd.Parameters.AddWithValue("Correo",TextBox10.Text);
            cmd.Parameters.AddWithValue("Contrasena",TextBox12.Text);
            cmd.Parameters.AddWithValue("Nombre",TextBox1.Text);
            cmd.Parameters.AddWithValue("Edad",TextBox4.Text);
            cmd.Parameters.AddWithValue("Sexo",DropDownList3.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("Telefono",TextBox9.Text);
            cmd.Parameters.AddWithValue("ClaveCiudad", DropDownList1.SelectedValue.ToString());
            try
            {
                cmd.ExecuteNonQuery();

                Label1.Text = "Cuenta registrada con exito";
            }
            catch(Exception ex)
            {
                Label1.Text = "No pudimos registrar la cuenta" + ex.ToString();
            }
            con.Close();
        }
    }
}