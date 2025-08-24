using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.ViewModels;

public class CategoriaProdutoViewModel
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Nome { get; set; }

    public bool Status { get; set; }

    public int EmpresaId { get; set; }
}
