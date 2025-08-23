using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Compressores.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{

    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ActivateProduto(Produtos produto)
    {
        produto.Status = true;

        _context.Produtos.Update(produto);

        return true;
    }

    public async Task<Produtos> AddProdutoAsync(Produtos produto)
    {
        if (produto is null)
            throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo!"); 

        await _context.Produtos.AddAsync(produto);

        return produto;
    }

    public async Task<bool> DeactivateProduto(Produtos produto)
    {
        produto.Status = false;

        _context.Produtos.Update(produto);

        return true;
    }

    public async Task<bool> DeleteProdutoAsync(int id)
    {
        var produto = await GetProdutoByIdAsync(id);

        if (produto is null)
            throw new KeyNotFoundException($"Produto não encontrado.");

        _context.Produtos.Remove(produto);

        return true;
    }

    public async Task<IEnumerable<Produtos>> GetAllProdutosAsync()
    {
        var produtos = await _context.Produtos.AsNoTracking().ToListAsync();

        return produtos;
    }

    public async Task<Produtos> GetProdutoByIdAsync(int id)
    {
        
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        return produto;
    }

    public async Task<IEnumerable<Produtos>> GetProdutosByCategoriaAsync(int categoriaId)
    {
        var produtos = await _context.Produtos
            .AsNoTracking()
            .Where(p => p.CategoriaProdutoId == categoriaId)
            .ToListAsync();

        return produtos;
    }

    public async Task<Produtos> UpdateProdutoAsync(Produtos produto)
    {
        
        if (produto is null)
            throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo!");

        var existingProduto = await GetProdutoByIdAsync(produto.Id);

        if (existingProduto is null)
            throw new KeyNotFoundException($"Produto não encontrado.");

        _context.Produtos.Update(produto);

        return produto;
    }
}
