using Presidencia.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presidencia
{
    public partial class AgendaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios Usuario = Session["Usuario"] as Usuarios;
            if (Usuario != null)
            {
                Response.Redirect("Inicio.aspx");
                Page.Session.Timeout = 180;

            }
            else
            {
                if (!IsPostBack)
                {
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            string User = txtUser.Text.Trim();
            string Pass = txtContraseña.Text.Trim();

            SqlConnection cnn = new SqlConnection(CConexion.Obtener());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;
            string qry;


            qry = "  SELECT IdUsuario , Nombre , Usuario   ";
            qry += " FROM   dbo.Usuarios ";
            qry += " WHERE  Usuario='" + User + "' COLLATE SQL_Latin1_General_CP1_CS_AS  and Pass='" + Pass + "' COLLATE SQL_Latin1_General_CP1_CS_AS";

            cmd.Connection = cnn;
            cmd.CommandText = qry;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader();
            }

            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                //Alerta2.Visible = true;
                //Password.Text = "";
                MensajeAlerta.AlertaAviso(this, "Error", "Error :" + ex.Message);
            }

            try
            {
                if (rdr.Read())
                {
                    Usuarios usuario = new Usuarios();
                    usuario.IdUsuario = rdr.GetInt32(0);
                    usuario.Nombre = rdr.GetString(1);
                    usuario.Usuario = rdr.GetString(2);

                    Session["login"] = "true";
                    Session["Usuario"] = usuario;
                    cnn.Close();
                    Response.Redirect("Inicio.aspx");


                }
                else
                {
                    //Alerta3.Visible = true;
                    //Password.Text = "";    

                    MensajeAlerta.AlertaAviso(this, "Alerta!", "Usuario no identificado.");

                }

            }
            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();

                //Alerta2.Visible = true;
                //Password.Text = "";
                //  Response.Redirect("404.aspx");

            }
        }

    }
}