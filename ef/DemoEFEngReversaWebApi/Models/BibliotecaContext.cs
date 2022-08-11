using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoEFEngReversaWebApi.Models
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autores { get; set; } = null!;
        public virtual DbSet<Emprestimo> Emprestimos { get; set; } = null!;
        public virtual DbSet<Livro> Livros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConexaoDefault");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PrimeiroNome)
                    .HasMaxLength(50)
                    .HasColumnName("primeironome");

                entity.Property(e => e.UltimoNome)
                    .HasMaxLength(50)
                    .HasColumnName("ultimonome");
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.ToTable("Emprestimo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDevolucao)
                    .HasColumnType("date")
                    .HasColumnName("datadevolucao");

                entity.Property(e => e.DataRetirada)
                    .HasColumnType("date")
                    .HasColumnName("dataretirada");

                entity.Property(e => e.Entregue).HasColumnName("entregue");

                entity.Property(e => e.Idlivro).HasColumnName("idlivro");

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.Emprestimos)
                    .HasForeignKey(d => d.Idlivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emprestimo_Livro");
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.ToTable("Livro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .HasColumnName("titulo");

                entity.HasMany(d => d.Autores)
                    .WithMany(p => p.Livros)
                    .UsingEntity<Dictionary<string, object>>(
                        "AutorLivro",
                        l => l.HasOne<Autor>().WithMany().HasForeignKey("Idautor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AutorLivro_Autor"),
                        r => r.HasOne<Livro>().WithMany().HasForeignKey("Idlivro").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AutorLivro_Livro"),
                        j =>
                        {
                            j.HasKey("Idlivro", "Idautor").HasName("PK_AutoLivro");

                            j.ToTable("AutorLivro");

                            j.IndexerProperty<int>("Idlivro").HasColumnName("idlivro");

                            j.IndexerProperty<int>("Idautor").HasColumnName("idautor");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
