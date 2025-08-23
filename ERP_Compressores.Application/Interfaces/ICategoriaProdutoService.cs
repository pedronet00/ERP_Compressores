using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface ICategoriaProdutoService
{
    Task<IEnumerable<CategoriaProdutoViewModel>> GetAllCategoriasAsync();

    Task<CategoriaProdutoViewModel> GetCategoriaByIdAsync(int id);

    Task<CategoriaProdutoViewModel> AddCategoriaAsync(CategoriaProdutoDTO categoria);

    Task<CategoriaProdutoViewModel> UpdateCategoriaAsync(CategoriaProdutoDTO categoria);

    Task<bool> DeleteCategoriaAsync(int id);

    Task<CategoriaProdutoViewModel> DeactivateCategoria(int id);

    Task<CategoriaProdutoViewModel> ActivateCategoria(int id);
}
