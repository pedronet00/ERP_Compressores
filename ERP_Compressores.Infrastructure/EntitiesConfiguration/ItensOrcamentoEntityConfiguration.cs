using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;
public class ItensOrcamentoConfiguration : IEntityTypeConfiguration<ItensOrcamento>
{
    public void Configure(EntityTypeBuilder<ItensOrcamento> builder)
    {
        builder.ToTable("ItensOrcamento");

        // Chave primária
        builder.HasKey(io => io.Id);

        // Índice único para Guid
        builder.HasIndex(io => io.Guid)
               .IsUnique();

        // Propriedades
        builder.Property(io => io.Id)
               .ValueGeneratedOnAdd();

        builder.Property(io => io.Guid)
               .IsRequired();

        builder.Property(io => io.PrecoUnitario)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(io => io.Quantidade)
               .IsRequired();

        builder.Property(io => io.ValorTotal)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        // Relacionamento com Orcamentos (N:1)
        builder.HasOne(io => io.Orcamento)
               .WithMany(o => o.ItensOrcamento) // precisa ter `public ICollection<ItensOrcamento> Itens { get; set; }` em Orcamentos
               .HasForeignKey(io => io.OrcamentoId)
               .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com Produtos (N:1)
        builder.HasOne(io => io.Produto)
               .WithMany(p => p.ItensOrcamento) // precisa ter `public ICollection<ItensOrcamento> ItensOrcamento { get; set; }` em Produtos
               .HasForeignKey(io => io.ProdutoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
