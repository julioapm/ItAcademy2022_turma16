public interface ICliente
{
    string Nome {get;}
    DateTime? UltimaCompra {get;}
    DateTime DataCadastro {get;}
    IEnumerable<IPedido> PedidosAnteriores {get;}

    //membros static
    private static decimal desconto = 0.10m;
    private static int quantidade = 5;
    private static TimeSpan periodo = new TimeSpan(365,0,0,0);
    public static void AlterarValoresPadrao(TimeSpan p, int q, decimal d)
    {
        periodo = p;
        quantidade = q;
        desconto = d;
    }
    protected static decimal CalcularDescontoPadrao(ICliente cliente)
    {
        DateTime inicio = DateTime.Now - periodo;
        if (cliente.DataCadastro < inicio && cliente.PedidosAnteriores.Count() >= quantidade)
        {
            return desconto;
        }
        return 0;
    } 

    //implementação padrão de membros de instância
    public decimal CalcularDesconto() => CalcularDescontoPadrao(this);
}