using ERP_Compressores.Domain.Entities;

namespace ERP_Compressores.Domain.Interfaces;

public interface IFornecedoresRepository
{
    Task<IEnumerable<Fornecedores>> GetAllFornecedoresAsync();

    Task<Fornecedores> GetFornecedorByIdAsync(int id);

    Task<Fornecedores> AddFornecedorAsync(Fornecedores fornecedor);

    Task<Fornecedores> UpdateFornecedorAsync(Fornecedores fornecedor);

    Task<bool> DeleteFornecedorAsync(int id);

    Task<bool> DeactivateFornecedor(Fornecedores fornecedor);

    Task<bool> ActivateFornecedor(Fornecedores fornecedor);
}
