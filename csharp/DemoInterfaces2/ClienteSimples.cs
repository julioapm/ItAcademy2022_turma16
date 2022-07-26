using System.Collections.Immutable;
public class ClienteSimples : ICliente
{
    public string Nome { get; }

    public DateTime? UltimaCompra { get; private set; }

    public DateTime DataCadastro { get; }

    public IEnumerable<IPedido> PedidosAnteriores => todosPedidos.ToImmutableList();

    private List<IPedido> todosPedidos = new List<IPedido>();

    public ClienteSimples(string n, DateTime d)
    {
        Nome = n;
        DataCadastro = d;
    }

    public void AdicionarPedido(IPedido p)
    {
        todosPedidos.Add(p);
        if (p.DataCompra > (UltimaCompra ?? DateTime.MinValue))
        {
            UltimaCompra = p.DataCompra;
        }
    }
}