using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Arbitro
    {
        public Arbitro()
        {
            Partido = new HashSet<Partido>();
        }

        public int CodArbitro { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Colegio { get; set; }
        public int? AnosActivo { get; set; }
        public string Foto { get; set; }

        public virtual ICollection<Partido> Partido { get; set; }
    }
}
