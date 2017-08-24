using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Producto
    {
        public int ProdId { get; set; }
        public string Nombre { get; set; }
        public float? Precio { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? Stock { get; set; }
        public string Categoria { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
    }
}
