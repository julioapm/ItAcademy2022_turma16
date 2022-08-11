using System;
using System.Collections.Generic;

namespace DemoEFEngReversaWebApi.Models
{
    public partial class Livro
    {
        public Livro()
        {
            Emprestimos = new HashSet<Emprestimo>();
            Autores = new HashSet<Autor>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = null!;

        public virtual ICollection<Emprestimo> Emprestimos { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
    }
}
