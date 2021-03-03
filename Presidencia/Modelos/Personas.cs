using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Presidencia.Modelos
{
    public class Personas
    {
      
        public Int32 IdPersona { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public Int32 IdAudiencia { get; set; }
        public string URLFoto { get; set; }



        public static List<Personas> PersonasXIdAudiencia(string id, ref bool realizada)
        {
            List<Personas> lista = new List<Personas>();

            string cadena = CConexion.Obtener();
            string consulta = "";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlDataReader reader = null;
                consulta = $"Select IdPersona, Nombre, APaterno , AMaterno , IdAudiencia, URLFoto  from Personas where IdAudiencia = " + id;
                SqlCommand comando = new SqlCommand(consulta, con);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Personas modelo = new Personas();
                    modelo.IdPersona = reader.GetInt32(0);
                    modelo.Nombre = reader.GetString(1);
                    modelo.APaterno = reader.GetString(2);
                    modelo.AMaterno = reader.GetString(3);
                    modelo.IdAudiencia = reader.GetInt32(4);

                    if (!reader.IsDBNull(reader.GetOrdinal("URLFoto")))
                        modelo.URLFoto = reader.GetString(reader.GetOrdinal("URLFoto"));
                    
                    lista.Add(modelo);


                }
                realizada = true;
                con.Close();
                return lista;
            }
            catch (Exception ex)
            {
                realizada = false;
                return lista;

            }
        }

        public static void ModificarPersona( Personas listapersonas, ref bool Resultado)
        {
            Resultado = false;
           
            string modificarPersona = @"[dbo].[stp_ModificarPersona]";
            using (var connection = new SqlConnection(CConexion.Obtener()))
            {
                connection.Open();

                using (var tx = connection.BeginTransaction())
                {
                    try
                    {
                        
                            SqlCommand command2 = new SqlCommand(modificarPersona, connection, tx);
                            command2.CommandType = CommandType.StoredProcedure;

                            command2.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int)).Value = listapersonas.IdPersona;
                            command2.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = listapersonas.Nombre;
                            command2.Parameters.Add(new SqlParameter("@APaterno", SqlDbType.VarChar)).Value = listapersonas.APaterno;
                            command2.Parameters.Add(new SqlParameter("@AMaterno", SqlDbType.VarChar)).Value = listapersonas.AMaterno;
                            command2.Parameters.Add(new SqlParameter("@URL", SqlDbType.VarChar)).Value = listapersonas.URLFoto;
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
        public static void AgregarPersona(Personas listapersonas, ref bool Resultado)
        {
            Resultado = false;

            string modificarPersona = @"[dbo].[stp_AgregarPersona]";
            using (var connection = new SqlConnection(CConexion.Obtener()))
            {
                connection.Open();

                using (var tx = connection.BeginTransaction())
                {
                    try
                    {

                        SqlCommand command2 = new SqlCommand(modificarPersona, connection, tx);
                        command2.CommandType = CommandType.StoredProcedure;

                        command2.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = listapersonas.Nombre;
                        command2.Parameters.Add(new SqlParameter("@APaterno", SqlDbType.VarChar)).Value = listapersonas.APaterno;
                        command2.Parameters.Add(new SqlParameter("@AMaterno", SqlDbType.VarChar)).Value = listapersonas.AMaterno;
                        command2.Parameters.Add(new SqlParameter("@IdAudiencia", SqlDbType.Int)).Value = listapersonas.IdAudiencia;
                        command2.Parameters.Add(new SqlParameter("@URLFoto", SqlDbType.VarChar)).Value = listapersonas.URLFoto;
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

        public static void EliminarPersona(int idPersona, ref bool Resultado)
        {
            Resultado = false;

            string modificarPersona = @"[dbo].[stp_EliminarPersonas]";
            using (var connection = new SqlConnection(CConexion.Obtener()))
            {
                connection.Open();

                using (var tx = connection.BeginTransaction())
                {
                    try
                    {

                        SqlCommand command2 = new SqlCommand(modificarPersona, connection, tx);
                        command2.CommandType = CommandType.StoredProcedure;

                        command2.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int)).Value = idPersona;

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