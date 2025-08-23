using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class VisitasTecnicasConfiguration : IEntityTypeConfiguration<VisitasTecnicas>
{
    public void Configure(EntityTypeBuilder<VisitasTecnicas> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Guid)
            .IsRequired();

        builder.Property(v => v.DataVisita)
            .IsRequired();

        builder.Property(v => v.Descricao)
            .HasMaxLength(500);

        builder.Property(v => v.Status)
            .IsRequired();

        builder.HasOne(v => v.Cliente)
            .WithMany(c => c.VisitasTecnicas)
            .HasForeignKey(v => v.ClienteId);

        builder.HasOne(v => v.Empresa)
            .WithMany(e => e.VisitasTecnicas)
            .HasForeignKey(v => v.EmpresaId);

        builder.ToTable("VisitasTecnicas");
    }
}
