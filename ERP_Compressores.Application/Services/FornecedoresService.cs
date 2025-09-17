using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services;

public class FornecedoresService : IFornecedoresService 
{
    private readonly IMapper _mapper;
    private readonly IFornecedoresRepository _repo;
    private readonly IUnitOfWork _uow;
    private readonly IUserContextService _userContext;

    public FornecedoresService(IMapper mapper, IFornecedoresRepository repo, IUnitOfWork uow, IUserContextService userContext)
    {
        _mapper = mapper;
        _repo = repo;
        _uow = uow;
        _userContext = userContext;
    }

    public async Task<DomainNotificationsResult<FornecedorViewModel>> ActivateFornecedor(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);
        var result = new DomainNotificationsResult<FornecedorViewModel>();

        if (fornecedor is null || fornecedor.Status == true)
            result.Notifications.Add("Fornecedor não encontrado ou já ativo.");

        if(result.Notifications.Any())
            return result;

        await _repo.ActivateFornecedor(empresaId, fornecedor);

        await _uow.Commit();

        result.Result = _mapper.Map<FornecedorViewModel>(fornecedor);

        return result;
    }

    public async Task<DomainNotificationsResult<FornecedorViewModel>> AddFornecedorAsync(FornecedorDTO fornecedor)
    {
        var result = new DomainNotificationsResult<FornecedorViewModel>();

        if (fornecedor is null)
            result.Notifications.Add("Dados do fornecedor não podem ser nulos.");

        if(result.Notifications.Any())
            return result;

        var fornecedorEntity = _mapper.Map<Domain.Entities.Fornecedores>(fornecedor);

        var newFornecedor = await _repo.AddFornecedorAsync(fornecedorEntity);

        await _uow.Commit();

        result.Result = _mapper.Map<FornecedorViewModel>(newFornecedor);

        return result;
    }

    public async Task<DomainNotificationsResult<FornecedorViewModel>> DeactivateFornecedor(int id)
    {
        var result = new DomainNotificationsResult<FornecedorViewModel>();
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null || fornecedor.Status == false)
            result.Notifications.Add("Fornecedor não encontrado ou já inativo.");

        if(result.Notifications.Any())
            return result;

        await _repo.DeactivateFornecedor(empresaId, fornecedor);

        await _uow.Commit();

        result.Result = _mapper.Map<FornecedorViewModel>(fornecedor);

        return result;
    }

    public async Task<DomainNotificationsResult<bool>> DeleteFornecedorAsync(int id)
    {
        var result = new DomainNotificationsResult<bool>();
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null)
            result.Notifications.Add("Fornecedor não encontrado.");

        if(result.Notifications.Any())
            return result;

        await _repo.DeleteFornecedorAsync(empresaId, id);

        await _uow.Commit();

        result.Result =  true;

        return result;
    }

    public async Task<IEnumerable<FornecedorViewModel>> GetAllFornecedoresAsync()
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedores = await _repo.GetAllFornecedoresAsync(empresaId);

        return _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);
    }

    public async Task<DomainNotificationsResult<FornecedorViewModel>> GetFornecedorByIdAsync(int id)
    {
        var result = new DomainNotificationsResult<FornecedorViewModel>();
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null)
            result.Notifications.Add("Fornecedor não encontrado.");

        result.Result = _mapper.Map<FornecedorViewModel>(fornecedor);

        return result;
    }

    public async Task<DomainNotificationsResult<FornecedorViewModel>> UpdateFornecedorAsync(FornecedorDTO fornecedor)
    {
        var result = new DomainNotificationsResult<FornecedorViewModel>();
        var empresaId = _userContext.GetEmpresaId();
        var fornecedorEntity = await _repo.GetFornecedorByIdAsync(empresaId, fornecedor.Id);

        if (fornecedorEntity is null)
            result.Notifications.Add("Fornecedor não encontrado.");

        if(result.Notifications.Any())
            return result;

        _mapper.Map(fornecedor, fornecedorEntity);

        var updatedFornecedor = await _repo.UpdateFornecedorAsync(empresaId, fornecedorEntity);

        await _uow.Commit();

        result.Result = _mapper.Map<FornecedorViewModel>(updatedFornecedor);

        return result;
    }
}
