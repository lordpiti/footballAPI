using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Gol
    {
        public int CodGol { get; set; }
        public int CodPartido { get; set; }
        public int CodJugador { get; set; }
        public int Minuto { get; set; }
        public string Tipo { get; set; }
        public string Video { get; set; }

        public virtual Jugador CodJugadorNavigation { get; set; }
        public virtual Partido CodPartidoNavigation { get; set; }
    }
}
