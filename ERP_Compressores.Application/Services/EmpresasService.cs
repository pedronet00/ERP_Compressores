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

public class EmpresasService : IEmpresasService
{

    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IEmpresasRepository _repo;

    public EmpresasService(IUnitOfWork uow, IMapper mapper, IEmpresasRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task<EmpresaViewModel> ActivateEmpresa(int id)
    {
        var empresa = await _repo.GetEmpresaByIdAsync(id);

        if (empresa == null)
        {

            throw new KeyNotFoundException("Empresa não encontrada.");
        }

        if (empresa.Status == true)
        {

            throw new ArgumentException("A empresa já está ativa.");
        }

        await _repo.ActivateEmpresa(empresa);
        await _uow.Commit();


        return _mapper.Map<EmpresaViewModel>(empresa);
    }

    public async Task<EmpresaViewModel> DeactivateEmpresa(int id)
    {
        var empresa = await _repo.GetEmpresaByIdAsync(id);

        if (empresa == null)
        {

            throw new KeyNotFoundException("Empresa não encontrada.");
        }

        if (empresa.Status == false)
        {

            throw new ArgumentException("A empresa já está inativa.");
        }

        await _repo.DeactivateEmpresa(empresa);
        await _uow.Commit();


        return _mapper.Map<EmpresaViewModel>(empresa);
    }

    public async Task<EmpresaViewModel> AddEmpresaAsync(EmpresaDTO empresaDTO)
    {
        if(empresaDTO is null)
            throw new ArgumentNullException(nameof(empresaDTO), "Empresa não pode ser nula!");

        var empresaEntity = _mapper.Map<Domain.Entities.Empresas>(empresaDTO);

        await _repo.AddEmpresaAsync(empresaEntity);

        await _uow.Commit();

        var empresaVM = _mapper.Map<EmpresaViewModel>(empresaEntity);

        return empresaVM;

    }

    public async Task<bool> DeleteEmpresaAsync(int id)
    {
        if(id is <= 0)
            throw new ArgumentException("ID inválido.", nameof(id));

        var result = await _repo.DeleteEmpresaAsync(id);

        if(!result)
            return false;

        await _uow.Commit();

        return true;
    }

    public async Task<IEnumerable<EmpresaViewModel>> GetAllEmpresasAsync()
    {
        var empresas = await _repo.GetAllEmpresasAsync();

        var empresasVM = _mapper.Map<IEnumerable<EmpresaViewModel>>(empresas);

        return empresasVM;
    }

    public async Task<EmpresaViewModel> GetEmpresaByIdAsync(int id)
    {
        if (id is <= 0)
            throw new ArgumentException("ID inválido.", nameof(id));

        var empresa = await _repo.GetEmpresaByIdAsync(id);

        var empresaVM = _mapper.Map<EmpresaViewModel>(empresa);

        return empresaVM;
    }

    public async Task<EmpresaViewModel> UpdateEmpresaAsync(EmpresaDTO empresaDTO)
    {
        if (empresaDTO is null)
            throw new ArgumentNullException(nameof(empresaDTO), "Empresa não pode ser nula!");

        var empresaEntity = _mapper.Map<Domain.Entities.Empresas>(empresaDTO);


        var updatedEmpresa = await _repo.UpdateEmpresaAsync(empresaEntity);


        await _uow.Commit();

        var empresaVM = _mapper.Map<EmpresaViewModel>(updatedEmpresa);

        return empresaVM;
    }
}
