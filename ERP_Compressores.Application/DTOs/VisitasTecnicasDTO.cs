using ERP_Compressores.Domain.Entities;
using ERP_Compressores.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.DTOs;

public class VisitasTecnicasDTO
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataVisita { get; set; }
    public string Descricao { get; set; }
    public StatusVisitasTecnicasEnum Status { get; set; }
    public int EmpresaId { get; set; }
}
