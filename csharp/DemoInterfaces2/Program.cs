ClienteSimples c = new ClienteSimples("John Doe", new DateTime(2022,7,20));
PedidoSimples p1 = new PedidoSimples(new DateTime(2022,6,20), 1.99m);
c.AdicionarPedido(p1);
PedidoSimples p2 = new PedidoSimples(new DateTime(2022,7,22), 110.55m);
c.AdicionarPedido(p2);
Console.WriteLine(c.Nome);
Console.WriteLine(c.DataCadastro);
Console.WriteLine(c.PedidosAnteriores.Count());
Console.WriteLine(c.UltimaCompra);
foreach (var pedido in c.PedidosAnteriores)
{
    Console.WriteLine(pedido);
}