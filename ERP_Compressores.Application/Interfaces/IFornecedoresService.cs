using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IFornecedoresService
{
    Task<IEnumerable<FornecedorViewModel>> GetAllFornecedoresAsync();

    Task<FornecedorViewModel> GetFornecedorByIdAsync(int id);

    Task<FornecedorViewModel> AddFornecedorAsync(FornecedorDTO fornecedor);

    Task<FornecedorViewModel> UpdateFornecedorAsync(FornecedorDTO fornecedor);

    Task<bool> DeleteFornecedorAsync(int id);

    Task<FornecedorViewModel> DeactivateFornecedor(int id);

    Task<FornecedorViewModel> ActivateFornecedor(int id);
}
