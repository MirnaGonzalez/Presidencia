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
    public partial class ReporteAudiencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFechaIni.Text = "01/02/2021";
            txtFechaFin.Text = "28/05/2021";
        }

        protected void BtnExportar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<RepAudiencias> listaAudiencias = new List<RepAudiencias>();


            string IdAudiencia = txtNumAudiencia.Text ;
            string Persona = txtNombrePersona.Text;
            string TipoVisita = ddlTipoVisita.SelectedValue;
            string TipoAsunto = ddlTipoAsunto.SelectedValue;
            string FechaIni = txtFechaIni.Text;
            string FechaFin = txtFechaFin.Text;

        

            string qry = "";


            SqlConnection cnn = new SqlConnection(CConexion.Obtener());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;


            if (FechaIni == "")
            {
                MensajeAlerta.AlertaAviso(this, "Alerta!", "Seleccione un rango de fechas");
            }


            else
            {

                 qry = @"SELECT IdAudiencia, Persona, TipoVisita, TipoAsunto, Telefono, FechaIni, FechaFin, InfoAdicional FROM vta_ReporteAudiencias WHERE (FechaIni BETWEEN   @FechaIni   AND @FechaFin ) ";

                if (IdAudiencia != "")
                {
                    qry += " AND IdAudiencia = '" + IdAudiencia + "' ";
                }

                if (Persona != "")
                {
                    qry += " AND (Persona LIKE '%" + Persona + "%') ";
                }

                if (TipoVisita != "")
                {
                    qry += " AND (TipoVisita = '" + TipoVisita + "') ";
                }

                if (TipoAsunto != "")
                {
                    qry += " AND (TipoAsunto = '" + TipoAsunto + "') ";
                }

                qry += " ORDER BY FechaIni ASC ";

            }


            cmd.Connection = cnn;
            cmd.CommandText = qry;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@fechaIni", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaIni);
            cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaFin);

            cmd.Parameters.Add("@IdAudiencia", System.Data.SqlDbType.VarChar, 100).Value = IdAudiencia;
            cmd.Parameters.Add("@Persona", System.Data.SqlDbType.VarChar, 250).Value = Persona;
            cmd.Parameters.Add("@TipoVisita", System.Data.SqlDbType.VarChar, 50).Value = TipoVisita;
            cmd.Parameters.Add("@TipoAsunto", System.Data.SqlDbType.VarChar, 50).Value = TipoAsunto;

            cmd.Connection = cnn;
            adp.SelectCommand = cmd;
            
          

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
                while (rdr.Read())
                {


                    RepAudiencias Audiencias = new RepAudiencias();
                    Audiencias.IdAudiencia = rdr.GetInt32(0);
                    Audiencias.Persona = rdr.GetString(1);
                    Audiencias.TipoVisita = rdr.GetString(2);
                    Audiencias.TipoAsunto = rdr.GetString(3);
                    

                    if (!rdr.IsDBNull(rdr.GetOrdinal("Telefono")))
                        Audiencias.Telefono = rdr.GetString(4);


                    Audiencias.FechaIni = rdr.GetDateTime(5);
                    Audiencias.FechaFin = rdr.GetDateTime(6);
                    
                    if (!rdr.IsDBNull(rdr.GetOrdinal("InfoAdicional")))
                    Audiencias.InfoAdicional = rdr.GetString(7);

                    listaAudiencias.Add(Audiencias);         
                }  
                cnn.Close();
               
                gridAudiencias.DataSource=listaAudiencias;
                gridAudiencias.DataBind();
                LblTotal.Text = gridAudiencias.Rows.Count.ToString();
                DivMostrar.Visible = true;
               

                if (gridAudiencias.Rows.Count == 0)
                {
                    MensajeAlerta.AlertaAviso(this, "Alerta!", " No existen datos con la búsqueda solicitada");
                }

            }
            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();


                MensajeAlerta.AlertaAviso(this, "Error", "Error :" + ex.Message);

                //Alerta2.Visible = true;
                //Password.Text = "";
                //  Response.Redirect("404.aspx");

            }




        }
    }
}