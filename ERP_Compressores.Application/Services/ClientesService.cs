using AutoMapper;
using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using ERP_Compressores.Domain.Enums;
using ERP_Compressores.Domain.Interfaces;
using ERP_Compressores.Domain.Notifications;

namespace ERP_Compressores.Application.Services;

public class ClientesService : IClientesService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClientesRepository _repo;
    private readonly IVendasRepository _vendasRepository;
    private readonly IUserContextService _userContext;


    public ClientesService(IUnitOfWork unitOfWork, IMapper mapper, IClientesRepository repo, IUserContextService userContext, IVendasRepository vendasRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repo = repo;
        _userContext = userContext;
        _vendasRepository = vendasRepository;
    }

    public async Task<DomainNotificationsResult<ClienteViewModel>> ActivateCliente(int id)
    {
        var resultNotifications = new DomainNotificationsResult<ClienteViewModel>();

         var empresaId = _userContext.GetEmpresaId();
         var cliente = await _repo.GetClienteByIdAsync(empresaId, id);

         if (cliente.Status is true)
         {
            resultNotifications.Notifications.Add("Usuário já está ativo.");
            return resultNotifications;
         }

         await _repo.ActivateCliente(empresaId, cliente);

         await _unitOfWork.Commit();

         resultNotifications.Result = _mapper.Map<ClienteViewModel>(cliente);
        
         return resultNotifications;
    }

    public async Task<DomainNotificationsResult<ClienteViewModel>> AddClienteAsync(ClienteDTO cliente)
    {
        var resultNotifications = new DomainNotificationsResult<ClienteViewModel>();

        if (cliente is null)
        {
            resultNotifications.Notifications.Add("Dados do cliente não encontrados.");
            return resultNotifications;
        }

        if (await _repo.ExistsByEmailAsync(cliente.EmpresaId, cliente.Email!))
            resultNotifications.Notifications.Add("Já existe cliente com este email.");

        if (await _repo.ExistsByCpfAsync(cliente.EmpresaId, cliente.Cpf!))
            resultNotifications.Notifications.Add("Já existe cliente com este CPF.");

        if (resultNotifications.Notifications.Any())
            return resultNotifications;

        var clienteEntity = _mapper.Map<Domain.Entities.Clientes>(cliente);

        var novoCliente = await _repo.AddClienteAsync(clienteEntity);

        await _unitOfWork.Commit();

        resultNotifications.Result = _mapper.Map<ClienteViewModel>(cliente);
        
        return resultNotifications;
    }

    public async Task<int> CountClientes()
    {
        var empresaId = _userContext.GetEmpresaId();
        return await _repo.CountClientes(empresaId);
    }

    public async Task<DomainNotificationsResult<ClienteViewModel>> DeactivateCliente(int id)
    {
        var resultNotifications = new DomainNotificationsResult<ClienteViewModel>();

        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId, id);

        if (cliente.Status is false)
        {
            resultNotifications.Notifications.Add("Usuário já está inativo.");
            return resultNotifications;
        }

        var vendas = await _vendasRepository.ObterVendasCliente(id);
        if (vendas.Any(c => c.ClienteId == id && c.Status == StatusVendasEnum.Pendente))
        {
            resultNotifications.Notifications.Add("Existem vendas pendentes para esse cliente.");
            return resultNotifications;
        }

        await _repo.DeactivateCliente(empresaId, cliente);

        await _unitOfWork.Commit();

        resultNotifications.Result = _mapper.Map<ClienteViewModel>(cliente);
        
        return resultNotifications;
    }

    public async Task<DomainNotificationsResult<ClienteViewModel>> DeleteClienteAsync(int id)
    {
        var result = new DomainNotificationsResult<ClienteViewModel>();
        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId, id);

        if (cliente is null)
        {
            result.Add("Cliente não encontrado.");
            return result;
        }

        var vendas = await _vendasRepository.ObterVendasCliente(id);
        if (vendas.Any(c => c.ClienteId == id && c.Status == StatusVendasEnum.Pendente))
        {
            result.Add("Existem vendas pendentes para esse cliente.");
            return result;
        }

        var sucesso = await _repo.DeleteClienteAsync(empresaId, id);
        if (!sucesso)
        {
            result.Add("Erro ao deletar o cliente.");
            return result;
        }

        await _unitOfWork.Commit();
        result.Result = _mapper.Map<ClienteViewModel>(cliente);

        return result;
    }

    public async Task<DomainNotificationsResult<ClientesRelatorioViewModel>> GerarRelatorioAsync()
    {
        var empresaId = _userContext.GetEmpresaId();
        var result = new DomainNotificationsResult<ClientesRelatorioViewModel>();

        var quantidadeTotal = await _repo.CountClientes(empresaId);
        var clientes = await _repo.GetAllClientesAsync(empresaId);
        var quantidadeUltimoMes = await _repo.CountClientesUltimoMesAsync(empresaId);
        var clienteMaisComprou = await _repo.GetClienteQueMaisComprouAsync(empresaId);

        var viewModel = new ClientesRelatorioViewModel
        {
            QuantidadeClientes = quantidadeTotal,
            Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes),
            QuantidadeClientesUltimoMes = quantidadeUltimoMes,
            ClienteQueMaisComprou = _mapper.Map<ClienteViewModel?>(clienteMaisComprou)
        };

        result.Result = viewModel;

        return result;
    }

    public async Task<IEnumerable<ClienteViewModel>> GetAllClientesAsync()
    {
        var empresaId = _userContext.GetEmpresaId();
        var clientes = await _repo.GetAllClientesAsync(empresaId);

        return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
    }

    public async Task<DomainNotificationsResult<ClienteViewModel>> GetClienteByIdAsync(int id)
    {
        var resultNotification = new DomainNotificationsResult<ClienteViewModel>();
        var empresaId = _userContext.GetEmpresaId();
        var cliente = await _repo.GetClienteByIdAsync(empresaId,id);

        if(cliente is null)
        {
            resultNotification.Notifications.Add("Cliente não encontrado");
        }

        resultNotification.Result = _mapper.Map<ClienteViewModel>(cliente);

        return resultNotification;
    }

    public async Task<DomainNotificationsResult<ClienteViewModel>> UpdateClienteAsync(ClienteDTO cliente)
    {
        var resultNotification = new DomainNotificationsResult<ClienteViewModel>();
        var empresaId = _userContext.GetEmpresaId();

        if (cliente.Id is <= 0)
            resultNotification.Notifications.Add("Cliente não encontrado.");

        if (await _repo.ExistsByEmailAsync(cliente.EmpresaId, cliente.Email!))
            resultNotification.Notifications.Add("Já existe cliente com este email.");

        if (await _repo.ExistsByCpfAsync(cliente.EmpresaId, cliente.Cpf!))
            resultNotification.Notifications.Add("Já existe cliente com este CPF.");

        if (resultNotification.Notifications.Any())
            return resultNotification;

        var clienteEntity = _mapper.Map<Domain.Entities.Clientes>(cliente);
        
        var clienteAtualizado = await _repo.UpdateClienteAsync(empresaId,clienteEntity);
        
        await _unitOfWork.Commit();
        
        resultNotification.Result = _mapper.Map<ClienteViewModel>(clienteAtualizado);

        return resultNotification;
    }
}
