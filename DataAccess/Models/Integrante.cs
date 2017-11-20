using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Integrante
    {
        public Integrante()
        {
            HcoIntegrante = new HashSet<HcoIntegrante>();
            Jugador = new HashSet<Jugador>();
        }

        public int CodInt { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Foto { get; set; }

        public GlobalMedia Picture { get; set; }

        public string BirthPlace { get; set; }

        public virtual ICollection<HcoIntegrante> HcoIntegrante { get; set; }
        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}
