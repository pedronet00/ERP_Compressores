using ERP_Compressores.Domain.Entities;

namespace ERP_Compressores.Domain.Interfaces;

public interface IFornecedoresRepository
{
    Task<IEnumerable<Fornecedores>> GetAllFornecedoresAsync(int empresaId);

    Task<Fornecedores> GetFornecedorByIdAsync(int empresaId, int id);

    Task<Fornecedores> AddFornecedorAsync(Fornecedores fornecedor);

    Task<Fornecedores> UpdateFornecedorAsync(int empresaId, Fornecedores fornecedor);

    Task<bool> DeleteFornecedorAsync(int empresaId, int id);

    Task<bool> DeactivateFornecedor(int empresaId, Fornecedores fornecedor);

    Task<bool> ActivateFornecedor(int empresaId, Fornecedores fornecedor);
}
