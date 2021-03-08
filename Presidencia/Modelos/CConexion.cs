using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presidencia.Modelos
{
    public class CConexion
    {
        internal static string Obtener()
        {
            //return "Data Source=192.168.73.3; Initial Catalog=Presidencia; Uid=Programadores2017; Password=Development10;";
            return "Data Source=200.79.183.181; Initial Catalog=Presidencia; Uid=Programadores2017; Password=Development10;";
        }

        internal static string ObtenerWS()
        {
            return "http://serviciowebpjhgo.azurewebsites.net/api/";
        }

        internal static string ObtenerRutaFTP()
        {
            return "ftp://192.168.73.7/"; //"ftp://192.168.73.245/Tocas/Notificaciones/";
        }
        internal static string ObtenerUsuarioFTP()
        {
            return "FTPUER"; 
        }
        internal static string ObtenerClaveFTP()
        {
            return "ftp2020A"; 
        }



    }
}