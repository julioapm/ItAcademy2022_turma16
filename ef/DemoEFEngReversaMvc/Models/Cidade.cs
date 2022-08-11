using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public decimal CodCidade { get; set; }
        public string Nome { get; set; } = null!;
        public string Uf { get; set; } = null!;

        public virtual Estado UfNavigation { get; set; } = null!;
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
