using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class TiposTelefone
    {
        public TiposTelefone()
        {
            Telefones = new HashSet<Telefone>();
        }

        public decimal CodTipoTelefone { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
