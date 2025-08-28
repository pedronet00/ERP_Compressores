using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class ClienteViewModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Endereco { get; set; }
    public bool Status { get; set; }
    public int EmpresaId { get; set; }
}
