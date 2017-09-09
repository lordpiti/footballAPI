using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class EquiposParticipan
    {
        public int CodCompeticion { get; set; }
        public int CodEquipo { get; set; }

        public virtual Equipo CodEquipoNavigation { get; set; }
        public virtual Competicion Competicion { get; set; }
    }
}
