public class PedidoSimples : IPedido
{
    public decimal Valor {get;}
    public DateTime DataCompra {get;}
    public PedidoSimples(DateTime d, decimal v)
    {
        DataCompra = d;
        Valor = v;
    }
    public override string ToString()
    {
        return $"Data = {DataCompra.ToShortDateString()} Valor = {Valor}";
    }
}