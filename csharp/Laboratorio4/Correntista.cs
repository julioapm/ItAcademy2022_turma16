public class Correntista
{
    public string Nome {get; set;} = String.Empty;
    public string Cpf {get; init;} = null!;
    private int anoNascimento;
    public int AnoNascimento
    {
        get => anoNascimento;
        set => anoNascimento = value;
    }
}