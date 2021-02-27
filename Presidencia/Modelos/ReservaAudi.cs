using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Presidencia.Modelos
{
    public class ReservaAudi
    {
        public int IdReserva { get; set; }
        public string Evento { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string InfoAdicional { get; set; }

        public ReservaAudi(string evento, DateTime fechaIni, DateTime fechaFin, string infoAdicional)
        {
            Evento = evento;
            FechaIni = fechaIni;
            FechaFin = fechaFin;
            InfoAdicional = infoAdicional;
        }

        public ReservaAudi(int idReserva, string evento, DateTime fechaIni, DateTime fechaFin, string infoAdicional)
        {
            IdReserva = idReserva;
            Evento = evento;
            FechaIni = fechaIni;
            FechaFin = fechaFin;
            InfoAdicional = infoAdicional;
        }

        public ReservaAudi(DateTime fechaIni, DateTime fechaFin)
        {
            FechaIni = fechaIni;
            FechaFin = fechaFin;
        }

        public ReservaAudi()
        {
        }

        public  void ReservarFecha( ref bool Realizada)
        {

            SqlConnection connection = new SqlConnection(CConexion.Obtener());
            try
            {
                string insertarRegistro = @"[dbo].[stp_AgregarReservas]";

                connection.Open();

                SqlCommand command = new SqlCommand(insertarRegistro, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Evento", SqlDbType.VarChar)).Value = this.Evento;
                command.Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.DateTime)).Value = this.FechaIni;
                command.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime)).Value = this.FechaFin;
                command.Parameters.Add(new SqlParameter("@InfoAdicional", SqlDbType.VarChar)).Value = this.InfoAdicional;
                

                command.ExecuteScalar();

                connection.Close();
                Realizada = true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Realizada = false;
            }
        }

        public void EditarReservaxId(ref bool Realizada)
        {

            SqlConnection connection = new SqlConnection(CConexion.Obtener());
            try
            {
                string insertarRegistro = @"[dbo].[stp_ModificarReservas]";

                connection.Open();

                SqlCommand command = new SqlCommand(insertarRegistro, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@IdReserva", SqlDbType.Int)).Value = this.IdReserva;
                command.Parameters.Add(new SqlParameter("@Evento", SqlDbType.VarChar)).Value = this.Evento;
                command.Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.DateTime)).Value = this.FechaIni;
                command.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime)).Value = this.FechaFin;
                command.Parameters.Add(new SqlParameter("@InfoAdicional", SqlDbType.VarChar)).Value = this.InfoAdicional;


                command.ExecuteScalar();

                connection.Close();
                Realizada = true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Realizada = false;
            }
        }
        public void EliminarReservaxId(ref bool Realizada)
        {

            SqlConnection connection = new SqlConnection(CConexion.Obtener());
            try
            {
                string eliminarRegistro = @"[dbo].[stp_EliminarReservas]";

                connection.Open();

                SqlCommand command = new SqlCommand(eliminarRegistro, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@IdReserva", SqlDbType.Int)).Value = this.IdReserva;

                command.ExecuteScalar();

                connection.Close();
                Realizada = true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Realizada = false;
            }
        }
        public static List<ReservaAudi> ObtenerReservaxId(int IdReserva, ref bool Realizada)
        {
            string Url = "";
            var Json = "";

            List<ReservaAudi> reserva = new List<ReservaAudi>();
            Realizada = false;

            try
            {
                HttpClient Client = new HttpClient();
                    Url = CConexion.ObtenerWS() + $"CitasAP/{IdReserva}";
             

                HttpResponseMessage Message = Client.GetAsync(Url).Result;
                if (Message.IsSuccessStatusCode)
                {
                    Json = Message.Content.ReadAsStringAsync().Result;
                    reserva = JsonConvert.DeserializeObject<List<ReservaAudi>>(Json);


                    Realizada = true;
                   
                }
                else
                {
                    Realizada = false;
                }
            }
            catch (Exception)
            {
                Realizada = false;

            }

            return reserva;
        }

        public static  List<ReservaAudi> FechasReservadarxDia(DateTime fecha, ref bool realizada)
        {
            List<ReservaAudi> list = new List<ReservaAudi>();
            string cadena = CConexion.Obtener();
            string consulta = "";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlDataReader reader = null;
                consulta = $"Select  [FechaIni], [FechaFin]   from ReservasAuditorio where  year(FechaIni) = {fecha.Year} and month(FechaIni) = {fecha.Month} and day(FechaIni)= {fecha.Day}";
                SqlCommand comando = new SqlCommand(consulta, con);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ReservaAudi modelo = new ReservaAudi(reader.GetDateTime(0), reader.GetDateTime(1));

                    list.Add(modelo);
                }
                realizada = true;
                con.Close();
                return list;
            }
            catch (Exception)
            {
                realizada = false;
                return list;

            }

        }

        public static List<ReservaAudi> FechasReservadarxDiaId(DateTime fecha,int idReserva,  ref bool realizada)
        {
            List<ReservaAudi> list = new List<ReservaAudi>();
            string cadena = CConexion.Obtener();
            string consulta = "";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlDataReader reader = null;
                consulta = $"Select  [FechaIni], [FechaFin]   from ReservasAuditorio where  year(FechaIni) = {fecha.Year} and month(FechaIni) = {fecha.Month} and day(FechaIni)= {fecha.Day} and IdReserva Not in ({idReserva})";
                SqlCommand comando = new SqlCommand(consulta, con);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ReservaAudi modelo = new ReservaAudi(reader.GetDateTime(0), reader.GetDateTime(1));

                    list.Add(modelo);
                }
                realizada = true;
                con.Close();
                return list;
            }
            catch (Exception)
            {
                realizada = false;
                return list;

            }

        }


    }
}