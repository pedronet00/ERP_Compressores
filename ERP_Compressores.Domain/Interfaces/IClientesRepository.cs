using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IClientesRepository
{
    Task<IEnumerable<Clientes>> GetAllClientesAsync();

    Task<Clientes> GetClienteByIdAsync(int id);

    Task<Clientes> AddClienteAsync(Clientes cliente);

    Task<Clientes> UpdateClienteAsync(Clientes cliente);

    Task<bool> DeleteClienteAsync(int id);

    Task<bool> DeactivateCliente(Clientes cliente);

    Task<bool> ActivateCliente(Clientes cliente);

    Task<int> CountClientes();
}
