using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class GlobalMedia : BaseEntity
    {
        public GlobalMedia()
        {
            Competicion = new HashSet<Competicion>();
            Equipo = new HashSet<Equipo>();
            Estadio = new HashSet<Estadio>();
            Integrante = new HashSet<Integrante>();
        }

        public int GlobalMediaId { get; set; }
        public string BlobStorageContainer { get; set; }
        public string BlobStorageReference { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<Competicion> Competicion { get; set; }
        public virtual ICollection<Equipo> Equipo { get; set; }
        public virtual ICollection<Estadio> Estadio { get; set; }
        public virtual ICollection<Integrante> Integrante { get; set; }
    }
}
