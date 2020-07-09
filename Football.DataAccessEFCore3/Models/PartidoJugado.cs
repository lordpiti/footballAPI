using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class PartidoJugado
    {
        public int CodJugador { get; set; }
        public int CodPartido { get; set; }
        public string Titular { get; set; }
        public int Minutos { get; set; }
        public int Asistencias { get; set; }
        public int AsistenciasGol { get; set; }
        public int Remates { get; set; }
        public int RematesPorteria { get; set; }
        public int RematesPoste { get; set; }
        public int FuerasJuego { get; set; }
        public int TarjetasAmarillasProvocadas { get; set; }
        public int TarjetasRojasProvocadas { get; set; }
        public int FaltasRecibidas { get; set; }
        public int FaltasCometidas { get; set; }
        public int Corners { get; set; }
        public int BalonesRecuperados { get; set; }
        public int BalonesPerdidos { get; set; }
        public int PenaltisRecibidos { get; set; }
        public int PenaltisCometidos { get; set; }

        public virtual Jugador CodJugadorNavigation { get; set; }
        public virtual Partido CodPartidoNavigation { get; set; }
    }
}
