using Microsoft.EntityFrameworkCore;

namespace DemoEFWebApi.Models;

public class LojinhaContext: DbContext
{
    public DbSet<Cliente> Clientes {get;set;} = null!;
    public DbSet<Produto> Produtos {get;set;} = null!;
    public DbSet<Pedido> Pedidos {get;set;} = null!;

    public LojinhaContext()
    {
    }
    public LojinhaContext(DbContextOptions<LojinhaContext> opcoes)
    : base(opcoes)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entityBuilder => {
            entityBuilder.Property(e => e.Nome).HasMaxLength(30);
            entityBuilder.Property(e => e.Email).HasMaxLength(50);
        });
        modelBuilder.Entity<Produto>(entityBuilder => {
            entityBuilder.Property(e => e.Nome).HasMaxLength(30);
            entityBuilder.Property(e => e.Descricao).HasMaxLength(200);
        });
        modelBuilder.Entity<Pedido>()
            .HasMany(pedido => pedido.Produtos)
            .WithMany(produto => produto.Pedidos)
            .UsingEntity<Item>();
    }
}