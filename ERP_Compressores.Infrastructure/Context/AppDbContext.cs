using ERP_Compressores.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP_Compressores.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<Usuarios>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Empresas> Empresas { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
    public DbSet<Vendas> Vendas { get; set; }
    public DbSet<ItensVendas> ItensVendas { get; set; }
    public DbSet<Fornecedores> Fornecedores { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<ItensOrcamento> ItensOrcamentos { get; set; }
    public DbSet<Orcamentos> Orcamentos { get; set; }
    public DbSet<VisitasTecnicas> VisitasTecnicas { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
