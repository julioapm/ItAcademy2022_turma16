using System.ComponentModel.DataAnnotations;

namespace DemoAloMundoWebService.Models;

public class Pessoa
{
    public string Nome {get;set;} = null!;
    [Required]
    public int? Idade {get;set;}
}
