using Microsoft.EntityFrameworkCore;

using var bd = new CepDbContext();
/*
Console.WriteLine("Inserir dados:");
bd.Add(new CepModel{
    Cep="12345678",
    Estado="RS",
    Cidade="Porto Alegre",
    Bairro="Centro",
    Logradouro="Borges de Medeiros"
});
bd.SaveChanges();

Console.WriteLine("Consultar dados:");
var todosCeps = bd.Ceps.OrderBy(c => c.Cidade);
foreach (var cep in todosCeps)
{
    Console.WriteLine($"Id={cep.Id}, Cep={cep.Cep}, Cidade={cep.Cidade}");
}
*/
/*
Console.WriteLine("Alterar dados:");
var umcep = bd.Ceps.Find(1);
if (umcep != null)
{
    Console.WriteLine($"Id={umcep.Id}, Cep={umcep.Cep}, Cidade={umcep.Cidade}");
    umcep.Cidade = "Canoas";
}
bd.SaveChanges();
*/
/*
Console.WriteLine("Remover dados:");
var umcep = bd.Ceps.Find(2);
if (umcep != null)
{
    bd.Remove(umcep);
}
bd.SaveChanges();

Console.WriteLine("Consultar dados:");
todosCeps = bd.Ceps.OrderBy(c => c.Cidade);
foreach (var cep in todosCeps)
{
    Console.WriteLine($"Id={cep.Id}, Cep={cep.Cep}, Cidade={cep.Cidade}");
}
*/

Console.WriteLine("Métodos assíncronos:");
await bd.AddAsync(new CepModel{
    Cep="12345678",
    Estado="RS",
    Cidade="Porto Alegre",
    Bairro="Centro",
    Logradouro="Borges de Medeiros"
});
await bd.SaveChangesAsync();
var todosCeps = await bd.Ceps.ToListAsync();
todosCeps.ForEach(cep => Console.WriteLine(cep.Cep));
