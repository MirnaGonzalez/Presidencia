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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Exportar_Click(object sender, EventArgs e)
        {

            //List<RepReservas> listaReservas = new List<RepReservas>();


            //listaReservas = Page.Session["listaReservas"];

            //string _open = "window.open('MostrarReporteDepreciacion.aspx', '_blank');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<RepReservas> listaReservas = new List<RepReservas>();

            string IdReserva = txtNumReserva.Text;
            string Evento = txtNombreEvento.Text;
            string FechaIni = txtFechaIni.Text;
            string FechaFin = txtFechaFin.Text;


            SqlConnection cnn = new SqlConnection(CConexion.Obtener());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            string qry = @"SELECT IdReserva, Evento, FechaIni, FechaFin, InfoAdicional FROM ReservasAuditorio WHERE (FechaIni BETWEEN @FechaIni AND @FechaFin ) ";

            if (IdReserva != "")
            {
                qry += " AND IdReserva = '" + IdReserva + "' ";
            }

            if (Evento != "")
            {
                qry += " AND (Evento LIKE '%" + Evento + "%') ";
            }

            qry += " ORDER BY FechaIni ASC ";


            cmd.Connection = cnn;
            cmd.CommandText = qry;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@fechaIni", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaIni);
            cmd.Parameters.Add("@fechaFin", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaFin);

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

                LblTotal.Text = gridReservas.Rows.Count.ToString();
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

            }
        }
    }
}