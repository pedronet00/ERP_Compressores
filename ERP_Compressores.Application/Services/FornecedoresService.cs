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

    public async Task<FornecedorViewModel> ActivateFornecedor(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null || fornecedor.Status == true)
            throw new ArgumentNullException("Fornecedor não encontrado ou já ativo.");

        await _repo.ActivateFornecedor(empresaId, fornecedor);

        await _uow.Commit();

        return _mapper.Map<FornecedorViewModel>(fornecedor);
    }

    public async Task<FornecedorViewModel> AddFornecedorAsync(FornecedorDTO fornecedor)
    {
        if (fornecedor is null)
            throw new ArgumentNullException("Fornecedor não pode ser nulo");

        var fornecedorEntity = _mapper.Map<Domain.Entities.Fornecedores>(fornecedor);

        var newFornecedor = await _repo.AddFornecedorAsync(fornecedorEntity);

        await _uow.Commit();

        return _mapper.Map<FornecedorViewModel>(newFornecedor);
    }

    public async Task<FornecedorViewModel> DeactivateFornecedor(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null || fornecedor.Status == false)
            throw new ArgumentNullException("Fornecedor não encontrado ou já inativo.");

        await _repo.DeactivateFornecedor(empresaId, fornecedor);

        await _uow.Commit();

        return _mapper.Map<FornecedorViewModel>(fornecedor);
    }

    public async Task<bool> DeleteFornecedorAsync(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null)
            throw new ArgumentNullException("Fornecedor não encontrado");

        await _repo.DeleteFornecedorAsync(empresaId, id);

        await _uow.Commit();

        return true;
    }

    public async Task<IEnumerable<FornecedorViewModel>> GetAllFornecedoresAsync()
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedores = await _repo.GetAllFornecedoresAsync(empresaId);

        return _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);
    }

    public async Task<FornecedorViewModel> GetFornecedorByIdAsync(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedor = await _repo.GetFornecedorByIdAsync(empresaId, id);

        if (fornecedor is null)
            throw new ArgumentNullException("Fornecedor não encontrado");

        return _mapper.Map<FornecedorViewModel>(fornecedor);
    }

    public async Task<FornecedorViewModel> UpdateFornecedorAsync(FornecedorDTO fornecedor)
    {
        var empresaId = _userContext.GetEmpresaId();
        var fornecedorEntity = await _repo.GetFornecedorByIdAsync(empresaId, fornecedor.Id);

        if (fornecedorEntity is null)
            throw new ArgumentNullException("Fornecedor não encontrado");

        _mapper.Map(fornecedor, fornecedorEntity);

        var updatedFornecedor = await _repo.UpdateFornecedorAsync(empresaId, fornecedorEntity);

        await _uow.Commit();

        return _mapper.Map<FornecedorViewModel>(updatedFornecedor);
    }
}
