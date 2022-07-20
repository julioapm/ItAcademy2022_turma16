public class ContaCorrente
{
    private decimal saldo;
    public decimal Saldo
    {
        get { return saldo; }
    }
    /*
    public decimal Saldo
    {
        get => saldo;
    }
    */
    //public decimal Saldo => saldo;
    public DateTime DataCriacao { get; }

    public void Depositar(decimal valor)
    {
        saldo = saldo + valor;
        //saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        saldo = saldo - valor;
    }

    public ContaCorrente(decimal valor)
    {
        saldo = valor;
        DataCriacao = DateTime.Now;
    }
}