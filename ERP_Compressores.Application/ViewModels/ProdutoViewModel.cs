using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class ProdutoViewModel
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public int CategoriaProdutoId { get; set; }

    public decimal Preco { get; set; }

    public int EmpresaId { get; set; }

    public int QuantidadeEstoque { get; set; }

    public int FornecedorId { get; set; }

    public bool Status { get; set; }
}
