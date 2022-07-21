static void TratadorDaExplosao(object? sender, EventArgs e)
{
    Console.WriteLine("A bomba explodiu!");
}

Bomba b = new Bomba(3);
b.FezBum += TratadorDaExplosao;
b.Tic();
Console.WriteLine("tic");
b.Tic();
Console.WriteLine("tic");
b.Tic();
Console.WriteLine("tic");
b.Tic(); //vai explodir aqui
Console.WriteLine("tic");
