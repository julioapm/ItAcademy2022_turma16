namespace DemoEFWebApi.Models;

public class Produto
{
    public int Id {get;set;}
    public string Nome {get;set;} = null!;
    public string? Descricao {get;set;}
    public int PrecoUnitario {get;set;}
    //relacionamento N-N com Pedido via Item
    public ICollection<Pedido> Pedidos {get;set;} = null!;
    public List<Item> Itens {get;set;} = null!;
}
