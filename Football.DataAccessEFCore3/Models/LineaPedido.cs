using System;
using System.Collections.Generic;

namespace Football.DataAccessEFCore3.Models
{
    public partial class LineaPedido
    {
        public int Idpedido { get; set; }
        public int Idlinea { get; set; }
        public int Cantidad { get; set; }
        public float Pvp { get; set; }
        public int IdProducto { get; set; }
        public int Disp { get; set; }

        public virtual Pedidos IdpedidoNavigation { get; set; }
    }
}
