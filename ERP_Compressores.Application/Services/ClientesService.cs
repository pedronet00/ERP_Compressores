using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services;

public class ClientesService : IClientesService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClientesRepository _repo;

    public ClientesService(IUnitOfWork unitOfWork, IMapper mapper, IClientesRepository repo)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<ClienteViewModel> ActivateCliente(int id)
    {
        var cliente = await _repo.GetClienteByIdAsync(id);

        if (cliente.Status is true)
            throw new Exception("Cliente já ativo ou não encontrado.");

        await _repo.ActivateCliente(cliente);

        await _unitOfWork.Commit();

        return _mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<ClienteViewModel> AddClienteAsync(ClienteDTO cliente)
    {
        if (cliente is null)
            throw new Exception("Dados do cliente não informados.");

        var clienteEntity = _mapper.Map<Domain.Entities.Clientes>(cliente);

        var novoCliente = await _repo.AddClienteAsync(clienteEntity);

        await _unitOfWork.Commit();

        return _mapper.Map<ClienteViewModel>(novoCliente);
    }

    public async Task<int> CountClientes()
    {
        return await _repo.CountClientes();
    }

    public async Task<ClienteViewModel> DeactivateCliente(int id)
    {
        var cliente = await _repo.GetClienteByIdAsync(id);

        if (cliente.Status is false)
            throw new Exception("Cliente já inativo ou não encontrado.");

        await _repo.DeactivateCliente(cliente);

        await _unitOfWork.Commit();

        return _mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<bool> DeleteClienteAsync(int id)
    {
        
        var cliente = await _repo.GetClienteByIdAsync(id);
        
        if (cliente is null)
            throw new Exception("Cliente não encontrado.");
        
        var result = await _repo.DeleteClienteAsync(id);
        
        if (!result)
            throw new Exception("Erro ao deletar o cliente.");
        
        await _unitOfWork.Commit();
        
        return result;
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllClientesAsync()
    {
        var clientes = await _repo.GetAllClientesAsync();

        return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
    }

    public async Task<ClienteViewModel> GetClienteByIdAsync(int id)
    {
        var cliente = await _repo.GetClienteByIdAsync(id);

        return _mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<ClienteViewModel> UpdateClienteAsync(ClienteDTO cliente)
    {
        
        if (cliente.Id is <= 0)
            throw new Exception("Dados do cliente não informados.");

        var clienteEntity = _mapper.Map<Domain.Entities.Clientes>(cliente);
        
        var clienteAtualizado = await _repo.UpdateClienteAsync(clienteEntity);
        
        await _unitOfWork.Commit();
        
        return _mapper.Map<ClienteViewModel>(clienteAtualizado);
    }
}
