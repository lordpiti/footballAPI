using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Trata
    {
        public int CodTratamiento { get; set; }
        public int CodMedico { get; set; }
        public int CodJugador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Lesion { get; set; }

        public virtual Jugador CodJugadorNavigation { get; set; }
        public virtual Medico CodMedicoNavigation { get; set; }
    }
}
