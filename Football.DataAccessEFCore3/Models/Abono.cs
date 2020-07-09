using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Abono
    {
        public int IdAbono { get; set; }
        public string LoginName { get; set; }
        public int? CodCompeticion { get; set; }
        public int? CodZona { get; set; }

        public virtual ZonaEstadio CodZonaNavigation { get; set; }
    }
}
