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

        //Services
        services.AddScoped<IEmpresasService, EmpresasService>();
        services.AddScoped<IFornecedoresService, FornecedoresService>();

        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
