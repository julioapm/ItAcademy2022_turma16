using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoEFEngReversaMvc.Models
{
    public partial class CadastroContext : DbContext
    {
        public CadastroContext()
        {
        }

        public CadastroContext(DbContextOptions<CadastroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administradore> Administradores { get; set; } = null!;
        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<Cidade> Cidades { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClientesEndereco> ClientesEnderecos { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<PedidosProduto> PedidosProdutos { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;
        public virtual DbSet<TiposTelefone> TiposTelefones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConexaoDefault");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradore>(entity =>
            {
                entity.HasKey(e => e.CodAdministrador)
                    .HasName("PK_ADMINISTRADORES");

                entity.ToTable("administradores");

                entity.Property(e => e.CodAdministrador)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("cod_administrador");

                entity.Property(e => e.NivelPrivilegio)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("nivel_privilegio");

                entity.HasOne(d => d.CodAdministradorNavigation)
                    .WithOne(p => p.Administradore)
                    .HasForeignKey<Administradore>(d => d.CodAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USU_ADM");
            });

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.CodAutor)
                    .HasName("PK_AUTORES");

                entity.ToTable("autores");

                entity.Property(e => e.CodAutor)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("cod_autor");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasMany(d => d.CodProdutos)
                    .WithMany(p => p.CodAutors)
                    .UsingEntity<Dictionary<string, object>>(
                        "AutoresProduto",
                        l => l.HasOne<Produto>().WithMany().HasForeignKey("CodProduto").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PRD_AUTPROD"),
                        r => r.HasOne<Autore>().WithMany().HasForeignKey("CodAutor").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AUT_AUTPROD"),
                        j =>
                        {
                            j.HasKey("CodAutor", "CodProduto").HasName("PK_AUTORES_PRODUTOS");

                            j.ToTable("autores_produtos");

                            j.IndexerProperty<decimal>("CodAutor").HasColumnType("numeric(4, 0)").HasColumnName("cod_autor");

                            j.IndexerProperty<decimal>("CodProduto").HasColumnType("numeric(5, 0)").HasColumnName("cod_produto");
                        });
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CodCidade)
                    .HasName("PK_CIDADES");

                entity.ToTable("cidades");

                entity.Property(e => e.CodCidade)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("cod_cidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("uf")
                    .IsFixedLength();

                entity.HasOne(d => d.UfNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.Uf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EST_CID");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK_CLIENTES");

                entity.ToTable("clientes");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("cod_cliente");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("date")
                    .HasColumnName("data_cadastro");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USU_CLI");
            });

            modelBuilder.Entity<ClientesEndereco>(entity =>
            {
                entity.HasKey(e => new { e.CodCliente, e.CodEndereco })
                    .HasName("PK_CLIENTES_ENDERECOS");

                entity.ToTable("clientes_enderecos");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("cod_cliente");

                entity.Property(e => e.CodEndereco)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("cod_endereco");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("date")
                    .HasColumnName("data_cadastro");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.ClientesEnderecos)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLI_CLIEND");

                entity.HasOne(d => d.CodEnderecoNavigation)
                    .WithMany(p => p.ClientesEnderecos)
                    .HasForeignKey(d => d.CodEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_END_CLIEND");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.CodEndereco)
                    .HasName("PK_ENDERECOS");

                entity.ToTable("enderecos");

                entity.Property(e => e.CodEndereco)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("cod_endereco");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("cep")
                    .IsFixedLength();

                entity.Property(e => e.CodCidade)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("cod_cidade");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("complemento");

                entity.Property(e => e.Numero)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("rua");

                entity.HasOne(d => d.CodCidadeNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CodCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CID_END");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Uf)
                    .HasName("PK_ESTADOS");

                entity.ToTable("estados");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("uf")
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Regiao)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("regiao")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.NumPedido)
                    .HasName("PK_PEDIDOS");

                entity.ToTable("pedidos");

                entity.Property(e => e.NumPedido)
                    .HasColumnType("numeric(7, 0)")
                    .HasColumnName("num_pedido");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("cod_cliente");

                entity.Property(e => e.CodEndereco)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("cod_endereco");

                entity.Property(e => e.DataEmissao)
                    .HasColumnType("date")
                    .HasColumnName("data_emissao");

                entity.HasOne(d => d.Cod)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => new { d.CodCliente, d.CodEndereco })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIEND_PED");
            });

            modelBuilder.Entity<PedidosProduto>(entity =>
            {
                entity.HasKey(e => new { e.NumPedido, e.CodProduto })
                    .HasName("PK_PEDIDOS_PRODUTOS");

                entity.ToTable("pedidos_produtos");

                entity.Property(e => e.NumPedido)
                    .HasColumnType("numeric(7, 0)")
                    .HasColumnName("num_pedido");

                entity.Property(e => e.CodProduto)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("cod_produto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("valor_unitario");

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.PedidosProdutos)
                    .HasForeignKey(d => d.CodProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROD_PEDPROD");

                entity.HasOne(d => d.NumPedidoNavigation)
                    .WithMany(p => p.PedidosProdutos)
                    .HasForeignKey(d => d.NumPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PED_PEDPROD");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProduto)
                    .HasName("PK_PRODUTOS");

                entity.ToTable("produtos");

                entity.Property(e => e.CodProduto)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("cod_produto");

                entity.Property(e => e.AnoLancamento)
                    .HasColumnType("date")
                    .HasColumnName("ano_lancamento");

                entity.Property(e => e.Importado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("importado")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.PrazoEntrega)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("prazo_entrega");

                entity.Property(e => e.Preco)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("preco");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => new { e.CodCliente, e.CodTelefone })
                    .HasName("PK_TELEFONES");

                entity.ToTable("telefones");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("cod_cliente");

                entity.Property(e => e.CodTelefone)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("cod_telefone");

                entity.Property(e => e.CodTipoTelefone)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("cod_tipo_telefone");

                entity.Property(e => e.Ddd)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("ddd");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLI_TEL");

                entity.HasOne(d => d.CodTipoTelefoneNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.CodTipoTelefone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPTEL_TEL");
            });

            modelBuilder.Entity<TiposTelefone>(entity =>
            {
                entity.HasKey(e => e.CodTipoTelefone)
                    .HasName("PK_TIPOS_TELEFONES");

                entity.ToTable("tipos_telefones");

                entity.Property(e => e.CodTipoTelefone)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("cod_tipo_telefone");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK_USUARIOS");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Cpf, "AK_USU_CPF")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "AK_USU_USERNAME")
                    .IsUnique();

                entity.Property(e => e.CodUsuario)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("cod_usuario");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
