Pessoa p1 = new Pessoa("John Doe", 20);
Pessoa p2 = new Pessoa("Mary Doe", 20);
Pessoa p3 = new Pessoa("John Doe", 20);
Pessoa p4 = p1;

//Igualdade de referência
Console.WriteLine(p1 == p4);
Console.WriteLine(p1 == p3);

//Igualdade de valor
Console.WriteLine(p1.Equals(p4));
Console.WriteLine(p1.Equals(p3));
Console.WriteLine(p1.Equals(p2));

Console.WriteLine(p1.GetHashCode());
Console.WriteLine(p3.GetHashCode());

Pessoa outra = (Pessoa) p2.Clone();
