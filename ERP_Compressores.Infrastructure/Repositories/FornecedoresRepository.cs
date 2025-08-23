using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP_Compressores.Infrastructure.Repositories;

public class FornecedoresRepository : IFornecedoresRepository
{

    private readonly AppDbContext _context;

    public FornecedoresRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ActivateFornecedor(Fornecedores fornecedor)
    {
        if(fornecedor is null)
            throw new ArgumentNullException("Fornecedor não pode ser nulo");

        fornecedor.Status = true;
        _context.Fornecedores.Update(fornecedor);

        return true;
    }

    public async Task<Fornecedores> AddFornecedorAsync(Fornecedores fornecedor)
    {
        if(fornecedor is null)
            throw new ArgumentNullException("Fornecedor não pode ser nulo");

        await _context.Fornecedores.AddAsync(fornecedor);

        return fornecedor;
    }

    public async Task<bool> DeactivateFornecedor(Fornecedores fornecedor)
    {
        if (fornecedor is null)
            throw new ArgumentNullException("Fornecedor não pode ser nulo");

        fornecedor.Status = false;
        _context.Fornecedores.Update(fornecedor);

        return true;
    }

    public async Task<bool> DeleteFornecedorAsync(int id)
    {
        
        var fornecedor = await GetFornecedorByIdAsync(id);

        if (fornecedor is null)
            throw new ArgumentNullException("Fornecedor não encontrado");

        _context.Fornecedores.Remove(fornecedor);
        
        return true;
    }

    public async Task<IEnumerable<Fornecedores>> GetAllFornecedoresAsync()
    {

        var fornecedores = await _context.Fornecedores.AsNoTracking().ToListAsync();

        return fornecedores;
    }

    public async Task<Fornecedores> GetFornecedorByIdAsync(int id)
    {
        var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id);

        return fornecedor;
    }

    public async Task<Fornecedores> UpdateFornecedorAsync(Fornecedores fornecedor)
    {
        if (fornecedor is null)
            throw new ArgumentNullException("Fornecedor não pode ser nulo");
        
        _context.Fornecedores.Update(fornecedor);
        
        return fornecedor;
    }
}
