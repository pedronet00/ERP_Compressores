using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Compressores.Infrastructure.Repositories;

public class CategoriaProdutoRepository : ICategoriaProdutoRepository
{

    private readonly AppDbContext _context;

    public CategoriaProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ActivateCategoria(CategoriaProduto categoria)
    {
        if(categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        categoria.Status = true;
        _context.CategoriasProdutos.Update(categoria);

        return true;
    }

    public async Task<CategoriaProduto> AddCategoriaAsync(CategoriaProduto categoria)
    {
        if(categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        await _context.CategoriasProdutos.AddAsync(categoria);

        return categoria;
    }

    public async Task<bool> DeactivateCategoria(CategoriaProduto categoria)
    {
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        categoria.Status = false;
        _context.CategoriasProdutos.Update(categoria);

        return true;
    }

    public async Task<bool> DeleteCategoriaAsync(int id)
    {
        var categoria = await GetCategoriaByIdAsync(id);

        _context.CategoriasProdutos.Remove(categoria);

        return true;
    }

    public async Task<IEnumerable<CategoriaProduto>> GetAllCategoriasAsync()
    {
        var categorias = await _context.CategoriasProdutos.AsNoTracking().ToListAsync();

        return categorias;
    }

    public async Task<CategoriaProduto> GetCategoriaByIdAsync(int id)
    {
        var categoria = await _context.CategoriasProdutos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        return categoria ?? throw new ArgumentNullException("Categoria não encontrada");
    }

    public async Task<CategoriaProduto> UpdateCategoriaAsync(CategoriaProduto categoria)
    {
        if(categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.CategoriasProdutos.Update(categoria);

        return categoria;
    }
}
