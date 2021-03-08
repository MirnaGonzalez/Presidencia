using Presidencia.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presidencia
{
    public partial class ReservaPresidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["key"] != null)
                {
                    string key = Request.QueryString["key"];
                    hfIdAudiencia.Value = key;
                    iAgregar.InnerText = "Agregar Asistente";
                    divCalendario.Visible = false;
                        divFormulario.Visible = true;
                        llenarDatos(key);
                    btnAlta.Text = "Editar";
                    btnEliminarAudiencia.Visible = true;


                }
                else if (Request.QueryString["fecha"] != null)
                {
                    string fecha = Request.QueryString["fecha"];
                    divCalendario.Visible = false;
                    divFormulario.Visible = true;
                    txtFecha.Text = fecha;
                    btnAlta.Text = "Guardar";
                    btnEliminarAudiencia.Visible = false;


                    List<Personas> listaPersonas = new List<Personas>();
                    Session["listaPersonas"] = listaPersonas;

                    //List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;
                    if (listaPersonas == null)
                    {
                        List<Personas> listaPersona = new List<Personas>();
                        Session["listaPersonas"] = listaPersona;

                    }

                }



                //List<Personas> lista = new List<Personas> { new Personas ( 1, "Faustino", "Tapia", "Moya", 2, "" ) };
                //gridPersonas.DataSource = lista;
                //gridPersonas.DataBind();

                //// Attribute to show the Plus Minus Button.
                //gridPersonas.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                ////Attribute to hide column in Phone.
                //gridPersonas.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                //gridPersonas.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";

                ////Adds THEAD and TBODY to GridView.
                //gridPersonas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnAgregar_ServerClick(object sender, EventArgs e)
        {
            List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;

            if (iAgregar.InnerText == "Guardar")
            {
                var person = listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value));

                iAgregar.InnerText = " Agregar";


                if (person.URLFoto == "" || person.URLFoto == null)
                {
                    if (fuImage.HasFile)
                    {
                        try
                        {

                            string DirCarpetaNExpe = "Imagenes/";
                            string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                            Stream stream = new MemoryStream(fuImage.FileBytes);
                            bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                            if (ArchivoCreado)
                            {
                                listaPersonas.Remove(person);
                                //LblAdjuntar.Text = "El archivo se guardó correctamente.";
                                Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo };
                                listaPersonas.Add(personas);
                                Session["listaPersonas"] = listaPersonas;
                                gridPersonas.DataSource = listaPersonas;
                                gridPersonas.DataBind();
                                VaciarPersona();

                            }
                        }
                        catch (Exception ex)
                        {
                            LblAdjuntar.Text = "Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.";
                        }
                    }
                    else
                    {
                        //LblAdjuntar.Text = "Seleccione el archivo a guardar.";
                        listaPersonas.Remove(person);
                        Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim() };
                        listaPersonas.Add(personas);
                        Session["listaPersonas"] = listaPersonas;
                        gridPersonas.DataSource = listaPersonas;
                        gridPersonas.DataBind();
                        VaciarPersona();
                    }
                }
                else
                {
                    string DirCarpetaNExpe = "Imagenes/";
                    bool ArchivoEliminado = NArchivosFTP.EliminarArchivo(DirCarpetaNExpe, person.URLFoto);

                    if (fuImage.HasFile)
                    {
                        try
                        {

                            string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                            Stream stream = new MemoryStream(fuImage.FileBytes);
                            bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                            if (ArchivoCreado)
                            {
                                listaPersonas.Remove(person);
                                //LblAdjuntar.Text = "El archivo se guardó correctamente.";
                                Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo };
                                listaPersonas.Add(personas);
                                Session["listaPersonas"] = listaPersonas;
                                gridPersonas.DataSource = listaPersonas;
                                gridPersonas.DataBind();
                                VaciarPersona();

                            }
                        }
                        catch (Exception ex)
                        {
                            LblAdjuntar.Text = "Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.";
                        }
                    }
                    else
                    {
                        //LblAdjuntar.Text = "Seleccione el archivo a guardar.";
                        listaPersonas.Remove(person);
                        Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim() };
                        listaPersonas.Add(personas);
                        Session["listaPersonas"] = listaPersonas;
                        gridPersonas.DataSource = listaPersonas;
                        gridPersonas.DataBind();
                        VaciarPersona();
                    }
                }

            }
            else if (iAgregar.InnerText== "Modificar")
            {
              //  var person = listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value));
                var person = listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value));

                iAgregar.InnerText = "Agregar Asistente";

                if (person.URLFoto == "" || person.URLFoto == null)
                {
                    if (fuImage.HasFile)
                    {
                        try
                        {

                            string DirCarpetaNExpe = "Imagenes/";
                            string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                            Stream stream = new MemoryStream(fuImage.FileBytes);
                            bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                            if (ArchivoCreado)
                            {

                                //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).Nombre = txt_Nombre.Text.Trim();
                                //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).APaterno = txt_AP.Text.Trim();
                                //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).AMaterno = txt_AM.Text.Trim();
                                //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).URLFoto = NombreArchivo;


                                listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).Nombre = txt_Nombre.Text.Trim();
                                listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).APaterno = txt_AP.Text.Trim();
                                listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).AMaterno = txt_AM.Text.Trim();
                                listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).URLFoto = NombreArchivo;


                                // listaPersonas.Remove(person);
                                //LblAdjuntar.Text = "El archivo se guardó correctamente.";
                                // Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo };
                                //listaPersonas.Add(personas);
                                bool realizado = false;
                                Personas.ModificarPersona(listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)), ref realizado);

                                Session["listaPersonas"] = listaPersonas;
                                gridModificar.DataSource = listaPersonas;
                                gridModificar.DataBind();
                                VaciarPersona();

                            }
                        }
                        catch (Exception ex)
                        {
                            LblAdjuntar.Text = "Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.";
                        }
                    }
                    else
                    {
                        //LblAdjuntar.Text = "Seleccione el archivo a guardar.";
                        // listaPersonas.Remove(person);
                        //Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim() };


                        // listaPersonas.Add(personas);


                        //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).Nombre = txt_Nombre.Text.Trim();
                        //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).APaterno = txt_AP.Text.Trim();
                        //listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)).AMaterno = txt_AM.Text.Trim();

                        listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).Nombre = txt_Nombre.Text.Trim();
                        listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).APaterno = txt_AP.Text.Trim();
                        listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)).AMaterno = txt_AM.Text.Trim();

                        // listaPersonas.Remove(person);
                        //LblAdjuntar.Text = "El archivo se guardó correctamente.";
                        // Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo };
                        //listaPersonas.Add(personas);
                        bool realizado = false;
                      //  Personas.ModificarPersona(listaPersonas.ElementAt(int.Parse(hfIndexSeleccionado.Value)), ref realizado);
                        Personas.ModificarPersona(listaPersonas.Find(x => x.IdPersona == int.Parse(hfIndexSeleccionado.Value)), ref realizado);

                        Session["listaPersonas"] = listaPersonas;
                        gridModificar.DataSource = listaPersonas;
                        gridModificar.DataBind();
                        VaciarPersona();
                    }
                }
                else
                {
                    string DirCarpetaNExpe = "Imagenes/";
                    bool ArchivoEliminado = NArchivosFTP.EliminarArchivo(DirCarpetaNExpe, person.URLFoto);

                    if (fuImage.HasFile)
                    {
                        try
                        {

                            string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                            Stream stream = new MemoryStream(fuImage.FileBytes);
                            bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                            if (ArchivoCreado)
                            {
                                listaPersonas.Remove(person);
                                //LblAdjuntar.Text = "El archivo se guardó correctamente.";
                                Personas personas = new Personas { IdPersona= int.Parse(hfIndexSeleccionado.Value), Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo };
                                listaPersonas.Add(personas);
                                bool realizado = false;
                                Personas.ModificarPersona(personas, ref realizado);
                                Session["listaPersonas"] = listaPersonas;
                                gridModificar.DataSource = listaPersonas;
                                gridModificar.DataBind();
                                VaciarPersona();

                            }
                        }
                        catch (Exception ex)
                        {
                            LblAdjuntar.Text = "Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.";
                        }
                    }
                    else
                    {
                        //LblAdjuntar.Text = "Seleccione el archivo a guardar.";
                        listaPersonas.Remove(person);
                        Personas personas = new Personas { IdPersona = int.Parse(hfIndexSeleccionado.Value), Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim() };
                        listaPersonas.Add(personas);
                        bool realizado = false;
                        Personas.ModificarPersona(personas, ref realizado);
                        Session["listaPersonas"] = listaPersonas;
                        gridModificar.DataSource = listaPersonas;
                        gridModificar.DataBind();
                        VaciarPersona();
                    }
                }

            }
            else if (iAgregar.InnerText == "Agregar Asistente")
            {

                string mensaje = ValidarPersona();

                if (mensaje == "")
                {
                    if (fuImage.HasFile)
                    {
                        try
                        {

                            string DirCarpetaNExpe = "Imagenes/";
                            string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                            Stream stream = new MemoryStream(fuImage.FileBytes);
                            bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                            if (ArchivoCreado)
                            {

                                Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo, IdAudiencia = int.Parse(hfIdAudiencia.Value) };
                                listaPersonas.Add(personas);
                                bool realizado = false;
                                Personas.AgregarPersona(personas, ref realizado);
                                Session["listaPersonas"] = listaPersonas;
                                gridModificar.DataSource = listaPersonas;
                                gridModificar.DataBind();
                                VaciarPersona();



                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        //LblAdjuntar.Text = "Seleccione el archivo a guardar.";
                        Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), IdAudiencia = int.Parse(hfIdAudiencia.Value) };
                        bool realizado = false;
                        Personas.AgregarPersona(personas, ref realizado);
                        listaPersonas.Add(personas);
                        Session["listaPersonas"] = listaPersonas;
                        gridModificar.DataSource = listaPersonas;
                        gridModificar.DataBind();
                        VaciarPersona();


                    }
                }
                else
                {
                    MensajeAlerta.AlertaValidacion(this, mensaje);

                }


            }

            else
            {

                string mensaje = ValidarPersona();

                if (mensaje == "")
                {
                    if (fuImage.HasFile)
                    {
                        try
                        {

                            string DirCarpetaNExpe = "Imagenes/";
                            string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                            Stream stream = new MemoryStream(fuImage.FileBytes);
                            bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                            if (ArchivoCreado)
                            {
                                LblAdjuntar.Text = "El archivo se guardó correctamente.";

                                Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim(), URLFoto = NombreArchivo };
                                listaPersonas.Add(personas);
                                Session["listaPersonas"] = listaPersonas;
                                gridPersonas.DataSource = listaPersonas;
                                gridPersonas.DataBind();
                                VaciarPersona();



                            }
                        }
                        catch (Exception ex)
                        {
                            LblAdjuntar.Text = "Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.";
                        }
                    }
                    else
                    {
                        //LblAdjuntar.Text = "Seleccione el archivo a guardar.";
                        Personas personas = new Personas { Nombre = txt_Nombre.Text.Trim(), APaterno = txt_AP.Text.Trim(), AMaterno = txt_AM.Text.Trim() };
                        listaPersonas.Add(personas);
                        Session["listaPersonas"] = listaPersonas;
                        gridPersonas.DataSource = listaPersonas;
                        gridPersonas.DataBind();
                        VaciarPersona();


                    }
                }
                else
                {
                    MensajeAlerta.AlertaValidacion(this, mensaje);

                }
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string mensaje = ValidarPersona();

            if (mensaje=="")
            {
                if (fuImage.HasFile)
                {
                    try
                    {

                        string DirCarpetaNExpe = "Imagenes/";
                        string NombreArchivo = $"{Path.GetFileNameWithoutExtension(fuImage.FileName)}_{DateTime.Now.Day.ToString("00")}{DateTime.Now.Month.ToString("00")}{DateTime.Now.Year.ToString()}{Path.GetExtension(this.fuImage.FileName)}";

                        Stream stream = new MemoryStream(fuImage.FileBytes);
                        bool ArchivoCreado = NArchivosFTP.CrearArchivoPDF(stream, DirCarpetaNExpe + NombreArchivo);

                        if (ArchivoCreado)
                        {
                            // LblAdjuntar.Text = "El archivo se guardó correctamente.";
                            string msj = "<b>* El archivo se guardó correctamente.</b> <br>";

                            MensajeAlerta.AlertaValidacion(this, msj);
                        }                      
                    }
                    catch (Exception ex)
                    {
                      string  msj = "<b>* Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.</b> <br>";
                        MensajeAlerta.AlertaValidacion(this, msj);
                        //  LblAdjuntar.Text = "Ocurrió un ploblema al guardar el documento. Por favor intente mas tarde.";
                    }
                }
                else
                    LblAdjuntar.Text = "Seleccione el archivo a guardar.";
            }
            else
            {
                MensajeAlerta.AlertaValidacion(this, mensaje);

            }

           
        }


        string ValidarPersona()
        {
            
            string mensaje = "";

            if (string.IsNullOrWhiteSpace(txt_Nombre.Text))
                mensaje += "<b>* Nombre.</b> <br>";

            if (string.IsNullOrWhiteSpace(txt_AP.Text))
                mensaje += "<b>* Apellido Paterno.</b> <br>";

            if (string.IsNullOrWhiteSpace(txt_AM.Text))
                mensaje += "<b>* Apellido Materno.</b> <br>";
       
            return mensaje;
        }
        void VaciarPersona()
        {
            txt_Nombre.Text = "";
            txt_AP.Text = "";
            txt_AM.Text = "";

        }

        string ValidarInsert()
        {
            DateTime fechaInicio;
            DateTime fechaFin;

            List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;
            string mensaje = "";

            if (listaPersonas.Count==0)          
                mensaje += "<b>* Ingrese datos de la persona.</b> <br>";

            if (ddlTipoVisita.SelectedValue=="SN")
                mensaje += "<b>* Tipo de visita.</b> <br>";

            if (ddlTipoAsunto.SelectedValue == "SN")
                mensaje += "<b>* Tipo de asunto.</b> <br>";

            if (string.IsNullOrWhiteSpace(txtTel.Text))
                mensaje += "<b>* Telefono.</b> <br>";

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
                    List<Audiencias> lista = Audiencias.FechasReservadarxDia(fecha, ref realizada);

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

        string ValidarModificar()
        {
            DateTime fechaInicio;
            DateTime fechaFin;

            List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;
            string mensaje = "";

            if (listaPersonas.Count == 0)
                mensaje += "<b>* Ingrese datos de la persona.</b> <br>";

            if (ddlTipoVisita.SelectedValue == "SN")
                mensaje += "<b>* Tipo de visita.</b> <br>";

            if (ddlTipoAsunto.SelectedValue == "SN")
                mensaje += "<b>* Tipo de asunto.</b> <br>";

            if (string.IsNullOrWhiteSpace(txtTel.Text))
                mensaje += "<b>* Telefono.</b> <br>";

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
                    int IdReserva = int.Parse(hfIdAudiencia.Value);
                    bool realizada = false;
                    List<Audiencias> lista = Audiencias.FechasReservadarxDiaId(fecha, IdReserva, ref realizada);

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



        void vaciarElementos()
        {
            txt_Nombre.Text = "";
            txt_AP.Text = "";
            txt_AM.Text = "";
            txtFecha.Text = "";
            txtHoraFinal.Text = "";
            txtHoraInicio.Text = "";
            txt_informacion.Text = "";
            txtTel.Text = "";
            ddlTipoAsunto.SelectedIndex = 0;
            ddlTipoVisita.SelectedIndex = 0;
            List<Personas> listaPersonas = new List<Personas>();
            Session["listaPersonas"] = listaPersonas;
            gridModificar.DataSource = null;
            gridModificar.DataBind();
            gridPersonas.DataSource = null;
            gridPersonas.DataBind();

        }

        protected void gridPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            index = Convert.ToInt32(e.CommandArgument);
            row = grid.Rows[index];

            switch (e.CommandName)
            {
                case "Modificar":
                    hfIndexSeleccionado.Value = index.ToString();
                    VaciarPersona();                
                    var person = listaPersonas.ElementAt(index);
                    txt_Nombre.Text = person.Nombre;
                    txt_AP.Text = person.APaterno;
                    txt_AM.Text = person.AMaterno;
                    iAgregar.InnerText = "Guardar";
                    break;
                case "Eliminar":
                    if (listaPersonas.Count > 1)
                    {
                        hfIndexSeleccionado.Value = index.ToString();
                        VaciarPersona();
                        var per = listaPersonas.ElementAt(index);
                        listaPersonas.Remove(per);
                        gridPersonas.DataSource = listaPersonas;
                        gridPersonas.DataBind();
                    }
                    else
                        MensajeAlerta.AlertaAviso(this, "Aviso", "No puede eliminar a todos los asistentes");
                    break;

            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (btnAlta.Text=="Guardar")
            {
                string mensaje = ValidarInsert();
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

                    Audiencias audiencia = new Audiencias { TipoVisita = ddlTipoVisita.SelectedValue, TipoAsunto = ddlTipoAsunto.SelectedValue, FechaIni = fechaInicial, FechaFin = fechaFinal, Telefono = txtTel.Text, InfoAdicional = txt_informacion.Text.Trim() };
                    List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;
                    bool realizado = false;
                    Audiencias.NuevaAudiencia(audiencia, listaPersonas, ref realizado);

                    if (realizado)
                    {
                        MensajeAlerta.AlertaSatisfactorio(this, "Registro Exitoso.");
                        vaciarElementos();
                        divCalendario.Visible = true;
                        divFormulario.Visible = false;
                    }
                    else
                        MensajeAlerta.AlertaAviso(this, "Aviso", "Error al insertar.");


                }
                else
                {
                    MensajeAlerta.AlertaValidacion(this, mensaje);
                }
            }
            else
            {
                string mensaje = ValidarModificar();
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

                    Audiencias audiencia = new Audiencias { IdAudiencia= int.Parse(hfIdAudiencia.Value), TipoVisita = ddlTipoVisita.SelectedValue, TipoAsunto = ddlTipoAsunto.SelectedValue, FechaIni = fechaInicial, FechaFin = fechaFinal, Telefono = txtTel.Text, InfoAdicional = txt_informacion.Text.Trim() };
                    bool realizado = false;
                    Audiencias.EditarAudiencia(audiencia, ref realizado);

                    if (realizado)
                    {
                        MensajeAlerta.AlertaSatisfactorio(this, "Edición Exitosa.");
                        vaciarElementos();
                        divCalendario.Visible = true;
                        divFormulario.Visible = false;
                    }
                    else
                        MensajeAlerta.AlertaAviso(this, "Aviso", "Error al insertar.");


                }
                else
                {
                    MensajeAlerta.AlertaValidacion(this, mensaje);
                }

            }

        }

     
     void   llenarDatos(string id)
        {

            Audiencias audiencias = new Audiencias();
            bool realizado = false;
            audiencias = Audiencias.AudienciaXId(id, ref realizado);

            txt_Nombre.Text = "";
            txt_AP.Text = "";
            txt_AM.Text = "";
            txtFecha.Text = audiencias.FechaIni.ToString("yyyy-MM-dd");
            txtHoraFinal.Text = audiencias.FechaFin.ToString("HH:mm");
            txtHoraInicio.Text = audiencias.FechaIni.ToString("HH:mm");
            txt_informacion.Text = audiencias.InfoAdicional;
            txtTel.Text = audiencias.Telefono;
            ddlTipoAsunto.SelectedValue = audiencias.TipoAsunto.ToUpper();
            ddlTipoVisita.SelectedValue = audiencias.TipoVisita.ToUpper();
            List<Personas> listaPersonas = new List<Personas>();
            listaPersonas = Personas.PersonasXIdAudiencia(id, ref realizado);
            gridModificar.DataSource = listaPersonas;
            gridModificar.DataBind();
            Session["listaPersonas"] = listaPersonas;

        }

        protected void gridModificar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            List<Personas> listaPersonas = Session["listaPersonas"] as List<Personas>;
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            index = Convert.ToInt32(e.CommandArgument);
            int idPer = listaPersonas.ElementAt(index).IdPersona;
            row = grid.Rows[index];

            switch (e.CommandName)
            {
                case "Modificar":
                    hfIndexSeleccionado.Value = idPer.ToString();
                    VaciarPersona();
                    var person = listaPersonas.ElementAt(index);
                    txt_Nombre.Text = person.Nombre;
                    txt_AP.Text = person.APaterno;
                    txt_AM.Text = person.AMaterno;
                    iAgregar.InnerText = "Modificar";
                    break;
                case "Eliminar":
                    if (listaPersonas.Count > 1)
                    {
                        hfIndexSeleccionado.Value = index.ToString();
                        VaciarPersona();
                        var per = listaPersonas.ElementAt(index);
                        bool resultado = false;
                        Personas.EliminarPersona(per.IdPersona, ref resultado);
                        listaPersonas.Remove(per);
                        gridModificar.DataSource = listaPersonas;
                        gridModificar.DataBind();
                    }
                    else
                        MensajeAlerta.AlertaAviso(this, "Aviso", "No puede eliminar a todos los asistentes");
                    break;

            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            vaciarElementos();
            divCalendario.Visible = true;
            divFormulario.Visible = false;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            vaciarElementos();
            divCalendario.Visible = true;
            divFormulario.Visible = false;
        }

        protected void btnEliminarAudiencia_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            Audiencias.EliminarAudienciaTotal(int.Parse(hfIdAudiencia.Value), ref resultado);
            if (resultado)
            {
                MensajeAlerta.AlertaSatisfactorio(this, "Eliminación Exitosa.");
                vaciarElementos();
                divCalendario.Visible = true;
                divFormulario.Visible = false;

            }
            else
                MensajeAlerta.AlertaAviso(this, "Aviso", "No puede eliminar la audiencia.");

        }

        protected void LinkDetalle_Click(object sender, EventArgs e)
        {
            Session["IdAudiencia"] = hfIdAudiencia.Value;
            Response.Redirect("ConsAudienciaFoto.aspx");

        }
    }
}