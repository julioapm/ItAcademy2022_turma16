using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidosProdutos = new HashSet<PedidosProduto>();
        }

        public decimal NumPedido { get; set; }
        public decimal CodCliente { get; set; }
        public decimal CodEndereco { get; set; }
        public DateTime DataEmissao { get; set; }

        public virtual ClientesEndereco Cod { get; set; } = null!;
        public virtual ICollection<PedidosProduto> PedidosProdutos { get; set; }
    }
}
