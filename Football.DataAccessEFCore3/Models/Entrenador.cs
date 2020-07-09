using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Entrenador
    {
        public int CodEntrenador { get; set; }
        public int CodIntegrante { get; set; }
        public int CodEquipo { get; set; }
        public int VersionIntegrante { get; set; }
        public string Cargo { get; set; }
        public DateTime? FechaProfesional { get; set; }

        public virtual Equipo CodEquipoNavigation { get; set; }
    }
}
