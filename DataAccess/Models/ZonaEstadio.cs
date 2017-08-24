using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ZonaEstadio
    {
        public ZonaEstadio()
        {
            Abono = new HashSet<Abono>();
        }

        public int IdZona { get; set; }
        public string Nombre { get; set; }
        public int? Capacidad { get; set; }
        public string Cubierto { get; set; }

        public virtual ICollection<Abono> Abono { get; set; }
    }
}
