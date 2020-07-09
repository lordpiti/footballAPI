using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
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
        public int? PictureGlobalMediaId { get; set; }
        public string BirthPlace { get; set; }

        public virtual GlobalMedia PictureGlobalMedia { get; set; }
        public virtual ICollection<HcoIntegrante> HcoIntegrante { get; set; }
        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}
