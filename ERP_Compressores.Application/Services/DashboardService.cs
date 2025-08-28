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

    public DashboardService(IVendasRepository vendaRepository, IClientesRepository clienteRepository)
    {
        _vendaRepository = vendaRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<DashboardViewModel> ObterDashboardAsync()
    {
        var totalVendas = await _vendaRepository.CountVendas();
        var totalClientes = await _clienteRepository.CountClientes();
       // var vendasPorMes = await _vendaRepository.ObterVendasAgrupadasPorMesAsync();

        return new DashboardViewModel
        {
            TotalVendas = totalVendas,
            TotalClientes = totalClientes,
            //ValorVendasMesAtual = vendasPorMes.FirstOrDefault(m => m.Mes == DateTime.Now.Month)?.ValorTotal ?? 0,
            //VendasPorMes = vendasPorMes
        };
    }
}
