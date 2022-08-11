using System;
using System.Collections.Generic;

namespace DemoEFEngReversaWebApi.Models
{
    public partial class Emprestimo
    {
        public int Id { get; set; }
        public bool Entregue { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int Idlivro { get; set; }
        public virtual Livro Livro { get; set; } = null!;
    }
}
