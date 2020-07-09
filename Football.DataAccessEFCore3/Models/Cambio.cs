using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Cambio
    {
        public int CodCambio { get; set; }
        public int CodPartido { get; set; }
        public int CodJugadorEntra { get; set; }
        public int CodJugadorSale { get; set; }
        public int Minuto { get; set; }

        public virtual Jugador CodJugadorEntraNavigation { get; set; }
        public virtual Jugador CodJugadorSaleNavigation { get; set; }
        public virtual Partido CodPartidoNavigation { get; set; }
    }
}
