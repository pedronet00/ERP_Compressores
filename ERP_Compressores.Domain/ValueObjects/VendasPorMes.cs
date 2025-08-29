using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.ValueObjects;

public class VendasPorMes
{
    public int Ano { get; set; }
    public int Mes { get; set; }
    public decimal ValorTotal { get; set; }
}
