using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class ProdutosConfiguration : IEntityTypeConfiguration<Produtos>
{
    public void Configure(EntityTypeBuilder<Produtos> builder)
    {
        builder.ToTable("Produtos");

        // Chave primária
        builder.HasKey(p => p.Id);

        // Índice único para Guid
        builder.HasIndex(p => p.Guid)
               .IsUnique();

        // Propriedades
        builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

        builder.Property(p => p.Guid)
               .IsRequired();

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(p => p.Descricao)
               .HasMaxLength(500);

        builder.Property(p => p.Preco)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.QuantidadeEstoque)
               .IsRequired();

        builder.Property(p => p.DataCadastro)
               .IsRequired();

        builder.Property(p => p.DataAtualizacao);

        builder.Property(p => p.Status)
               .IsRequired();

        // Relacionamento com CategoriaProduto (N:1)
        builder.HasOne(p => p.CategoriaProduto)
               .WithMany(c => c.Produtos)
               .HasForeignKey(p => p.CategoriaProdutoId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Empresa (N:1)
        builder.HasOne(p => p.Empresa)
               .WithMany(e => e.Produtos)
               .HasForeignKey(p => p.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Fornecedor (N:1)
        builder.HasOne(p => p.Fornecedor)
               .WithMany(f => f.Produtos)
               .HasForeignKey(p => p.FornecedorId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com ItensOrcamento (1:N)
        builder.HasMany(p => p.ItensOrcamento)
               .WithOne(io => io.Produto)
               .HasForeignKey(io => io.ProdutoId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com ItensVendas (1:N)
        builder.HasMany(p => p.ItensVenda)
               .WithOne(iv => iv.Produto)
               .HasForeignKey(iv => iv.ProdutoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
