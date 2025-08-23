
namespace ERP_Compressores.Domain.Entities;

public class CategoriaProduto
{

    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string Nome { get; set; }

    public bool Status { get; set; }

    public int EmpresaId { get; set; }
    public Empresas Empresa { get; set; }

    // Collections
    public ICollection<Produtos> Produtos { get; set; } = new List<Produtos>();

    public CategoriaProduto() { }

    public CategoriaProduto(int id, string nome, int empresaId)
    {
        Id = id;
        Guid = Guid.NewGuid();
        Nome = nome;
        Status = true;
        EmpresaId = empresaId;
    }
}
