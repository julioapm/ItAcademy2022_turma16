public class ContaCorrente : Conta
{
    public override string Id
    {
        get { return $"{Titular}(CC)"; }
    }
    public ContaCorrente(string t)
    : base(t)
    {}
}