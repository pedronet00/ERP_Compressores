using Microsoft.AspNetCore.Identity;

namespace ERP_Compressores.Domain.Entities;

public class Usuarios : IdentityUser
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public int EmpresaId { get; set; }
    public string Cpf { get; set; }
    public bool Status { get; set; }
    public Empresas Empresa { get; set; }

    // Token
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public Usuarios() { }
    public Usuarios(int empresaId, string cpf)
    {
        Guid = Guid.NewGuid(); ;
        EmpresaId = empresaId;
        Cpf = cpf;
        Status = true;
    }

}
