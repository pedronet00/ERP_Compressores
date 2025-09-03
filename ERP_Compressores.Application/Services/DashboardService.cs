using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IVendasRepository _vendaRepository;
    private readonly IClientesRepository _clienteRepository;
    private readonly IUserContextService _userContext;


    public DashboardService(IVendasRepository vendaRepository, IClientesRepository clienteRepository, IUserContextService userContext)
    {
        _vendaRepository = vendaRepository;
        _clienteRepository = clienteRepository;
        _userContext = userContext;
    }

    public async Task<DashboardViewModel> ObterDashboardAsync()
    {
        var empresaId = _userContext.GetEmpresaId();

        var totalVendas = await _vendaRepository.CountVendas();
        var totalClientes = await _clienteRepository.CountClientes(empresaId);
        var vendasPorMes = await _vendaRepository.ObterVendasAgrupadasPorMesAsync();

        // Garantir todos os meses do ano
        var anoAtual = DateTime.Now.Year;
        var todosMeses = Enumerable.Range(1, 12)
            .Select(m => new
            {
                Ano = anoAtual,
                Mes = m,
                ValorTotal = vendasPorMes.FirstOrDefault(v => v.Mes == m && v.Ano == anoAtual)?.ValorTotal ?? 0
            })
            .ToList();

        return new DashboardViewModel
        {
            TotalVendas = totalVendas,
            TotalClientes = totalClientes,
            ValorVendasMesAtual = todosMeses.First(m => m.Mes == DateTime.Now.Month).ValorTotal,
            VendasPorMes = todosMeses.Select(v => new VendasPorMesViewModel
            {
                Ano = v.Ano,
                Mes = v.Mes,
                ValorTotal = v.ValorTotal
            }).ToList()
        };
    }


}
