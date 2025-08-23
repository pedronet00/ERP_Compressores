using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produtos>> GetAllProdutosAsync();
    
    Task<Produtos> GetProdutoByIdAsync(int id);

    Task<IEnumerable<Produtos>> GetProdutosByCategoriaAsync(int categoriaId);

    Task<Produtos> AddProdutoAsync(Produtos produto);

    Task<Produtos> UpdateProdutoAsync(Produtos produto);

    Task<bool> DeleteProdutoAsync(int id);

    Task<bool> DeactivateProduto(Produtos produto);

    Task<bool> ActivateProduto(Produtos produto);
}
