using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Competicion
    {
        public Competicion()
        {
            Clasificacion = new HashSet<Clasificacion>();
            Partido = new HashSet<Partido>();
        }

        public int CodCompeticion { get; set; }
        public string Nombre { get; set; }
        public string Temporada { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Campeon { get; set; }
        public string Foto { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
        public virtual ICollection<Partido> Partido { get; set; }
    }
}
