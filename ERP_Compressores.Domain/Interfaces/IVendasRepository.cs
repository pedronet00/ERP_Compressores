using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IVendasRepository
{
    Task AdicionarAsync(Vendas venda);
    Task<Vendas?> ObterPorIdAsync(int id);
    Task<IEnumerable<Vendas>> ListarAsync();

    Task<int> CountVendas();

}
