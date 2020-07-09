using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class EquiposParticipan
    {
        public int CodCompeticion { get; set; }
        public int CodEquipo { get; set; }

        public virtual Competicion CodCompeticionNavigation { get; set; }
        public virtual Equipo CodEquipoNavigation { get; set; }
    }
}
