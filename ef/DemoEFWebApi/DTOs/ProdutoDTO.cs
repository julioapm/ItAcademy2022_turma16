using DemoEFWebApi.Models;

namespace DemoEFWebApi.DTOs;

public class ProdutoDTO
{
    public int Id {get;set;}
    public string Nome {get;set;} = null!;
    public string? Descricao {get;set;}
    public string PrecoUnitario {get;set;} = null!;

    public static ProdutoDTO DeEntidadeParaDTO(Produto produto)
    {
        ProdutoDTO dto = new ProdutoDTO();
        dto.Id = produto.Id;
        dto.Nome = produto.Nome;
        dto.Descricao = produto.Descricao;
        dto.PrecoUnitario = $"{produto.PrecoUnitario/100M:C}";
        return dto;
    }
}