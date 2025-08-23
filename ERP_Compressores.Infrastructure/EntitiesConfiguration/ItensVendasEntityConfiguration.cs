using ERP_Compressores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP_Compressores.Infrastructure.EntitiesConfiguration;

public class ItensVendasConfiguration : IEntityTypeConfiguration<ItensVendas>
{
    public void Configure(EntityTypeBuilder<ItensVendas> builder)
    {
        builder.ToTable("ItensVendas");

        // Chave primária
        builder.HasKey(iv => iv.Id);

        // Índice único para Guid
        builder.HasIndex(iv => iv.Guid)
               .IsUnique();

        // Propriedades
        builder.Property(iv => iv.Id)
               .ValueGeneratedOnAdd();

        builder.Property(iv => iv.Guid)
               .IsRequired();

        builder.Property(iv => iv.Quantidade)
               .IsRequired();

        builder.Property(iv => iv.ValorUnitario)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        // Propriedade calculada Subtotal não precisa ser mapeada no banco
        builder.Ignore(iv => iv.Subtotal);

        // Relacionamento com Vendas (N:1)
        builder.HasOne(iv => iv.Venda)
               .WithMany(v => v.ItensVenda) // precisa ter `public ICollection<ItensVendas> Itens { get; set; }` em Vendas
               .HasForeignKey(iv => iv.VendaId)
               .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com Produtos (N:1)
        builder.HasOne(iv => iv.Produto)
               .WithMany(p => p.ItensVenda) // precisa ter `public ICollection<ItensVendas> ItensVendas { get; set; }` em Produtos
               .HasForeignKey(iv => iv.ProdutoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
