using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Services;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetEmpresaId()
    {
        var empresaId = _httpContextAccessor.HttpContext?.User?.FindFirst("empresaId")?.Value;

        if (string.IsNullOrEmpty(empresaId))
            throw new UnauthorizedAccessException("EmpresaId não localizada no token JWT.");

        return int.Parse(empresaId);
    }

    public string GetUserName()
    {
        return _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Usuário desconhecido";
    }
}
