using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IVisitasTecnicasService
{
    Task<IEnumerable<VisitasTecnicasViewModel>> GetAllVisitasTecnicassAsync();

    Task<DomainNotificationsResult<VisitasTecnicasViewModel>> GetVisitaTecnicaByIdAsync(int id);

    Task<DomainNotificationsResult<VisitasTecnicasViewModel>> AddVisitaTecnicaAsync(VisitasTecnicasDTO visita);

    Task<DomainNotificationsResult<VisitasTecnicasViewModel>> UpdateVisitaTecnicaAsync(VisitasTecnicasDTO visita);

    Task<DomainNotificationsResult<VisitasTecnicasViewModel>> DeleteVisitaTecnicaAsync(int id);

    Task<DomainNotificationsResult<VisitasTecnicasViewModel>> ConcluirVisitaTecnica(int id);

    Task<DomainNotificationsResult<VisitasTecnicasViewModel>> CancelarVisitaTecnica(int id);
}
