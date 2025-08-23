using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedores>
{
    public void Configure(EntityTypeBuilder<Fornecedores> builder)
    {
        builder.ToTable("Fornecedores");

        // Chave primária
        builder.HasKey(f => f.Id);

        // Índice único para o Guid
        builder.HasIndex(f => f.Guid)
               .IsUnique();

        // Propriedades
        builder.Property(f => f.Id)
               .ValueGeneratedOnAdd();

        builder.Property(f => f.Guid)
               .IsRequired();

        builder.Property(f => f.Nome)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(f => f.Cnpj)
               .IsRequired()
               .HasMaxLength(18); // 00.000.000/0000-00

        builder.Property(f => f.Telefone)
               .HasMaxLength(20);

        builder.Property(f => f.Email)
               .HasMaxLength(150);

        builder.Property(f => f.Endereco)
               .HasMaxLength(250);

        builder.Property(f => f.Status)
               .IsRequired();

        // Relacionamento com Empresa (N:1)
        builder.HasOne(f => f.Empresa)
               .WithMany(e => e.Fornecedores) 
               .HasForeignKey(f => f.EmpresaId)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Produtos (1:N)
        builder.HasMany(f => f.Produtos)
               .WithOne(p => p.Fornecedor)
               .HasForeignKey(p => p.FornecedorId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
