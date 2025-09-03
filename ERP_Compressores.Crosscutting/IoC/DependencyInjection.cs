using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.Services;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Infrastructure.Repositories;
using ERP_Compressores.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ERP_Compressores.Crosscutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IEmpresasRepository, EmpresasRepository>();
        services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
        services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IClientesRepository, ClientesRepository>();
        services.AddScoped<IVendasRepository, VendasRepository>();
        services.AddScoped<IItensVendasRepository, ItensVendasRepository>();
        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        //Services
        services.AddScoped<IEmpresasService, EmpresasService>();
        services.AddScoped<IFornecedoresService, FornecedoresService>();
        services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IClientesService, ClientesService>();
        services.AddScoped<IVendasService, VendasService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IUserContextService, UserContextService>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Token
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
