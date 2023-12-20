using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_Monserrat
{
    public partial class Encuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                Llenartipos();
            }

        }
  

    public void alertas(String texto)
    {
        string message = texto;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload=function(){");
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("')};");
        sb.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

    }
    protected void LlenarGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT *  FROM encuestas"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }
            }
        }
    }


    protected void Llenartipos()
    {
        string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("select partido from Partidos_Politicos"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList1.DataSource = dt;

                        DropDownList1.DataTextField = dt.Columns["partido"].ToString();
                        DropDownList1.DataBind();
                    }
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

            int resultado = Clases.Formulario.Agregar(tnombre.Text, tnacimiento.Text, tcorreo.Text, (DropDownList1.SelectedValue));

        if (resultado > 0)
        {
            alertas("encuesta ingresada con exito");
            tnombre.Text = string.Empty;
            LlenarGrid();
        }
        else
        {
            alertas("Error al ingresar encuesta");

        }
    }
}
}
  