public readonly struct Fracao
{
    private readonly int num;
    private readonly int den;

    public Fracao(int numerador, int denominador)
    {
        //assumir que denominador != 0
        num = numerador;
        den = denominador;
    }

    public int Numerador => num;
    public int Denominador => den;

    public string FracaoPorExtenso() => $"{num}/{den}";

    public static Fracao operator *(Fracao a, Fracao b)
    {
        return new Fracao(a.num * b.num, a.den * b.den);
    }
}