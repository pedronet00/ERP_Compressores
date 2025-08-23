namespace ERP_Compressores.Domain.Entities;

public class Empresas
{
    public int Id { get; set; } 
    public Guid Guid { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cnpj { get; set; }
    public string Telefone { get; set; } 
    public string Endereco { get; set; } 
    public bool Status { get; set; }

    // Collections
    public ICollection<Produtos> Produtos { get; set; } = new List<Produtos>();
    public ICollection<CategoriaProduto> CategoriasProdutos { get; set; } = new List<CategoriaProduto>();
    public ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
    public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();
    public ICollection<Fornecedores> Fornecedores { get; set; } = new List<Fornecedores>();
    public ICollection<Orcamentos> Orcamentos { get; set; } = new List<Orcamentos>();
    public ICollection<VisitasTecnicas> VisitasTecnicas { get; set; } = new List<VisitasTecnicas>();

    public Empresas() { }

    public Empresas(int id, string nome, string email, string cnpj, string telefone, string endereco)
    {
        Id = id;
        Guid = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Cnpj = cnpj;
        Telefone = telefone;
        Endereco = endereco;
        Status = true;
    }
}
