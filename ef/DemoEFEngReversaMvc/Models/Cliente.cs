using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClientesEnderecos = new HashSet<ClientesEndereco>();
            Telefones = new HashSet<Telefone>();
        }

        public decimal CodCliente { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Usuario CodClienteNavigation { get; set; } = null!;
        public virtual ICollection<ClientesEndereco> ClientesEnderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
