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
    private readonly IUserContextService _userContext;


    public ClientesService(IUnitOfWork unitOfWork, IMapper mapper, IClientesRepository repo, IUserContextService userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repo = repo;
        _userContext = userContext;
    }

    public async Task<ClienteViewModel> ActivateCliente(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId, id);

        if (cliente.Status is true)
            throw new Exception("Cliente já ativo ou não encontrado.");

        await _repo.ActivateCliente(empresaId,cliente);

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
        var empresaId = _userContext.GetEmpresaId();
        return await _repo.CountClientes(empresaId);
    }

    public async Task<ClienteViewModel> DeactivateCliente(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId,id);

        if (cliente.Status is false)
            throw new Exception("Cliente já inativo ou não encontrado.");

        await _repo.DeactivateCliente(empresaId,cliente);

        await _unitOfWork.Commit();

        return _mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<bool> DeleteClienteAsync(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId,id);
        
        if (cliente is null)
            throw new Exception("Cliente não encontrado.");
        
        var result = await _repo.DeleteClienteAsync(empresaId,id);
        
        if (!result)
            throw new Exception("Erro ao deletar o cliente.");
        
        await _unitOfWork.Commit();
        
        return result;
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllClientesAsync()
    {
        var empresaId = _userContext.GetEmpresaId();
        var clientes = await _repo.GetAllClientesAsync(empresaId);

        return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
    }

    public async Task<ClienteViewModel> GetClienteByIdAsync(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId,id);

        return _mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<ClienteViewModel> UpdateClienteAsync(ClienteDTO cliente)
    {
        var empresaId = _userContext.GetEmpresaId();

        if (cliente.Id is <= 0)
            throw new Exception("Dados do cliente não informados.");

        var clienteEntity = _mapper.Map<Domain.Entities.Clientes>(cliente);
        
        var clienteAtualizado = await _repo.UpdateClienteAsync(empresaId,clienteEntity);
        
        await _unitOfWork.Commit();
        
        return _mapper.Map<ClienteViewModel>(clienteAtualizado);
    }
}
