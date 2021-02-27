using Presidencia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presidencia
{
    public partial class ReservaAuditorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string javaScript = "myFunction();";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                //string strUserAgent = Request.UserAgent.ToString().ToLower();

                //if (strUserAgent != null)
                //{
                //    if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                //    strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                //    strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                //    strUserAgent.Contains("palm"))
                //    {
                //        //Response.Redirect("http://www.m.tuweb.com/");

                //    }
                //} 
            }
          //  ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "cal", "$('#calendar').fullCalendar('refetchEventSources', 'http://serviciowebpjhgo.azurewebsites.net/Api/CitasAP')", true);


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "edit", "$('[id*='btnEditar']').css('visibility', 'hidden');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "edit", "$('[id*='btnEliminar']').css('visibility', 'hidden');", true);

            //btnEditar.Visible = false;
            //btnEliminar.Visible = false;
            string mensaje = ValidarRegistro();

            if (mensaje == "")
            {
                DateTime fechaInicio = Convert.ToDateTime(txtHoraInicio.Text);
                var horaInicio = fechaInicio.Hour;
                var minutosInicio = fechaInicio.Minute;

                DateTime fechaFin = Convert.ToDateTime(txtHoraFinal.Text);
                var horaFin = fechaFin.Hour;
                var minutosFin = fechaFin.Minute;

                DateTime fechaInicial = DateTime.Parse(txtFecha.Text).AddHours(horaInicio).AddMinutes(minutosInicio);
                DateTime fechaFinal = DateTime.Parse(txtFecha.Text).AddHours(horaFin).AddMinutes(minutosFin);
  
                ReservaAudi reservanueva = new ReservaAudi(txtNombreEvento.Text, fechaInicial, fechaFinal, txtInformacion.Text);
                bool esCorrecto = false;
                reservanueva.ReservarFecha(ref esCorrecto);

                if (esCorrecto)
                {
                    VaciarRecuadros();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#exampleModal').modal('hide');", true);
                    MensajeAlerta.AlertaSatisfactorio(this, "Registro Exitoso.");
                    // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "window.location.reload()", true);
                    // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "recargar();", true);
                }
            }
            else
            {
                MensajeAlerta.AlertaValidacion(this, mensaje);

            }
        }




        string ValidarRegistro()
        {
            DateTime fechaInicio;
            DateTime fechaFin ;

            string mensaje = "";

            if (string.IsNullOrWhiteSpace(txtNombreEvento.Text))
                mensaje += "<b>* Nombre del evento.</b> <br>";

            if (string.IsNullOrWhiteSpace(txtFecha.Text))
                mensaje += "<b>* Fecha.</b> <br>";
           
            if (string.IsNullOrWhiteSpace(txtHoraInicio.Text))
                mensaje += "<b>* Hora Inicial.</b> <br>";
          


            if (string.IsNullOrWhiteSpace(txtHoraFinal.Text))
                mensaje += "<b>* Hora Final.</b> <br>";
           
               
            

            if (!string.IsNullOrWhiteSpace(txtHoraInicio.Text) && !string.IsNullOrWhiteSpace(txtHoraFinal.Text))
            {
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);

                fechaInicio = Convert.ToDateTime(txtHoraInicio.Text);
                fechaFin = Convert.ToDateTime(txtHoraFinal.Text);

                if (fechaInicio > fechaFin)
                {
                    mensaje += "<b>* Hora Final es menor a Hora inicial.</b> <br>";

                }
                else
                {
                    bool realizada = false;
                  List<ReservaAudi> lista =  ReservaAudi.FechasReservadarxDia(fecha, ref realizada);

                    if (realizada && lista.Count>0)
                    {
                        for (int i = 0; i < lista.Count; i++)
                        {

                            var horaInicio = fechaInicio.Hour;
                            var minutosInicio = fechaInicio.Minute;

                            var horaFin = fechaFin.Hour;
                            var minutosFin = fechaFin.Minute;

                            DateTime fechaInicial = DateTime.Parse(txtFecha.Text).AddHours(horaInicio).AddMinutes(minutosInicio);
                            DateTime fechaFinal = DateTime.Parse(txtFecha.Text).AddHours(horaFin).AddMinutes(minutosFin);

                            DateTime fechaInicial2 = lista.ElementAt(i).FechaIni;
                            DateTime fechaFinal2 = lista.ElementAt(i).FechaFin;


                            if ((fechaInicial2 >= fechaInicial) && (fechaInicial2 <= fechaFinal))
                            {
                                mensaje += "<b>* Hora inicial ya reservada.</b> <br>";
                                break;
                            }                         
                            else if ((fechaFinal2 >= fechaInicial) && (fechaFinal2 <= fechaFinal))
                            {
                                mensaje += "<b>* Hora final ya reservada.</b> <br>";
                                break;
                            }
                            else if ((fechaInicial >= fechaInicial2) && (fechaFinal <= fechaFinal2))
                            {
                                mensaje += "<b>* Hora inicial ya reservada.</b> <br>";
                                break;
                            }
                            else if ((fechaFinal >= fechaInicial2) && (fechaFinal <= fechaFinal2))
                            {
                                mensaje += "<b>* Hora final ya reservada.</b> <br>";
                                break;
                            }
                      }
                    }

                }
            }
                return mensaje;
        }

        string ValidarEditar()
        {
            DateTime fechaInicio;
            DateTime fechaFin;

            string mensaje = "";

            if (string.IsNullOrWhiteSpace(txtNombreEvento.Text))
                mensaje += "<b>* Nombre del evento.</b> <br>";

            if (string.IsNullOrWhiteSpace(txtFecha.Text))
                mensaje += "<b>* Fecha.</b> <br>";

            if (string.IsNullOrWhiteSpace(txtHoraInicio.Text))
                mensaje += "<b>* Hora Inicial.</b> <br>";



            if (string.IsNullOrWhiteSpace(txtHoraFinal.Text))
                mensaje += "<b>* Hora Final.</b> <br>";




            if (!string.IsNullOrWhiteSpace(txtHoraInicio.Text) && !string.IsNullOrWhiteSpace(txtHoraFinal.Text))
            {
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);

                fechaInicio = Convert.ToDateTime(txtHoraInicio.Text);
                fechaFin = Convert.ToDateTime(txtHoraFinal.Text);

                if (fechaInicio > fechaFin)
                {
                    mensaje += "<b>* Hora Final es menor a Hora inicial.</b> <br>";

                }
                else
                {
                    int IdReserva = int.Parse(hiddenIdReserva.Value);
                    bool realizada = false;
                    List<ReservaAudi> lista = ReservaAudi.FechasReservadarxDiaId(fecha, IdReserva, ref realizada);

                    if (realizada && lista.Count > 0)
                    {
                        for (int i = 0; i < lista.Count; i++)
                        {

                            var horaInicio = fechaInicio.Hour;
                            var minutosInicio = fechaInicio.Minute;

                            var horaFin = fechaFin.Hour;
                            var minutosFin = fechaFin.Minute;

                            DateTime fechaInicial = DateTime.Parse(txtFecha.Text).AddHours(horaInicio).AddMinutes(minutosInicio);
                            DateTime fechaFinal = DateTime.Parse(txtFecha.Text).AddHours(horaFin).AddMinutes(minutosFin);

                            DateTime fechaInicial2 = lista.ElementAt(i).FechaIni;
                            DateTime fechaFinal2 = lista.ElementAt(i).FechaFin;


                            if ((fechaInicial2 >= fechaInicial) && (fechaInicial2 <= fechaFinal))
                            {
                                mensaje += "<b>* Hora inicial ya reservada.</b> <br>";
                                break;
                            }
                            else if ((fechaFinal2 >= fechaInicial) && (fechaFinal2 <= fechaFinal))
                            {
                                mensaje += "<b>* Hora final ya reservada.</b> <br>";
                                break;
                            }
                            else if ((fechaInicial >= fechaInicial2) && (fechaFinal <= fechaFinal2))
                            {
                                mensaje += "<b>* Hora inicial ya reservada.</b> <br>";
                                break;
                            }
                            else if ((fechaFinal >= fechaInicial2) && (fechaFinal <= fechaFinal2))
                            {
                                mensaje += "<b>* Hora final ya reservada.</b> <br>";
                                break;
                            }
                        }
                    }

                }
            }
            return mensaje;
        }

        void VaciarRecuadros()
        {
            txtNombreEvento.Text = "";
            txtFecha.Text = "";
            txtHoraFinal.Text = "";
            txtHoraInicio.Text = "";
            txtInformacion.Text = "";
        }
     void llenarRecuadros(string Nombre, string fecha, string fechaini, string fechaFin , string informacion)
        {
            txtNombreEvento.Text = Nombre;
            txtFecha.Text = fecha;
            txtHoraFinal.Text = fechaini;
            txtHoraInicio.Text = fechaFin;
            txtInformacion.Text = informacion;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            VaciarRecuadros();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#exampleModal').modal('hide');", true);
        }





        protected void btnBucarId_Click(object sender, EventArgs e)
        {

            int IdReserva = int.Parse(hiddenIdReserva.Value);
            bool esRealizada = false;
            List<ReservaAudi> reservas = ReservaAudi.ObtenerReservaxId(IdReserva, ref esRealizada);

            if (reservas.Count > 0)
            {
                var reserva = reservas.FirstOrDefault();
                VaciarRecuadros();
                llenarRecuadros(reserva.Evento, reserva.FechaIni.ToString(), reserva.FechaIni.ToString(), reserva.FechaFin.ToString(), reserva.InfoAdicional);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Pop", " $('[id*='examplemodal']').modal('show');", true);

            }
            else
            {
                // No encontro resultados

            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "edit", "$('[id*='btnGuardar']').css('visibility', 'hidden');", true);
          //  btnGuardar.Visible = false;

            int IdReserva = int.Parse(hiddenIdReserva.Value);
            string mensaje = ValidarEditar();

            if (mensaje == "")
            {
                DateTime fechaInicio = Convert.ToDateTime(txtHoraInicio.Text);
                var horaInicio = fechaInicio.Hour;
                var minutosInicio = fechaInicio.Minute;

                DateTime fechaFin = Convert.ToDateTime(txtHoraFinal.Text);
                var horaFin = fechaFin.Hour;
                var minutosFin = fechaFin.Minute;

                DateTime fechaInicial = DateTime.Parse(txtFecha.Text).AddHours(horaInicio).AddMinutes(minutosInicio);
                DateTime fechaFinal = DateTime.Parse(txtFecha.Text).AddHours(horaFin).AddMinutes(minutosFin);

                ReservaAudi reservanueva = new ReservaAudi(IdReserva,txtNombreEvento.Text, fechaInicial, fechaFinal, txtInformacion.Text);
                bool esCorrecto = false;
                reservanueva.EditarReservaxId(ref esCorrecto);

                if (esCorrecto)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#exampleModal').modal('hide');", true);
                    MensajeAlerta.AlertaSatisfactorio(this, "Registro Exitoso.");
                    VaciarRecuadros();
                    // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "window.location.reload()", true);
                    // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "recargar();", true);

                }
            }
            else
            {
                MensajeAlerta.AlertaValidacion(this, mensaje);


                
                
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int IdReserva = int.Parse(hiddenIdReserva.Value);

                ReservaAudi reservanueva = new ReservaAudi();

                reservanueva.IdReserva = IdReserva;
                bool esCorrecto = false;
                reservanueva.EliminarReservaxId(ref esCorrecto);

                if (esCorrecto)
                {
                VaciarRecuadros();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#exampleModal').modal('hide');", true);
                    MensajeAlerta.AlertaSatisfactorio(this, "Eliminado Exitoso.");
                    // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "window.location.reload()", true);
                    // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "load", "recargar();", true);

                }
          
        }
    }
}