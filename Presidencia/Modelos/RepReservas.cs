using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presidencia.Modelos
{
    public class RepReservas
    {
        public int IdReserva { get; set; }

        public string Evento { get; set; }

        public DateTime FechaIni { get; set; }

        public DateTime FechaFin { get; set; }

        public string InfoAdicional { get; set; }

    }
}