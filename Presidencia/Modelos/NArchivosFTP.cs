using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Presidencia.Modelos
{
    public class NArchivosFTP
    {


        public static bool CrearDirectorioFTP(string Carpeta)
        {

            try
            {
                //create the directory
                string UrlCompleta = CConexion.ObtenerRutaFTP() + Carpeta;
                FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(UrlCompleta));
                requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                //requestDir.Credentials = new NetworkCredential(Usuario, Clave);
                requestDir.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
                requestDir.UsePassive = true;
                requestDir.UseBinary = true;
                requestDir.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();

                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return false;
                }
                else
                {
                    response.Close();
                    return true;
                }
            }
        }

        public static bool VerificarDirectorioFTP(string NombreCarpeta)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(CConexion.ObtenerRutaFTP() + NombreCarpeta);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                //request.Credentials = new NetworkCredential(Usuario, Clave);
                request.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
                request.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                response.Close();
                return false;
            }
        }

        public static bool VerificarArchivoFTP(string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(CConexion.ObtenerRutaFTP() + fileName);
            //request.Credentials = new NetworkCredential(Usuario, Clave);
            request.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.KeepAlive = false;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
                response.Close();
            }
            return false;
        }

        public static bool EliminarArchivo(string DirCarpetaNExpe, string NombreArchivo)
        {
            string RutaArchivo = CConexion.ObtenerRutaFTP() + DirCarpetaNExpe + NombreArchivo;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(RutaArchivo);
            //request.Credentials = new NetworkCredential(Usuario, Clave);
            request.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.KeepAlive = false;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
                response.Close();
            }
            return false;
        }

        public static Byte[] ObtenerArchivoFTP(string fileName, string Usuario, string Clave)
        {
            Byte[] ArchivoArray = new byte[4096];

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(CConexion.ObtenerRutaFTP() + fileName);
            //request.Credentials = new NetworkCredential(Usuario, Clave);
            request.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.KeepAlive = false;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream ArchivoStream = response.GetResponseStream();
                ArchivoArray = ToByteArray(ArchivoStream);

                response.Close();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                response.Close();
            }

            return ArchivoArray;
        }


        public static bool CrearArchivoPDF(Stream responseStream, string NombreArchivo)
        {
            Stream clsStream = new MemoryStream();
            try
            {
                Byte[] ArchivoBA = ToByteArray(responseStream);
                string FileName = CConexion.ObtenerRutaFTP() + NombreArchivo;

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FileName);
                //request.Credentials = new NetworkCredential(Usuario, Clave);
                request.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.KeepAlive = true;

                clsStream = request.GetRequestStream();
                clsStream.Write(ArchivoBA, 0, ArchivoBA.Length);

                clsStream.Close();
                clsStream.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                clsStream.Close();
                clsStream.Dispose();
                return false;
            }

        }

        public static bool UploadFile(byte[] fileBytes, string NombreArchivo)
        {
            string FileName = CConexion.ObtenerRutaFTP() + NombreArchivo;

            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential(CConexion.ObtenerUsuarioFTP(), CConexion.ObtenerClaveFTP());
               // request.Credentials = new NetworkCredential("UserName", "Password");
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;

            }
            catch (WebException ex)
            {
                return false;
            }
        }


        public static Byte[] ToByteArray(Stream stream)
        {
            MemoryStream ms = new MemoryStream();

            //Obtener tamaño necesario el estandar es 4096
            //long Tam = stream.Length;

            byte[] chunk = new byte[4096];
            int bytesRead;
            while ((bytesRead = stream.Read(chunk, 0, chunk.Length)) > 0)
                ms.Write(chunk, 0, bytesRead);

            return ms.ToArray();
        }

    }


}