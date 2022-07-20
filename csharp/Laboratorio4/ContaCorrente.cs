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

    public ContaCorrente(decimal saldo, Correntista umCorrentista)
    {
        this.saldo = saldo;
        DataCriacao = DateTime.Now;
        correntista = umCorrentista;
    }

    public ContaCorrente(string nomeCorrentista, string cpfCorrentista)
    : this(0,new Correntista {Nome=nomeCorrentista,Cpf=cpfCorrentista})
    {
    }
}