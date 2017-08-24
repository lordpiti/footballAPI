using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Transpaso
    {
        public int CodTranspaso { get; set; }
        public int CodIntegrante { get; set; }
        public int CodEquipoOrigen { get; set; }
        public int CodEquipoDestino { get; set; }
        public float Coste { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Equipo CodEquipoDestinoNavigation { get; set; }
        public virtual Equipo CodEquipoOrigenNavigation { get; set; }
    }
}
