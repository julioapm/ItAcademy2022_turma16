int[] array = new int[5] {10, 20, 30, 40, 50};
for (int i=0; i<array.Length; i++)
{
    Console.WriteLine($"Índice = {i} Valor = {array[i]}");
}
var j = 0;
while (j<array.Length)
{
    Console.WriteLine($"Índice = {j} Valor = {array[j]}");
    j++;
}
foreach (var item in array)
{
    Console.WriteLine(item);
}

string[] palavras = new string[3];
palavras[0] = "Um";
palavras[1] = "Dois";
palavras[2] = "Três";
Console.WriteLine(palavras.Length);
Console.WriteLine(palavras.Rank);

Console.WriteLine("Exemplo da matriz:");
int[,] matriz = new int[2,2];
matriz[0,0] = 1;
matriz[1,1] = 1;
foreach (var item in matriz)
{
    Console.WriteLine(item);
}
Console.WriteLine(matriz.Rank);
Console.WriteLine(matriz.Length);

Console.WriteLine("Exemplo de array jagged:");
int[][] jagged = new int[2][];
jagged[0] = new int[3] {1,2,3};
jagged[1] = new int[2];
Console.WriteLine(jagged.Rank);
Console.WriteLine(jagged.Length);
Console.WriteLine(jagged[0].Rank);
Console.WriteLine(jagged[0].Length);
Console.WriteLine(jagged[1].Rank);
Console.WriteLine(jagged[1].Length);
foreach (var subarray in jagged)
{
    foreach (var item in subarray)
    {
        Console.WriteLine(item);
    }
}
