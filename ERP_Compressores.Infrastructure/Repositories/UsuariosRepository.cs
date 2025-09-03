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

public class UsuariosRepository : IUsuariosRepository
{

    private readonly AppDbContext _context;

    public UsuariosRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<bool> ActivateUsuario(int empresaId, Usuarios usuario)
    {
        if (usuario is null || usuario.EmpresaId != empresaId)
            throw new KeyNotFoundException("Usuário não existe.");

        usuario.Status = true;
        _context.Usuarios.Update(usuario);

        return true;
    }

    public async Task<bool> DeactivateUsuario(int empresaId, Usuarios usuario)
    {
        if (usuario is null || usuario.EmpresaId != empresaId)
            throw new KeyNotFoundException("Usuário não existe.");

        usuario.Status = false;
        _context.Usuarios.Update(usuario);

        return true;
    }

    public async Task<bool> DeleteUsuarioAsync(int empresaId, int id)
    {
        var usuario = await GetUsuarioByIdAsync(empresaId, id);

        if (usuario is null)
            throw new KeyNotFoundException("Usuário não existe.");

        _context.Remove(usuario);

        return true;
    }

    public async Task<IEnumerable<Usuarios>> GetAllUsuariosAsync(int empresaId)
    {
        return await _context.Usuarios.Where(u => u.EmpresaId == empresaId).AsNoTracking().ToListAsync();
    }

    public async Task<Usuarios> GetUsuarioByIdAsync(int empresaId, int id)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id && u.EmpresaId == empresaId);

        return usuario!;
    }

    public async Task<Usuarios> UpdateUsuarioAsync(int empresaId, Usuarios usuario)
    {
        if (usuario is null || usuario.EmpresaId != empresaId)
            throw new KeyNotFoundException("Usuário não encontrado");

        _context.Usuarios.Update(usuario);

        return usuario;
    }
}
