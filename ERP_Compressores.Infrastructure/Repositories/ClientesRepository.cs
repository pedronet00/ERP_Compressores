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

    public async Task<bool> ActivateCliente(Clientes cliente)
    {
        cliente.Status = true;

        _context.Clientes.Update(cliente);

        return true;
    }

    public async Task<Clientes> AddClienteAsync(Clientes cliente)
    {
        if (cliente is null)
            throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo!");

        await _context.Clientes.AddAsync(cliente);

        return cliente;
    }

    public async Task<int> CountClientes()
    {   
        return await _context.Clientes.CountAsync();
    }

    public async Task<bool> DeactivateCliente(Clientes cliente)
    {
        cliente.Status = false;

        _context.Clientes.Update(cliente);

        return true;
    }

    public async Task<bool> DeleteClienteAsync(int id)
    {
        var cliente = await GetClienteByIdAsync(id);

        if (cliente is null)
            throw new KeyNotFoundException($"Cliente não encontrado.");

        _context.Clientes.Remove(cliente);

        return true;
    }

    public async Task<IEnumerable<Clientes>> GetAllClientesAsync()
    {
        var clientes = await _context.Clientes.ToListAsync();

        return clientes;
    }

    public async Task<Clientes> GetClienteByIdAsync(int id)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

        return cliente;
    }

    public async Task<Clientes> UpdateClienteAsync(Clientes cliente)
    {
        if (cliente is null)
            throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo!");
        
        _context.Clientes.Update(cliente);
        
        return cliente;
    }
}
