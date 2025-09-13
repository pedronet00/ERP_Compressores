using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Enums;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Infrastructure.Repositories;

public class VisitasTecnicasRepository : IVisitasTecnicasRepository
{
    private readonly AppDbContext _context;

    public VisitasTecnicasRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VisitasTecnicas> AddVisitaAsync(VisitasTecnicas visita)
    {
        await _context.VisitasTecnicas.AddAsync(visita);

        return visita;
    }

    public async Task<bool> CancelarVisita(int empresaId, VisitasTecnicas visita)
    {
        visita.Status = StatusVisitasTecnicasEnum.Cancelada;

        _context.VisitasTecnicas.Update(visita);

        return true;
    }

    public async Task<bool> ConcluirVisita(int empresaId, VisitasTecnicas visita)
    {
        visita.Status = StatusVisitasTecnicasEnum.Concluida;

        _context.VisitasTecnicas.Update(visita);

        return true;
    }

    public async Task<bool> DeleteVisitaAsync(int empresaId, int id)
    {
        var visita = await GetVisitaByIdAsync(empresaId, id);

        _context.VisitasTecnicas.Remove(visita);

        return true;
    }

    public async Task<IEnumerable<VisitasTecnicas>> GetAlVisitasAsync(int empresaId)
    {
        var visitas = await _context.VisitasTecnicas
            .Where(c => c.EmpresaId == empresaId)
            .Include(v => v.Cliente)
            .AsNoTracking()
            .ToListAsync();

        return visitas;
    }

    public async Task<VisitasTecnicas> GetVisitaByIdAsync(int empresaId, int id)
    {
        var visita = await _context.VisitasTecnicas
                            .FirstOrDefaultAsync(c => c.Id == id && c.EmpresaId == empresaId);

        return visita;
    }

    public async Task<VisitasTecnicas> UpdateVisitaAsync(int empresaId, VisitasTecnicas visita)
    {
        _context.VisitasTecnicas.Update(visita);

        return visita;
    }
}
