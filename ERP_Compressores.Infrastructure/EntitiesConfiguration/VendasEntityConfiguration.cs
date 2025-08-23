using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class VendasConfiguration : IEntityTypeConfiguration<Vendas>
{
    public void Configure(EntityTypeBuilder<Vendas> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Guid)
            .IsRequired();

        builder.HasIndex(v => v.Guid)
            .IsUnique();

        builder.Property(v => v.DataVenda)
            .IsRequired();

        builder.Property(v => v.ValorOriginal)
            .HasColumnType("decimal(18,2)");

        builder.Property(v => v.ValorTotal)
            .HasColumnType("decimal(18,2)");

        builder.Property(v => v.DescontoPercentual);

        builder.Property(v => v.Descricao)
            .HasMaxLength(500);

        builder.Property(v => v.Status)
            .IsRequired();

        builder.HasOne(v => v.Cliente)
            .WithMany(c => c.Vendas)
            .HasForeignKey(v => v.ClienteId);

        builder.HasOne(v => v.Empresa)
            .WithMany(e => e.Vendas)
            .HasForeignKey(v => v.EmpresaId);

        builder.HasMany(v => v.ItensVenda)
            .WithOne(i => i.Venda)
            .HasForeignKey(i => i.VendaId);
    }
}
