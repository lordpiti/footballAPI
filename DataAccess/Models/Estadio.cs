using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Estadio
    {
        public Estadio()
        {
            Partido = new HashSet<Partido>();
        }

        public int CodEstadio { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public string Foto { get; set; }

        public GlobalMedia Picture { get; set; }

        public virtual ICollection<Partido> Partido { get; set; }
    }
}
