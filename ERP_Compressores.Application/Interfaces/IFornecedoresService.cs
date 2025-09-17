using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IFornecedoresService
{
    Task<IEnumerable<FornecedorViewModel>> GetAllFornecedoresAsync();

    Task<DomainNotificationsResult<FornecedorViewModel>> GetFornecedorByIdAsync(int id);

    Task<DomainNotificationsResult<FornecedorViewModel>> AddFornecedorAsync(FornecedorDTO fornecedor);

    Task<DomainNotificationsResult<FornecedorViewModel>> UpdateFornecedorAsync(FornecedorDTO fornecedor);

    Task<DomainNotificationsResult<bool>> DeleteFornecedorAsync(int id);

    Task<DomainNotificationsResult<FornecedorViewModel>> DeactivateFornecedor(int id);

    Task<DomainNotificationsResult<FornecedorViewModel>> ActivateFornecedor(int id);
}
