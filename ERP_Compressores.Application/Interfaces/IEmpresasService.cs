using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IEmpresasService
{
    Task<IEnumerable<EmpresaViewModel>> GetAllEmpresasAsync();

    Task<EmpresaViewModel> GetEmpresaByIdAsync(int id);

    Task<EmpresaViewModel> AddEmpresaAsync(EmpresaDTO empresa);

    Task<EmpresaViewModel> UpdateEmpresaAsync(EmpresaDTO empresa);

    Task<bool> DeleteEmpresaAsync(int id);

    Task<EmpresaViewModel> DeactivateEmpresa(int id);

    Task<EmpresaViewModel> ActivateEmpresa(int id);
}
