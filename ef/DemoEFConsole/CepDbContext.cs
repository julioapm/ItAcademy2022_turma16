using Microsoft.EntityFrameworkCore;

public class CepDbContext : DbContext
{
    public DbSet<CepModel> Ceps {get;set;} = null!;
    public string CaminhoDoBD {get;set;}

    public CepDbContext()
    {
        var diretorio = Environment.SpecialFolder.LocalApplicationData;
        var caminho = Environment.GetFolderPath(diretorio);
        Console.WriteLine(caminho);
        CaminhoDoBD = Path.Join(caminho, "ceps.db");
        Console.WriteLine(CaminhoDoBD);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={CaminhoDoBD}");
    }
}
