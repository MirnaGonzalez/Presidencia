using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Presidencia.Modelos
{
    public class Audiencias
    {

        public int IdAudiencia { get; set; }
        public string TipoVisita { get; set; }
        public string TipoAsunto { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string InfoAdicional { get; set; }

        public static void NuevaAudiencia (Audiencias audiencias, List<Personas> listapersonas, ref bool Resultado)
        {
            Resultado = false;
            string insertarAudiencia = @"[dbo].[stp_InsertarAudiencia]";

            string insertarAsistentes = @"dbo.stp_AgregarPersona";


            using (var connection = new SqlConnection(CConexion.Obtener()))
            {
                connection.Open();

                using (var tx = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(insertarAudiencia, connection, tx);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@TipoVisita", SqlDbType.VarChar)).Value = audiencias.TipoVisita;
                        command.Parameters.Add(new SqlParameter("@TipoAsunto", SqlDbType.VarChar)).Value = audiencias.TipoAsunto;
                        command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar)).Value = audiencias.Telefono;
                        command.Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.DateTime)).Value = audiencias.FechaIni;
                        command.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime)).Value = audiencias.FechaFin;
                        command.Parameters.Add(new SqlParameter("@InfoAdicional", SqlDbType.VarChar)).Value = audiencias.InfoAdicional;

                        int idAudiencia = Convert.ToInt32(command.ExecuteScalar());

                        for (int i = 0; i < listapersonas.Count; i++)
                        {
                            SqlCommand command2 = new SqlCommand(insertarAsistentes, connection, tx);
                            command2.CommandType = CommandType.StoredProcedure;

                            command2.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = listapersonas.ElementAt(i).Nombre;
                            command2.Parameters.Add(new SqlParameter("@APaterno", SqlDbType.VarChar)).Value = listapersonas.ElementAt(i).APaterno;
                            command2.Parameters.Add(new SqlParameter("@AMaterno", SqlDbType.VarChar)).Value = listapersonas.ElementAt(i).AMaterno;
                            command2.Parameters.Add(new SqlParameter("@URLFoto", SqlDbType.VarChar)).Value = listapersonas.ElementAt(i).URLFoto;
                            command2.Parameters.Add(new SqlParameter("@IdAudiencia", SqlDbType.Int)).Value = idAudiencia;
                            command2.ExecuteScalar();
                        }

                        tx.Commit();

                        connection.Close();
                        Resultado = true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        Resultado = false;
                        connection.Close();



                    }
                }
                }
            }
        public static List<Audiencias> FechasReservadarxDia(DateTime fecha, ref bool realizada)
        {
            List<Audiencias> list = new List<Audiencias>();
            string cadena = CConexion.Obtener();
            string consulta = "";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlDataReader reader = null;
                consulta = $"Select  [FechaIni], [FechaFin]   from Audiencias where  year(FechaIni) = {fecha.Year} and month(FechaIni) = {fecha.Month} and day(FechaIni)= {fecha.Day}";
                SqlCommand comando = new SqlCommand(consulta, con);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Audiencias modelo = new Audiencias { FechaIni = reader.GetDateTime(0), FechaFin = reader.GetDateTime(1) };

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

        public static List<Audiencias> FechasReservadarxDiaId(DateTime fecha, int idReserva, ref bool realizada)
        {
            List<Audiencias> list = new List<Audiencias>();
            string cadena = CConexion.Obtener();
            string consulta = "";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlDataReader reader = null;
                consulta = $"Select  [FechaIni], [FechaFin]   from Audiencias where  year(FechaIni) = {fecha.Year} and month(FechaIni) = {fecha.Month} and day(FechaIni)= {fecha.Day} and IdReserva Not in ({idReserva})";
                SqlCommand comando = new SqlCommand(consulta, con);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Audiencias modelo = new Audiencias { FechaIni = reader.GetDateTime(0), FechaFin = reader.GetDateTime(1) };

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


        public static Audiencias AudienciaXId (string id, ref bool realizada)
        {
            Audiencias modelo = new Audiencias();

            string cadena = CConexion.Obtener();
            string consulta = "";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlDataReader reader = null;
                consulta = $"Select IdAudiencia, TipoVisita, TipoAsunto , Telefono , FechaIni, FechaFin , InfoAdicional from Audiencias where IdAudiencia = " + id;
                SqlCommand comando = new SqlCommand(consulta, con);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    modelo.IdAudiencia = reader.GetInt32(0);
                    modelo.TipoVisita = reader.GetString(1);
                    modelo.TipoAsunto = reader.GetString(2);

                    if (!reader.IsDBNull(reader.GetOrdinal("Telefono")))
                        modelo.Telefono = reader.GetString(reader.GetOrdinal("Telefono"));


                    modelo.FechaIni = reader.GetDateTime(4);
                    modelo.FechaFin = reader.GetDateTime(5);
                    if (!reader.IsDBNull(reader.GetOrdinal("InfoAdicional")))
                        modelo.InfoAdicional = reader.GetString(reader.GetOrdinal("InfoAdicional"));


                }
                realizada = true;
                con.Close();
                return modelo;
            }
            catch (Exception ex)
            {
                realizada = false;
                return modelo;

            }
        }

        public static void EditarAudiencia(Audiencias audiencias, ref bool Resultado)
        {
            Resultado = false;
            string insertarAudiencia = @"[dbo].[stp_ModificarAudiencia]";



            using (var connection = new SqlConnection(CConexion.Obtener()))
            {
                connection.Open();

                using (var tx = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(insertarAudiencia, connection, tx);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@IdAudiencia", SqlDbType.Int)).Value = audiencias.IdAudiencia;
                        command.Parameters.Add(new SqlParameter("@TipoVisita", SqlDbType.VarChar)).Value = audiencias.TipoVisita;
                        command.Parameters.Add(new SqlParameter("@TipoAsunto", SqlDbType.VarChar)).Value = audiencias.TipoAsunto;
                        command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar)).Value = audiencias.Telefono;
                        command.Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.DateTime)).Value = audiencias.FechaIni;
                        command.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.DateTime)).Value = audiencias.FechaFin;
                        command.Parameters.Add(new SqlParameter("@InfoAdicional", SqlDbType.VarChar)).Value = audiencias.InfoAdicional;
                        int retorno = Convert.ToInt32(command.ExecuteScalar());


                        tx.Commit();

                        connection.Close();
                        Resultado = true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        Resultado = false;
                        connection.Close();



                    }
                }
            }
        }

        public static void EliminarAudienciaTotal(int IdAudiencia, ref bool Resultado)
        {
            Resultado = false;

            string modificarPersona = @"[dbo].[stp_EliminarAudienciaPersonas]";
            using (var connection = new SqlConnection(CConexion.Obtener()))
            {
                connection.Open();

                using (var tx = connection.BeginTransaction())
                {
                    try
                    {

                        SqlCommand command2 = new SqlCommand(modificarPersona, connection, tx);
                        command2.CommandType = CommandType.StoredProcedure;

                        command2.Parameters.Add(new SqlParameter("@IdAudiencia", SqlDbType.Int)).Value = IdAudiencia;

                        command2.ExecuteScalar();


                        tx.Commit();

                        connection.Close();
                        Resultado = true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        Resultado = false;
                        connection.Close();



                    }
                }
            }
        }


    }
    }
