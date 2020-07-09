using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Clasificacion
    {
        public int CodCompeticion { get; set; }
        public int Jornada { get; set; }
        public int CodEquipo { get; set; }
        public int Posicion { get; set; }
        public int? Ganados { get; set; }
        public int? Perdidos { get; set; }
        public int? Empatados { get; set; }
        public int? GolesFavor { get; set; }
        public int? GolesContra { get; set; }
        public int? Puntos { get; set; }

        public virtual Competicion CodCompeticionNavigation { get; set; }
        public virtual Equipo CodEquipoNavigation { get; set; }
    }
}
