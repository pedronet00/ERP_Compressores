using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

internal class ClientesEntityConfiguration : IEntityTypeConfiguration<Clientes>
{
    public void Configure(EntityTypeBuilder<Clientes> builder)
    {
        builder.ToTable("Clientes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasAlternateKey(c => c.Guid);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Cpf)
            .IsRequired()
            .HasMaxLength(11)
            .IsFixedLength();

        builder.Property(c => c.Telefone)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Endereco)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Status)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(c => c.EmpresaId)
            .IsRequired();

        builder.HasOne(c => c.Empresa)
       .WithMany(e => e.Clientes)
       .HasForeignKey(c => c.EmpresaId)
       .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Vendas)
            .WithOne(v => v.Cliente)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Orcamentos)
            .WithOne(o => o.Cliente)
            .HasForeignKey(o => o.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.VisitasTecnicas)
            .WithOne(vt => vt.Cliente)
            .HasForeignKey(vt => vt.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
