using DemoEFWebApi.Models;

namespace DemoEFWebApi.DTOs;

public class PedidoDTO
{
    public int Id {get;set;}
    public string DataEmissao {get;set;} = null!;
    public string NomeCliente {get;set;} = null!;
    public decimal ValorTotal {get;set;}
    public IEnumerable<ItemDTO> Itens {get;set;} = null!;
    public static PedidoDTO DeEntidadeParaDTO(Pedido pedido)
    {
        return new PedidoDTO
        {
            DataEmissao = pedido.DataEmissao.ToShortDateString(),
            Id = pedido.Id,
            Itens = pedido.Itens.Select(ItemDTO.DeEntidadeParaDTO),
            NomeCliente = pedido.Cliente.Nome,
            ValorTotal = pedido.Itens.Sum(item => item.Quantidade * item.Produto.PrecoUnitario)/100M
        };
    }
}

public class ItemDTO
{
    public int Quantidade {get;set;}
    public int IdProduto {get;set;}
    public string NomeProduto {get;set;} = null!;
    public decimal ValorUnitario {get;set;}
    public decimal SubTotal {get;set;}
    public static ItemDTO DeEntidadeParaDTO(Item item)
    {
        return new ItemDTO
        {
            IdProduto = item.ProdutoId,
            NomeProduto = item.Produto.Nome,
            Quantidade = item.Quantidade,
            ValorUnitario = item.Produto.PrecoUnitario/100M,
            SubTotal = item.Quantidade*(item.Produto.PrecoUnitario/100M)
        };
    }
}