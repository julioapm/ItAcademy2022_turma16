using System;
using System.Collections.Generic;

namespace DemoEFEngReversaMvc.Models
{
    public partial class Produto
    {
        public Produto()
        {
            PedidosProdutos = new HashSet<PedidosProduto>();
            CodAutors = new HashSet<Autore>();
        }

        public decimal CodProduto { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime AnoLancamento { get; set; }
        public string Importado { get; set; } = null!;
        public decimal Preco { get; set; }
        public decimal PrazoEntrega { get; set; }

        public virtual ICollection<PedidosProduto> PedidosProdutos { get; set; }

        public virtual ICollection<Autore> CodAutors { get; set; }
    }
}
