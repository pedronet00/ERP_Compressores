using ERP_Compressores.Domain.ValueObjects;

namespace ERP_Compressores.Domain.Entities;

// Essa classe representa os clientes das Empresas. São usados nas Vendas, Visitas Técnicas e Orçamentos.

public class Clientes
{
    
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Nome { get; set; } 
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public bool Status { get; set; }
    public int EmpresaId { get; set; }
    public Empresas Empresa { get; set; }

    // Collections
    public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();
    public ICollection<Orcamentos> Orcamentos { get; set; } = new List<Orcamentos>();
    public ICollection<VisitasTecnicas> VisitasTecnicas { get; set; } = new List<VisitasTecnicas>();

    public Clientes() { }
    public Clientes(string nome, string cpf, string telefone, string email, string endereco, int empresaId)
    {
        Guid = Guid.NewGuid();
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        Status = true;
        EmpresaId = empresaId;
    }

}
