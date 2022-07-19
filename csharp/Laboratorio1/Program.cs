byte b;
b = byte.MaxValue;
Console.WriteLine("Valor máximo de byte: " + b);
Console.WriteLine($"Valor máximo de byte: {b}");

string strPrimeira = "Alô ";
string strSegunda = "Mundo";
string strTerceira = strPrimeira + strSegunda;
Console.WriteLine(strTerceira);

int cchTamanho = strTerceira.Length;
string strQuarta = "Tamanho = " + cchTamanho.ToString();
Console.WriteLine(strQuarta);

DateTime dt = new DateTime(2022,7,19);
Console.WriteLine(dt.ToShortDateString());
DateTime agora = DateTime.Now;
Console.WriteLine(agora);

int i = 10;
float f = 0;
f = i;
Console.WriteLine(f);
f = 0.5f;
i = (int)f;
Console.WriteLine(i);
