using ERP_Compressores.Domain.Entities;

namespace ERP_Compressores.Domain.Interfaces;

public interface IItensVendasRepository
{
    Task AdicionarAsync(ItensVendas item);
}
