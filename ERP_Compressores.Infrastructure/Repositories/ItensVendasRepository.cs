using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.Repositories;

public class ItensVendasRepository : IItensVendasRepository
{

    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ItensVendasRepository(AppDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItensVendas> AdicionarAsync(ItensVendas item)
    {
        _context.ItensVendas.Add(item);
        await _unitOfWork.Commit();

        return item;
    }

    public async Task<IEnumerable<ItensVendas>> ObterPorVendaIdAsync(int vendaId)
    {
        return await _context.ItensVendas.Where(i => i.VendaId == vendaId).ToListAsync();
    }

    Task IItensVendasRepository.AdicionarAsync(ItensVendas item)
    {
        return AdicionarAsync(item);
    }
}
