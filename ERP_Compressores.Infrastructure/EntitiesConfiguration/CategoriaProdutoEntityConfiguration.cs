using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class CategoriaProdutoConfiguration : IEntityTypeConfiguration<CategoriaProduto>
{
    public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
    {
        builder.ToTable("CategoriaProdutos");

        // Chave primária
        builder.HasKey(c => c.Id);

        // Índice único para o Guid
        builder.HasIndex(c => c.Guid)
               .IsUnique();

        // Propriedades
        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd();

        builder.Property(c => c.Guid)
               .IsRequired();

        builder.Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(c => c.Status)
               .IsRequired();

        // Relacionamento com Empresa (N:1)
        builder.HasOne(c => c.Empresa)
               .WithMany(e => e.CategoriasProdutos) // precisa ter ICollection<CategoriaProduto> em Empresa
               .HasForeignKey(c => c.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Produtos (1:N)
        builder.HasMany(c => c.Produtos)
               .WithOne(p => p.CategoriaProduto)
               .HasForeignKey(p => p.CategoriaProdutoId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
