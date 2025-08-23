namespace ERP_Compressores.Domain.Entities;

public class Fornecedores
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public bool Status { get; set; }
    public int EmpresaId { get; set; }
    public Empresas Empresa { get; set; }

    //Collections
    public ICollection<Produtos> Produtos { get; set; } = new List<Produtos>();

    public Fornecedores() { }
    public Fornecedores(string nome, string cnpj, string telefone, string email, string endereco, int empresaId)
    {
        Guid = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        Status = true;
        EmpresaId = empresaId;
    }
}
