using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface ICategoriaProdutoRepository
{
    Task<IEnumerable<CategoriaProduto>> GetAllCategoriasAsync();

    Task<CategoriaProduto> GetCategoriaByIdAsync(int id);

    Task<CategoriaProduto> AddCategoriaAsync(CategoriaProduto categoria);

    Task<CategoriaProduto> UpdateCategoriaAsync(CategoriaProduto categoria);

    Task<bool> DeleteCategoriaAsync(int id);

    Task<bool> DeactivateCategoria(CategoriaProduto categoria);

    Task<bool> ActivateCategoria(CategoriaProduto categoria);
}
