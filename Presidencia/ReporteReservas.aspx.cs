using Presidencia.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Presidencia
{
    public partial class ReporteReservas : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            txtFechaIni.Text = "01/01/2021";
            txtFechaFin.Text = "31/12/2090";
        }

     

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<RepReservas> listaReservas = new List<RepReservas>();

            string IdReserva = txtNumReserva.Text;
            string Evento = txtNombreEvento.Text;
            string FechaIni = txtFechaIni.Text;
            string FechaFin = txtFechaFin.Text;
            string qry = "";


            SqlConnection cnn = new SqlConnection(CConexion.Obtener());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            if (!string.IsNullOrWhiteSpace(FechaIni) && !string.IsNullOrWhiteSpace(FechaFin))
            {
              

                qry = @"SELECT IdReserva, Evento, FechaIni, FechaFin, InfoAdicional FROM ReservasAuditorio WHERE (FechaIni BETWEEN @FechaIni AND @FechaFin ) ";

                if (IdReserva != "")
                {
                    qry += " AND IdReserva = '" + IdReserva + "' ";
                }

                if (Evento != "")
                {
                    qry += " AND (Evento LIKE '%" + Evento + "%') ";
                }

                qry += " ORDER BY FechaIni ASC ";
            }
            else
            {
                MensajeAlerta.AlertaAviso(this, "Alerta!", "Seleccione un rango de fechas");
            }
        
               
          

            cmd.Connection = cnn;
            cmd.CommandText = qry;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@fechaIni", SqlDbType.DateTime).Value = FechaIni;  //Convert.ToDateTime(FechaIni);
            cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = FechaFin;    //Convert.ToDateTime(FechaFin);

            cmd.Parameters.Add("@IdReserva", System.Data.SqlDbType.VarChar, 100).Value = IdReserva;
            cmd.Parameters.Add("@Evento", System.Data.SqlDbType.VarChar, 250).Value = Evento;

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

                    RepReservas Reservas = new RepReservas();
                    Reservas.IdReserva = rdr.GetInt32(0);
                    Reservas.Evento = rdr.GetString(1);
                    Reservas.FechaIni = rdr.GetDateTime(2);
                    Reservas.FechaFin = rdr.GetDateTime(3);


                    if (!rdr.IsDBNull(rdr.GetOrdinal("InfoAdicional")))
                        Reservas.InfoAdicional = rdr.GetString(4);

                    listaReservas.Add(Reservas);
                }
                cnn.Close();

                gridReservas.DataSource = listaReservas;
                gridReservas.DataBind();

                LblTotal.Text = "Total de registros: " + gridReservas.Rows.Count.ToString();
                DivMostrar.Visible = true;

                Page.Session["listaReservas"] = listaReservas;


                if (gridReservas.Rows.Count == 0)
                {
                    MensajeAlerta.AlertaAviso(this, "Alerta!", " No existen datos con la búsqueda solicitada");
                }

            }


            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();

                //  Response.Redirect("404.aspx");

                MensajeAlerta.AlertaAviso(this, "Alerta!", "Seleccione un rango de fechas");

            }
        }

        protected void BtnExportar_Click(object sender, EventArgs e)
        {
             
                gridReservas.Width = Unit.Percentage(0);
                HttpResponse response = Response;
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                System.Web.UI.Page pageToRender = new System.Web.UI.Page();
                HtmlForm form = new HtmlForm();


                form.Controls.Add(gridReservas);
                pageToRender.Controls.Add(form);
                response.Clear();
                response.Buffer = true;
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=ReporteAudiencias.xls");
                response.Charset = "UTF-8";
                response.ContentEncoding = Encoding.Default;
                pageToRender.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();

                gridReservas.Width = Unit.Percentage(100);
                

        }






    }
}