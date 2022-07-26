List<Pessoa> pessoas = new List<Pessoa> 
{ 
    new Pessoa{Nome="Ana", DataNascimento=new DateTime(1980,3,14), Casada=true}, 
    new Pessoa{Nome="Maria", DataNascimento=new DateTime(2000,1,10), Casada=false}, 
    new Pessoa{Nome="Paulo", DataNascimento=new DateTime(1978,10,23), Casada=true}, 
    new Pessoa{Nome="Carlos", DataNascimento=new DateTime(1999,12,12), Casada=false} 
};

var casadasLinq = from p in pessoas
                  where p.Casada
                  select p;

foreach (var pessoa in casadasLinq)
{
    Console.WriteLine(pessoa);
}

var casadasLinqV2 = pessoas.Where(p => p.Casada);

foreach (var pessoa in casadasLinqV2)
{
    Console.WriteLine(pessoa);
}

var linq1 = from p in pessoas
            where p.Casada && p.DataNascimento >= new DateTime(1980,1,1)
            select p;

foreach (var pessoa in linq1)
{
    Console.WriteLine(pessoa);
}

var linq1V2 = pessoas.Where(p => p.Casada && p.DataNascimento >= new DateTime(1980,1,1));

var linq2 = from p in pessoas
            where !p.Casada
            select p.Nome;
foreach (var nome in linq2)
{
    Console.WriteLine(nome);
}

var linq2V2 = pessoas.Where(p => !p.Casada).Select(p => p.Nome);
foreach (var nome in linq2V2)
{
    Console.WriteLine(nome);
}

var linq2V3 = pessoas.Where(p => !p.Casada).Select((p,i) => p.Nome + $"({i})");
foreach (var nome in linq2V3)
{
    Console.WriteLine(nome);
}
