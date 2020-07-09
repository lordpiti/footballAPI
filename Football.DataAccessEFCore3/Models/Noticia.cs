using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Noticia
    {
        public int CodNoticia { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Cuerpo { get; set; }
        public int? CodPartido { get; set; }
        public string Foto { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; }
    }
}
