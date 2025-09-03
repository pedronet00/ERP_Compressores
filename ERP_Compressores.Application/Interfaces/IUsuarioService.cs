using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioViewModel>> GetAllUsuariosAsync();

    Task<UsuarioViewModel> GetUsuarioByIdAsync(int id);

    //Task<UsuarioViewModel> AddFornecedorAsync(UsuarioDTO usuario);

    Task<UsuarioViewModel> UpdateUsuarioAsync(UsuarioDTO usuario);

    Task<bool> DeleteUsuarioAsync(int id);

    Task<UsuarioViewModel> DeactivateUsuario(int id);

    Task<UsuarioViewModel> ActivateUsuario(int id);
}
