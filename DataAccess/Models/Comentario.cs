using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Comentario
    {
        public int CodComentario { get; set; }
        public int CodNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
