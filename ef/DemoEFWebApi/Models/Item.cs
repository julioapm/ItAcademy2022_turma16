namespace DemoEFWebApi.Models;

public class Item
{
    public int Quantidade {get;set;}
    //relacionamento N-1 com Produto
    public Produto Produto {get;set;} = null!;
    public int ProdutoId {get;set;}
    //relacionamento N-1 com Pedido
    public Pedido Pedido {get;set;} = null!;
    public int PedidoId {get;set;}
}
