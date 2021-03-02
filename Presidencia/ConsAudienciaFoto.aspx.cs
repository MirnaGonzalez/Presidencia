﻿using Presidencia.Modelos;
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
    public partial class ConsAudienciaFoto : System.Web.UI.Page
    {
        private string imgImagen;

        protected void Page_Load(object sender, EventArgs e)
        {

        

            int IdAudiencia = 1;

            List<RepAudiencias> listaAudiencias = new List<RepAudiencias>();

            SqlConnection cnn = new SqlConnection(CConexion.Obtener());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;
            string qry;


            qry = " SELECT IdAudiencia, Persona , TipoVisita , TipoAsunto, Telefono, FechaIni, FechaFin, InfoAdicional, URLFoto   ";
            qry += " FROM   dbo.vta_ReporteAudiencias ";
            qry += " WHERE  IdAudiencia= " + IdAudiencia ;
            

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

                MensajeAlerta.AlertaAviso(this, "Error", "Error :" + ex.Message);
            }

            try
            {
                if (rdr.Read())
                {


                    RepAudiencias Audiencia = new RepAudiencias();

                    Audiencia.IdAudiencia = rdr.GetInt32(0);
                    Audiencia.Persona = rdr.GetString(1);
                    Audiencia.TipoVisita = rdr.GetString(2);
                    Audiencia.TipoAsunto = rdr.GetString(3);


                    if (!rdr.IsDBNull(rdr.GetOrdinal("Telefono")))
                        Audiencia.Telefono = rdr.GetString(4);


                    Audiencia.FechaIni = rdr.GetDateTime(5);
                    Audiencia.FechaFin = rdr.GetDateTime(6);

                    if (!rdr.IsDBNull(rdr.GetOrdinal("InfoAdicional")))
                        Audiencia.InfoAdicional = rdr.GetString(7);

                    if (!rdr.IsDBNull(rdr.GetOrdinal("URLFoto")))
                        Audiencia.URLFoto = rdr.GetString(8);


                    lblAudiencia0.Text = Audiencia.IdAudiencia.ToString();
                    lblPersona0.Text =  Audiencia.Persona;
                    lblTipoVisita0.Text =  Audiencia.TipoVisita;
                    lblTipoAsunto0.Text =  Audiencia.TipoAsunto;
                    lblTelefono0.Text =  Audiencia.Telefono;
                    lblFecha0.Text =  Audiencia.FechaIni + " - " + Audiencia.FechaFin;
                    lblInfoAdicional0.Text =  Audiencia.InfoAdicional;
                    imgFoto.ImageUrl = "http://200.79.183.187/Pictu/" + Audiencia.URLFoto;



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