using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Agenda
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int? CodCalendario { get; set; }
    }
}
