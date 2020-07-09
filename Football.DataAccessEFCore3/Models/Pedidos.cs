using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            LineaPedido = new HashSet<LineaPedido>();
        }

        public int IdPedido { get; set; }
        public string IdUsuario { get; set; }
        public string Tarjeta { get; set; }
        public DateTime Fechatarjeta { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Puerta { get; set; }
        public int Cp { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<LineaPedido> LineaPedido { get; set; }
    }
}
