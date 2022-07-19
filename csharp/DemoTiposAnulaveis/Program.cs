//isso não é possível
//int x = null;
//isso é possível
int? y = null;
Console.WriteLine(y);

string s = null;
Console.WriteLine(s);
string? t = null;
Console.WriteLine(t);

int? a = 28;
int b = a ?? 0;
Console.WriteLine(b);
int? c = null;
int d = c ?? 0;
Console.WriteLine(d);
int? e = a + c;
Console.WriteLine(e); //e tem o valor null

string st = null!;

//DateTime dt = DateTime.Now;
//Console.WriteLine(dt.Day);
DateTime? dt = null;
Console.WriteLine(dt?.Day);

if (dt != null) {
    Console.WriteLine(dt?.Day);
}

if (dt.HasValue) {
    Console.WriteLine(dt.Value.Day);
}
