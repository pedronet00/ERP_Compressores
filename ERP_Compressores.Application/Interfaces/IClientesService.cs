using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;

namespace ERP_Compressores.Application.Interfaces;

public interface IClientesService
{
    Task<IEnumerable<ClienteViewModel>> GetAllClientesAsync();

    Task<ClienteViewModel> GetClienteByIdAsync(int id);

    Task<ClienteViewModel> AddClienteAsync(ClienteDTO cliente);

    Task<ClienteViewModel> UpdateClienteAsync(ClienteDTO cliente);

    Task<bool> DeleteClienteAsync(int id);

    Task<ClienteViewModel> DeactivateCliente(int id);

    Task<ClienteViewModel> ActivateCliente(int id);

    Task<int> CountClientes();
}
