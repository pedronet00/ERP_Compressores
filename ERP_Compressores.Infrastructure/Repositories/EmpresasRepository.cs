using AutoMapper;
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

public class EmpresasRepository : IEmpresasRepository
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public EmpresasRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> ActivateEmpresa(Empresas empresa)
    {
        empresa.Status = true;
        _context.Empresas.Update(empresa);

        return true;
    }

    public async Task<bool> DeactivateEmpresa(Empresas empresa)
    {
        empresa.Status = false;
        _context.Empresas.Update(empresa);

        return true;
    }

    public async Task<Empresas> AddEmpresaAsync(Empresas empresa)
    {
        if(empresa is null)
            throw new ArgumentNullException(nameof(empresa), "Empresa não pode ser nula!");

        await _context.Empresas.AddAsync(empresa);

        return empresa;
    }

    public async Task<bool> DeleteEmpresaAsync(int id)
    {
        var empresa = await GetEmpresaByIdAsync(id);

        if (empresa is null)
            throw new KeyNotFoundException($"Empresa não encontrada.");

        _context.Empresas.Remove(empresa);

        return true;
    }

    public async Task<IEnumerable<Empresas>> GetAllEmpresasAsync()
    {
        var empresas = await _context.Empresas.AsNoTracking().ToListAsync();

        return empresas;
    }

    public Task<Empresas> GetEmpresaByIdAsync(int id)
    {
        var empresa = _context.Empresas.FirstOrDefaultAsync(e => e.Id == id);

        if (empresa is null)
            throw new KeyNotFoundException($"Empresa não encontrada.");

        return empresa;
    }

    public async Task<Empresas> UpdateEmpresaAsync(Empresas empresa)
    {
        if (empresa is null)
            throw new ArgumentNullException(nameof(empresa), "Empresa não pode ser nula!");

        _context.Empresas.Update(empresa);

        return empresa;
    }

}
