using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IUsuariosRepository
{
    Task<IEnumerable<Usuarios>> GetAllUsuariosAsync(int empresaId);

    Task<Usuarios> GetUsuarioByIdAsync(int empresaId, int id);

    //Task<Usuarios> AddFornecedorAsync(Usuarios fornecedor);

    Task<Usuarios> UpdateUsuarioAsync(int empresaId, Usuarios usuario);

    Task<bool> DeleteUsuarioAsync(int empresaId, int id);

    Task<bool> DeactivateUsuario(int empresaId, Usuarios usuario);

    Task<bool> ActivateUsuario(int empresaId, Usuarios usuario);
}
