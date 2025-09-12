using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Domain.Notifications;
using ERP_Compressores.Domain.Enums;

namespace ERP_Compressores.Application.Services;

public class VisitasTecnicasService : IVisitasTecnicasService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IVisitasTecnicasRepository _repo;
    private readonly IUserContextService _userContext;


    public VisitasTecnicasService(IUnitOfWork unitOfWork, IMapper mapper, IVisitasTecnicasRepository repo, IUserContextService userContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repo = repo;
        _userContext = userContext;
    }

    public async Task<DomainNotificationsResult<VisitasTecnicasViewModel>> AddVisitaTecnicaAsync(VisitasTecnicasDTO visita)
    {
        var resultNotification = new DomainNotificationsResult<VisitasTecnicasViewModel>();

        if(visita is null)
        {
            resultNotification.Notifications.Add("Visita não pode ser nula.");
        }

        if (resultNotification.Notifications.Any())
            return resultNotification;

        var visitaEntity = _mapper.Map<VisitasTecnicas>(visita);

        var novaVisita = await _repo.AddVisitaAsync(visitaEntity);

        await _unitOfWork.Commit();

        resultNotification.Result = _mapper.Map<VisitasTecnicasViewModel>(novaVisita);

        return resultNotification;

    }

    public async Task<DomainNotificationsResult<VisitasTecnicasViewModel>> CancelarVisitaTecnica(int id)
    {
        var resultNotification = new DomainNotificationsResult<VisitasTecnicasViewModel>();
        var empresaId = _userContext.GetEmpresaId();

        var visita = await _repo.GetVisitaByIdAsync(empresaId, id);

        if (visita is null)
            resultNotification.Notifications.Add("Visita não existe.");
        

        if(visita.Status == StatusVisitasTecnicasEnum.Cancelada ||  visita.Status == StatusVisitasTecnicasEnum.Concluida)
            resultNotification.Notifications.Add("Visita já está cancelada ou concluída.");
        

        if(resultNotification.Notifications.Any())
            return resultNotification;

        await _repo.CancelarVisita(empresaId, visita!);

        await _unitOfWork.Commit();

        resultNotification.Result = _mapper.Map<VisitasTecnicasViewModel>(visita);

        return resultNotification;
    }

    public async Task<DomainNotificationsResult<VisitasTecnicasViewModel>> ConcluirVisitaTecnica(int id)
    {
        var resultNotification = new DomainNotificationsResult<VisitasTecnicasViewModel>();
        var empresaId = _userContext.GetEmpresaId();

        var visita = await _repo.GetVisitaByIdAsync(empresaId, id);

        if (visita is null)
            resultNotification.Notifications.Add("Visita não existe.");


        if (visita.Status == StatusVisitasTecnicasEnum.Cancelada || visita.Status == StatusVisitasTecnicasEnum.Concluida)
            resultNotification.Notifications.Add("Visita já está cancelada ou concluída.");


        if (resultNotification.Notifications.Any())
            return resultNotification;

        await _repo.ConcluirVisita(empresaId, visita!);

        await _unitOfWork.Commit();

        resultNotification.Result = _mapper.Map<VisitasTecnicasViewModel>(visita);

        return resultNotification;
    }

    public async Task<DomainNotificationsResult<VisitasTecnicasViewModel>> DeleteVisitaTecnicaAsync(int id)
    {
        var resultNotification = new DomainNotificationsResult<VisitasTecnicasViewModel>();
        var empresaId = _userContext.GetEmpresaId();

        var visita = await _repo.GetVisitaByIdAsync(empresaId, id);

        if (visita is null)
            resultNotification.Notifications.Add("Visita não existe.");


        if (resultNotification.Notifications.Any())
            return resultNotification;

        await _repo.DeleteVisitaAsync(empresaId, id);

        await _unitOfWork.Commit();

        resultNotification.Result = _mapper.Map<VisitasTecnicasViewModel>(visita);

        return resultNotification;
    }

    public async Task<IEnumerable<VisitasTecnicasViewModel>> GetAllVisitasTecnicassAsync()
    {
        var empresaId = _userContext.GetEmpresaId();
        var visitas = await _repo.GetAlVisitasAsync(empresaId);

        return _mapper.Map<IEnumerable<VisitasTecnicasViewModel>>(visitas);
    }

    public async Task<DomainNotificationsResult<VisitasTecnicasViewModel>> GetVisitaTecnicaByIdAsync(int id)
    {
        var resultNotification = new DomainNotificationsResult<VisitasTecnicasViewModel>();

        var empresaId = _userContext.GetEmpresaId();

        var visita = await _repo.GetVisitaByIdAsync(empresaId, id);

        if (visita is null)
            resultNotification.Notifications.Add("Visita não existe.");

        if (resultNotification.Notifications.Any())
            return resultNotification;

        resultNotification.Result =  _mapper.Map<VisitasTecnicasViewModel>(visita);

        return resultNotification;
    }

    public async Task<DomainNotificationsResult<VisitasTecnicasViewModel>> UpdateVisitaTecnicaAsync(VisitasTecnicasDTO visita)
    {
        var resultNotification = new DomainNotificationsResult<VisitasTecnicasViewModel>();
        var empresaId = _userContext.GetEmpresaId();

        if (visita.Id is <= 0)
        {
            resultNotification.Notifications.Add("Visita não encontrada.");

            return resultNotification;
        }

        var visitaEntity = _mapper.Map<VisitasTecnicas>(visita);

        var visitaAtualizada = await _repo.UpdateVisitaAsync(empresaId, visitaEntity);

        await _unitOfWork.Commit();

        resultNotification.Result = _mapper.Map<VisitasTecnicasViewModel>(visitaAtualizada);

        return resultNotification;
    }
}
