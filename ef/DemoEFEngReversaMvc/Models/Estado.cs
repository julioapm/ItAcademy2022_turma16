using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public string Uf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Regiao { get; set; } = null!;

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
