using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            Clasificacion = new HashSet<Clasificacion>();
            Directivo = new HashSet<Directivo>();
            Entrenador = new HashSet<Entrenador>();
            EquiposParticipan = new HashSet<EquiposParticipan>();
            HcoIntegrante = new HashSet<HcoIntegrante>();
            Jugador = new HashSet<Jugador>();
            Medico = new HashSet<Medico>();
            PartidoCodLocalNavigation = new HashSet<Partido>();
            PartidoCodVisitanteNavigation = new HashSet<Partido>();
            TranspasoCodEquipoDestinoNavigation = new HashSet<Transpaso>();
            TranspasoCodEquipoOrigenNavigation = new HashSet<Transpaso>();
        }

        public int CodEquipo { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public int? CodEstadio { get; set; }
        public string FotoEscudo { get; set; }
        public string FotoPlantilla { get; set; }
        public int? TeamPictureGlobalMediaId { get; set; }

        public virtual Estadio CodEstadioNavigation { get; set; }
        public virtual GlobalMedia TeamPictureGlobalMedia { get; set; }
        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
        public virtual ICollection<Directivo> Directivo { get; set; }
        public virtual ICollection<Entrenador> Entrenador { get; set; }
        public virtual ICollection<EquiposParticipan> EquiposParticipan { get; set; }
        public virtual ICollection<HcoIntegrante> HcoIntegrante { get; set; }
        public virtual ICollection<Jugador> Jugador { get; set; }
        public virtual ICollection<Medico> Medico { get; set; }
        public virtual ICollection<Partido> PartidoCodLocalNavigation { get; set; }
        public virtual ICollection<Partido> PartidoCodVisitanteNavigation { get; set; }
        public virtual ICollection<Transpaso> TranspasoCodEquipoDestinoNavigation { get; set; }
        public virtual ICollection<Transpaso> TranspasoCodEquipoOrigenNavigation { get; set; }
    }
}
