using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Estadio
    {
        public Estadio()
        {
            Equipo = new HashSet<Equipo>();
            Partido = new HashSet<Partido>();
        }

        public int CodEstadio { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public string Foto { get; set; }
        public int? PictureGlobalMediaId { get; set; }

        public virtual GlobalMedia PictureGlobalMedia { get; set; }
        public virtual ICollection<Equipo> Equipo { get; set; }
        public virtual ICollection<Partido> Partido { get; set; }
    }
}
