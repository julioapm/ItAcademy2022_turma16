using System.ComponentModel.DataAnnotations;

namespace DemoEFWebApi.DTOs;

public class CarrinhoDTO
{
    [Required(ErrorMessage = "IdCliente é obrigatório")]
    public int? IdCliente {get;set;}
    [Required(ErrorMessage = "Itens é obrigatório")]
    public IEnumerable<ItemCarrinhoDTO> Itens {get;set;} = null!;
}

public class ItemCarrinhoDTO
{
    [Required(ErrorMessage = "IdProduto é obrigatório")]
    public int? IdProduto {get;set;}
    [Required(ErrorMessage = "Quantidade é obrigatório")]
    [Range(1,10, ErrorMessage = "No mínimo 1 e no máximo 10")]
    public int? Quantidade {get;set;}
}