using System;
using System.Collections.Generic;

namespace DemoEFEngReversaWebApi.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Livros = new HashSet<Livro>();
        }

        public int Id { get; set; }
        public string PrimeiroNome { get; set; } = null!;
        public string UltimoNome { get; set; } = null!;

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
