using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IEmpresasRepository
{
    Task<IEnumerable<Empresas>> GetAllEmpresasAsync();

    Task<Empresas> GetEmpresaByIdAsync(int id);

    Task<Empresas> AddEmpresaAsync(Empresas empresa);

    Task<Empresas> UpdateEmpresaAsync(Empresas empresa);

    Task<bool> DeleteEmpresaAsync(int id);

    Task<bool> DeactivateEmpresa(Empresas empresa);

    Task<bool> ActivateEmpresa(Empresas empresa);
}
