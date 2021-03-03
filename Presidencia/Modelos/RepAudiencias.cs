using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presidencia.Modelos
{
    public class RepAudiencias
    {


        public int IdAudiencia { get; set; }

        public string Persona { get; set; }
        public string TipoVisita { get; set; }
        public string TipoAsunto { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaIni { get; set; }

        public DateTime FechaFin { get; set; }
        public string InfoAdicional { get; set; }






    }
}