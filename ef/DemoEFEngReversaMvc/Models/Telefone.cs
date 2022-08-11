using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Telefone
    {
        public decimal CodCliente { get; set; }
        public decimal CodTelefone { get; set; }
        public decimal CodTipoTelefone { get; set; }
        public decimal? Ddd { get; set; }
        public string Numero { get; set; } = null!;

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
        public virtual TiposTelefone CodTipoTelefoneNavigation { get; set; } = null!;
    }
}
