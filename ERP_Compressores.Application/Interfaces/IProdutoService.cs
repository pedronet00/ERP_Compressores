using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoViewModel>> GetAllProdutosAsync();

    Task<ProdutoViewModel> GetProdutoByIdAsync(int id);

    Task<ProdutoViewModel> AddProdutoAsync(ProdutoDTO produto);

    Task<ProdutoViewModel> UpdateProdutoAsync(ProdutoDTO produto);

    Task<bool> DeleteProdutoAsync(int id);

    Task<ProdutoViewModel> DeactivateProduto(int id);

    Task<ProdutoViewModel> ActivateProduto(int id);
}
