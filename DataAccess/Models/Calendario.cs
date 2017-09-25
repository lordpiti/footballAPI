using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Calendario
    {
        public int CodCalendario { get; set; }
        public int CodCompeticion { get; set; }
        public string Jornada { get; set; }
        public int CodLocal { get; set; }
        public int CodVisitante { get; set; }
        public DateTime? Fecha { get; set; }

        public Partido Match { get; set; }
    }
}
