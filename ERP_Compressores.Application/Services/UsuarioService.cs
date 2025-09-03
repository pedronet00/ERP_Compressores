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

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuariosRepository _repo;
    private readonly IUnitOfWork _uow;
    private readonly IUserContextService _userContext;

    public UsuarioService(IMapper mapper, IUsuariosRepository repo, IUnitOfWork uow, IUserContextService userContext)
    {
        _mapper = mapper;
        _repo = repo;
        _uow = uow;
        _userContext = userContext;
    }

    public async Task<UsuarioViewModel> ActivateUsuario(int id)
    {
        var empresaId = _userContext.GetEmpresaId();

        var usuario = await _repo.GetUsuarioByIdAsync(empresaId, id);

        if (usuario.Status is true)
            throw new Exception("Usuário não encontrado ou já ativo.");

        await _repo.ActivateUsuario(empresaId, usuario);

        await _uow.Commit();

        return _mapper.Map<UsuarioViewModel>(usuario);
    }

    public async Task<UsuarioViewModel> DeactivateUsuario(int id)
    {
        var empresaId = _userContext.GetEmpresaId();

        var usuario = await _repo.GetUsuarioByIdAsync(empresaId, id);

        if (usuario.Status is false)
            throw new Exception("Usuário não encontrado ou já inativo.");

        await _repo.DeactivateUsuario(empresaId, usuario);

        await _uow.Commit();

        return _mapper.Map<UsuarioViewModel>(usuario);
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        var empresaId = _userContext.GetEmpresaId();
        var usuario = await _repo.GetUsuarioByIdAsync(empresaId, id);

        if (usuario is null)
            throw new ArgumentNullException("Usuário não encontrado");

        await _repo.DeleteUsuarioAsync(empresaId, id);

        await _uow.Commit();

        return true;
    }

    public async Task<IEnumerable<UsuarioViewModel>> GetAllUsuariosAsync()
    {
        var empresaId = _userContext.GetEmpresaId();

        var usuarios =  await _repo.GetAllUsuariosAsync(empresaId);

        return _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
    }

    public async Task<UsuarioViewModel> GetUsuarioByIdAsync(int id)
    {
        var empresaId = _userContext.GetEmpresaId();

        var usuario = await _repo.GetUsuarioByIdAsync(empresaId, id);

        return _mapper.Map<UsuarioViewModel>(usuario);
    }

    public async Task<UsuarioViewModel> UpdateUsuarioAsync(UsuarioDTO usuario)
    {
        var empresaId = _userContext.GetEmpresaId();
        var usuarioEntity = await _repo.GetUsuarioByIdAsync(empresaId, usuario.Id);

        if (usuarioEntity is null)
            throw new ArgumentNullException("Fornecedor não encontrado");

        _mapper.Map(usuario, usuarioEntity);

        var updatedUsuario = await _repo.UpdateUsuarioAsync(empresaId, usuarioEntity);

        await _uow.Commit();

        return _mapper.Map<UsuarioViewModel>(updatedUsuario);
    }
}
