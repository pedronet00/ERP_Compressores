using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Entities;

namespace ERP_Compressores.Application.Interfaces;

public interface IVendasService
{
    Task<VendasViewModel> RegistrarVendaAsync(RegistrarVendaDTO dto);
    Task<VendasViewModel?> ObterVendaAsync(int id);
    Task<IEnumerable<VendasViewModel>> ListarVendasAsync();

    Task<int> CountVendas();

    Task<List<VendasPorMesViewModel>> ObterVendasAgrupadasPorMesAsync();
}
