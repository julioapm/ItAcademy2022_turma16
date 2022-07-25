public class Circulo
{
    private double coordX;
    private double coordY;
    private double raio;
    public double CentroX
    {
        get { return coordX; }
        set { coordX = value; }
    }
    public double CentroY
    {
        get { return coordY; }
        set { coordY = value; }
    }
    public double Raio
    {
        get { return raio; }
        set { raio = value; }
    }
    public Circulo(double x, double y, double r)
    {
        coordX = x;
        coordY = y;
        raio = r;
    }
    public Circulo()
    : this(0,0,1)
    {}
    public override string ToString()
    {
        return $"({CentroX:F2};{CentroY:F2}) raio={Raio:F2}";
    }
    public string ToStringHashCode()
    {
        return $"{GetType().Name} hash={GetHashCode()}";
    }
}