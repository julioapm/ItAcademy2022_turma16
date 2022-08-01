using System.ComponentModel.DataAnnotations;
namespace DemoCatalogoCepWebServices.Models;

public class CepModel
{
    //[Required(AllowEmptyStrings = true)]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter exatamente 8 dígitos")]
    public string Cep {get; set;} = null!;
    [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "O estados deve ser uma sigla com dois caracteres maiúsculos")]
    public string Estado {get; set;} = null!;
    [StringLength(50)]
    public string Cidade {get; set;} = null!;
    [StringLength(30)]
    public string Bairro {get; set;} = null!;
    [StringLength(70)]
    public string Logradouro {get; set;} = null!;
}