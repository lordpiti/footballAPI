using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class HcoIntegrante
    {
        public int CodIntegrante { get; set; }
        public int CodEquipo { get; set; }
        public int VersionIntegrante { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaFinContrato { get; set; }
        public float? Sueldo { get; set; }
        public int? Dorsal { get; set; }

        public virtual Equipo CodEquipoNavigation { get; set; }
        public virtual Integrante CodIntegranteNavigation { get; set; }
    }
}
