using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class ClientesRelatorioViewModel
{
    public int QuantidadeClientes { get; set; }
    public IEnumerable<ClienteViewModel> Clientes { get; set; } = new List<ClienteViewModel>();
    public int QuantidadeClientesUltimoMes { get; set; }
    public ClienteViewModel? ClienteQueMaisComprou { get; set; }
}
