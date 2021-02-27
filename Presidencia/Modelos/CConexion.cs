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
           // return "Data Source=192.168.73.3; Initial Catalog=Presidencia; Uid=Programadores2017; Password=Development10;";
            return "Data Source=200.79.183.181; Initial Catalog=Presidencia; Uid=Programadores2017; Password=Development10;";
        }

        internal static string ObtenerWS()
        {
            return "http://serviciowebpjhgo.azurewebsites.net/api/";
        }

    }
}