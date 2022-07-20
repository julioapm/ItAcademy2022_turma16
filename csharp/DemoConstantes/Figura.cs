public class Figura
{
    private readonly string nomeDaClasse;

    public string NomeDaClasse => nomeDaClasse;

    public Figura()
    {
        nomeDaClasse = this.GetType().AssemblyQualifiedName ?? String.Empty;
    }

    public void AlteraNome(string nome)
    {
        //erro de compilação
        //nomeDaClasse = nome;
    }
}