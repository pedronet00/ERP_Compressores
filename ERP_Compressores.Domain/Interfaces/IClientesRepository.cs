using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IClientesRepository
{
    Task<IEnumerable<Clientes>> GetAllClientesAsync(int empresaId);

    Task<Clientes> GetClienteByIdAsync(int empresaId, int id);

    Task<Clientes> AddClienteAsync(Clientes cliente);

    Task<Clientes> UpdateClienteAsync(int empresaId, Clientes cliente);

    Task<bool> DeleteClienteAsync(int empresaId, int id);

    Task<bool> DeactivateCliente(int empresaId, Clientes cliente);

    Task<bool> ActivateCliente(int empresaId, Clientes cliente);

    Task<int> CountClientes(int empresaId);

    Task<int> CountClientesUltimoMesAsync(int empresaId);
    Task<Clientes?> GetClienteQueMaisComprouAsync(int empresaId);

    // Validações
    Task<bool> ExistsByEmailAsync(int empresaId, string email);
    Task<bool> ExistsByCpfAsync(int empresaId, string cpf);
}
