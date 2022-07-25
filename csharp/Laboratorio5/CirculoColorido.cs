public class CirculoColorido : Circulo
{
    private string minhaCor;
    public string Cor
    {
        get { return minhaCor; }
        set { minhaCor = value; }
    }
    public CirculoColorido()
    {
        minhaCor = "preto";
    }
    public CirculoColorido(double x, double y, double r, string c)
    : base(x,y,r)
    {
        minhaCor = c;
    }
    public override string ToString()
    {
        return base.ToString() + $" cor={Cor}";
    }
    public new string ToStringHashCode()
    {
        return "uma coisa qualquer";
    }
}