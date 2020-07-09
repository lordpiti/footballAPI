using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Asiento
    {
        public int CodCompeticion { get; set; }
        public int RefZona { get; set; }
        public float? Precio { get; set; }
        public int? Libres { get; set; }
    }
}
