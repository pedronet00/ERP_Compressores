using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.DTOs;

public class RegistrarVendaDTO
{
    public int ClienteId { get; set; }
    public int EmpresaId { get; set; }
    public string? Descricao { get; set; }
    public int DescontoPercentual { get; set; }
    public List<ItemVendaDTO>? Itens { get; set; }
}
