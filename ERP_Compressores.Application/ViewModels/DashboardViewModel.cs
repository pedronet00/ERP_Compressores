using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class DashboardViewModel
{
    public int TotalVendas { get; set; }
    public int TotalClientes { get; set; }
    public decimal ValorVendasMesAtual { get; set; }
    public IEnumerable<VendasPorMesViewModel> VendasPorMes { get; set; }
}
