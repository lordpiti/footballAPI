using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Directivo
    {
        public int CodDirectivo { get; set; }
        public int CodIntegrante { get; set; }
        public int CodEquipo { get; set; }
        public int VersionIntegrante { get; set; }
        public string Cargo { get; set; }
        public string Profesion { get; set; }

        public virtual Equipo CodEquipoNavigation { get; set; }
    }
}
