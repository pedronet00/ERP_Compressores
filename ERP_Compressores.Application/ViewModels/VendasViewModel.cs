using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class VendasViewModel
{
    public Guid Guid { get; set; }
    public string NomeCliente { get; set; }
    public int EmpresaId { get; set; }
    public DateTime DataVenda { get; set; }
    public string? Descricao { get; set; }
    public decimal ValorOriginal { get; set; }
    public int DescontoPercentual { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusVendasEnum Status { get; set; }
    public List<ItemVendaDTO>? Itens { get; set; }
}
