using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Trata = new HashSet<Trata>();
        }

        public int CodMedico { get; set; }
        public int CodIntegrante { get; set; }
        public int CodEquipo { get; set; }
        public int VersionIntegrante { get; set; }
        public string Especialidad { get; set; }
        public DateTime? FechaProfesional { get; set; }

        public virtual ICollection<Trata> Trata { get; set; }
        public virtual Equipo CodEquipoNavigation { get; set; }
    }
}
