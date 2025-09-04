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

public class ClientesRepository : IClientesRepository
{

    private readonly AppDbContext _context;

    public ClientesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ActivateCliente(int empresaId, Clientes cliente)
    {
        cliente.Status = true;

        _context.Clientes.Update(cliente);

        return true;
    }

    public async Task<Clientes> AddClienteAsync(Clientes cliente)
    {
        await _context.Clientes.AddAsync(cliente);

        return cliente;
    }

    public async Task<int> CountClientes(int empresaId)
    {
        return await _context.Clientes.CountAsync(c => c.EmpresaId == empresaId);
    }

    public async Task<bool> DeactivateCliente(int empresaId, Clientes cliente)
    {
        cliente.Status = false;

        _context.Clientes.Update(cliente);

        return true;
    }

    public async Task<bool> DeleteClienteAsync(int empresaId, int id)
    {
        var cliente = await GetClienteByIdAsync(empresaId, id);

        _context.Clientes.Remove(cliente);

        return true;
    }

    public async Task<IEnumerable<Clientes>> GetAllClientesAsync(int empresaId)
    {
        var clientes = await _context.Clientes.Where(c => c.EmpresaId == empresaId).ToListAsync();

        return clientes;
    }

    public async Task<Clientes> GetClienteByIdAsync(int empresaId, int id)
    {
        var cliente = await _context.Clientes
                            .FirstOrDefaultAsync(c => c.Id == id && c.EmpresaId == empresaId);


        return cliente;
    }

    public async Task<Clientes> UpdateClienteAsync(int empresaId, Clientes cliente)
    {
        _context.Clientes.Update(cliente);
        
        return cliente;
    }
}
