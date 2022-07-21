List<string> listaStrings = new List<string>();
listaStrings.Add("Um");
listaStrings.Add("Hello");
listaStrings.Add("World");
Console.WriteLine(listaStrings[0]);
//Console.WriteLine(listaStrings[3]);
listaStrings[0] = "Alterado";
Console.WriteLine(listaStrings[0]);
Console.WriteLine(listaStrings.Count);

/*
foreach (var item in listaStrings)
{
    Console.WriteLine(item);
}
*/
listaStrings.ForEach(Console.WriteLine);
listaStrings.ForEach(item => Console.WriteLine(item.Length));
var elemento = listaStrings.Find(item => item[0] == 'Z');
Console.WriteLine(elemento);
