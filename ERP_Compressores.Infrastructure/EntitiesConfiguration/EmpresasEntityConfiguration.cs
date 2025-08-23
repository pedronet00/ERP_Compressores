using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

internal class EmpresasEntityConfiguration : IEntityTypeConfiguration<Empresas>
{
    public void Configure(EntityTypeBuilder<Empresas> builder)
    {
        builder.ToTable("Empresas");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasAlternateKey(e => e.Guid);

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Cnpj)
            .IsRequired()
            .HasMaxLength(14)
            .IsFixedLength();

        builder.Property(e => e.Telefone)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(e => e.Endereco)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Status)
            .IsRequired()
            .HasDefaultValue(true);

        // Configurações de relacionamentos
        builder.HasMany(e => e.Produtos)
            .WithOne(p => p.Empresa)
            .HasForeignKey(p => p.EmpresaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.CategoriasProdutos)
            .WithOne(cp => cp.Empresa)
            .HasForeignKey(cp => cp.EmpresaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Clientes)
            .WithOne(c => c.Empresa)
            .HasForeignKey(c => c.EmpresaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
