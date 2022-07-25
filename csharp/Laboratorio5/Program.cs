Circulo circ1 = new Circulo();
Console.WriteLine(circ1);
Circulo circ2 = new Circulo(2.4, 5, 3);
Console.WriteLine(circ2);

CirculoColorido circ3 = new CirculoColorido();
Console.WriteLine(circ3);
CirculoColorido circ4 = new CirculoColorido(1.5, 3.1, 1, "vermelho");
Console.WriteLine(circ4);

LinkedList<Circulo> circulos = new LinkedList<Circulo>();
circulos.AddLast(circ1);
circulos.AddLast(circ2);
circulos.AddLast(circ3);
circulos.AddLast(circ4);
Console.WriteLine("Foreach polimórfico:");
foreach (var item in circulos)
{
    Console.WriteLine(item);
}
Console.WriteLine("Foreach não polimórfico:");
foreach (var item in circulos)
{
    Console.WriteLine(item.ToStringHashCode());
}
Console.WriteLine(circ4.ToStringHashCode());
Console.WriteLine(((Circulo)circ4).ToStringHashCode());

Console.WriteLine(circ4 is Circulo);
Console.WriteLine(circ4 is CirculoColorido);
CirculoColorido? circ1convertida = circ1 as CirculoColorido; //vai gerar null
