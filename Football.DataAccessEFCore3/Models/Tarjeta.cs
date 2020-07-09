using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Tarjeta
    {
        public int CodTarjeta { get; set; }
        public int CodPartido { get; set; }
        public int CodJugador { get; set; }
        public int Minuto { get; set; }
        public string Tipo { get; set; }
        public string Motivo { get; set; }

        public virtual Jugador CodJugadorNavigation { get; set; }
        public virtual Partido CodPartidoNavigation { get; set; }
    }
}
