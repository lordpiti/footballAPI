using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Calendario
    {
        public int CodCalendario { get; set; }
        public int CodCompeticion { get; set; }
        public string Jornada { get; set; }
        public int CodLocal { get; set; }
        public int CodVisitante { get; set; }
        public DateTime? Fecha { get; set; }
        public int? MatchCodPartido { get; set; }

        public virtual Partido MatchCodPartidoNavigation { get; set; }
    }
}
