public class ContaCorrente
{
    private Correntista correntista;
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
    
    public Correntista Correntista => correntista;

    public void Depositar(decimal valor)
    {
        saldo = saldo + valor;
        //saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        saldo = saldo - valor;
    }

    public ContaCorrente(decimal valor, Correntista umCorrentista)
    {
        saldo = valor;
        DataCriacao = DateTime.Now;
        correntista = umCorrentista;
    }
}