using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Notifications;

namespace ERP_Compressores.Application.Interfaces;

public interface IClientesService
{
    Task<IEnumerable<ClienteViewModel>> GetAllClientesAsync();

    Task<DomainNotificationsResult<ClienteViewModel>> GetClienteByIdAsync(int id);

    Task<DomainNotificationsResult<ClienteViewModel>> AddClienteAsync(ClienteDTO cliente);

    Task<DomainNotificationsResult<ClienteViewModel>> UpdateClienteAsync(ClienteDTO cliente);

    Task<DomainNotificationsResult<ClienteViewModel>> DeleteClienteAsync(int id);

    Task<DomainNotificationsResult<ClienteViewModel>> DeactivateCliente(int id);

    Task<DomainNotificationsResult<ClienteViewModel>> ActivateCliente(int id);

    Task<DomainNotificationsResult<ClientesRelatorioViewModel>> GerarRelatorioAsync();

    Task<int> CountClientes();
}
