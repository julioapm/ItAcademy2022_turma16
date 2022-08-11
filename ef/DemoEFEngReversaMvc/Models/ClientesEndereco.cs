using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class ClientesEndereco
    {
        public ClientesEndereco()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public decimal CodCliente { get; set; }
        public decimal CodEndereco { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
        public virtual Endereco CodEnderecoNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
