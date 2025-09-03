using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int EmpresaId { get; set; }
    public string Cpf { get; set; }
    public bool Status { get; set; }
}
