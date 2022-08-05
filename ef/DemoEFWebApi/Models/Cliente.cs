namespace DemoEFWebApi.Models;

public class Cliente
{
    public int Id {get;set;}
    public string Nome {get;set;} = null!;
    public string Email {get;set;} = null!;
    public string? Telefone {get;set;}
    //relacionamento 1-N com Pedido
    public List<Pedido> Pedidos {get;set;} = null!;
}
