using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Domain.ValueObjects;
using ERP_Compressores.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.Repositories;

public class VendasRepository : IVendasRepository
{

    private readonly AppDbContext _context;

    public VendasRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Vendas> AdicionarAsync(Vendas venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    public async Task<int> CountVendas()
    {
        return await _context.Vendas.CountAsync();
    }

    public async Task<IEnumerable<Vendas>> ListarAsync()
    {
        return await _context.Vendas
            .Include(v => v.Cliente)
            .Include(v => v.ItensVenda)
            .ToListAsync(); 
    }

    public async Task<Vendas?> ObterPorIdAsync(int id)
    {
        return await _context.Vendas.Include(v => v.ItensVenda).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<List<VendasPorMes>> ObterVendasAgrupadasPorMesAsync()
    {
        return await _context.Vendas
        .GroupBy(v => new { v.DataVenda.Year, v.DataVenda.Month })
        .Select(g => new VendasPorMes
        {
            Ano = g.Key.Year,
            Mes = g.Key.Month,
            ValorTotal = g.Sum(x => x.ValorTotal)
        })
        .OrderBy(v => v.Ano)
        .ThenBy(v => v.Mes)
        .ToListAsync();
    }

    Task IVendasRepository.AdicionarAsync(Vendas venda)
    {
        return AdicionarAsync(venda);
    }
}
