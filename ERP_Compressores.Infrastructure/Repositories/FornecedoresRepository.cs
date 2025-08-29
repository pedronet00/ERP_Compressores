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

    public async Task<bool> ActivateFornecedor(int empresaId, Fornecedores fornecedor)
    {
        if(fornecedor is null || fornecedor.EmpresaId != empresaId)
            throw new KeyNotFoundException("Fornecedor não existe");

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

    public async Task<bool> DeactivateFornecedor(int empresaId, Fornecedores fornecedor)
    {
        if (fornecedor is null || fornecedor.EmpresaId != empresaId)
            throw new KeyNotFoundException("Fornecedor não existe");

        fornecedor.Status = false;
        _context.Fornecedores.Update(fornecedor);

        return true;
    }

    public async Task<bool> DeleteFornecedorAsync(int empresaId, int id)
    {
        
        var fornecedor = await GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null)
            throw new KeyNotFoundException("Fornecedor não encontrado");

        _context.Fornecedores.Remove(fornecedor);
        
        return true;
    }

    public async Task<IEnumerable<Fornecedores>> GetAllFornecedoresAsync(int empresaId)
    {

        var fornecedores = await _context.Fornecedores.Where(c => c.EmpresaId == empresaId).AsNoTracking().ToListAsync();

        return fornecedores;
    }

    public async Task<Fornecedores> GetFornecedorByIdAsync(int empresaId, int id)
    {
        var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id && f.EmpresaId == empresaId);

        return fornecedor;
    }

    public async Task<Fornecedores> UpdateFornecedorAsync(int empresaId, Fornecedores fornecedor)
    {
        if (fornecedor is null || fornecedor.EmpresaId != empresaId)
            throw new KeyNotFoundException("Fornecedor não encontrado");
        
        _context.Fornecedores.Update(fornecedor);
        
        return fornecedor;
    }
}
