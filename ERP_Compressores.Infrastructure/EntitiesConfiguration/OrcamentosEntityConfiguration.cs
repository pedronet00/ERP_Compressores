using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class OrcamentosConfiguration : IEntityTypeConfiguration<Orcamentos>
{
    public void Configure(EntityTypeBuilder<Orcamentos> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasIndex(o => o.Guid).IsUnique();

        builder.Property(o => o.Guid)
            .IsRequired();

        builder.HasOne(o => o.Cliente)
            .WithMany(c => c.Orcamentos)
            .HasForeignKey(o => o.ClienteId);

        builder.HasOne(o => o.Empresa)
            .WithMany(e => e.Orcamentos)
            .HasForeignKey(o => o.EmpresaId);

        builder.Property(o => o.Descricao)
            .HasMaxLength(500);

        builder.Property(o => o.ValorTotal)
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.ValorOriginal)
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.DescontoPercentual)
            .HasDefaultValue(0);
    }
}
