using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public int EmpresaId { get; set; }
    public string? Cpf { get; set; }
    public bool Status { get; set; }
}
