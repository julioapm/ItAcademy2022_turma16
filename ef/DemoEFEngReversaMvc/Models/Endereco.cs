using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            ClientesEnderecos = new HashSet<ClientesEndereco>();
        }

        public decimal CodEndereco { get; set; }
        public string Rua { get; set; } = null!;
        public decimal Numero { get; set; }
        public string? Complemento { get; set; }
        public decimal CodCidade { get; set; }
        public string Cep { get; set; } = null!;

        public virtual Cidade CodCidadeNavigation { get; set; } = null!;
        public virtual ICollection<ClientesEndereco> ClientesEnderecos { get; set; }
    }
}
