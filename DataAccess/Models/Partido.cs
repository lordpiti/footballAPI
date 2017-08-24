using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Partido
    {
        public Partido()
        {
            Cambio = new HashSet<Cambio>();
            Gol = new HashSet<Gol>();
            PartidoJugado = new HashSet<PartidoJugado>();
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int CodPartido { get; set; }
        public int CodCompeticion { get; set; }
        public string Jornada { get; set; }
        public int CodLocal { get; set; }
        public int CodVisitante { get; set; }
        public DateTime? Fecha { get; set; }
        public string Clima { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public float PosesionLocal { get; set; }
        public float PosesionVisitante { get; set; }
        public int CornersLocal { get; set; }
        public int CornersVisitante { get; set; }
        public int FuerasJuegoLocal { get; set; }
        public int FuerasJuegoVisitante { get; set; }
        public int? Asistencia { get; set; }
        public int CodArbitro { get; set; }
        public int CodEstadio { get; set; }

        public virtual ICollection<Cambio> Cambio { get; set; }
        public virtual ICollection<Gol> Gol { get; set; }
        public virtual ICollection<PartidoJugado> PartidoJugado { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
        public virtual Arbitro CodArbitroNavigation { get; set; }
        public virtual Competicion CodCompeticionNavigation { get; set; }
        public virtual Estadio CodEstadioNavigation { get; set; }
        public virtual Equipo CodLocalNavigation { get; set; }
        public virtual Equipo CodVisitanteNavigation { get; set; }
    }
}
