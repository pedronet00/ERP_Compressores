namespace ERP_Compressores.Domain.Entities;

public class Produtos
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public int CategoriaProdutoId { get; set; }

    public CategoriaProduto CategoriaProduto { get; set; }

    public decimal Preco { get; set; }

    public int EmpresaId { get; set; }

    public Empresas Empresa { get; set; }

    public int QuantidadeEstoque { get; set; }

    public int FornecedorId { get; set; }
    public Fornecedores Fornecedor { get; set; }

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public bool Status { get; set; }

    // Collections
    public ICollection<ItensOrcamento> ItensOrcamento { get; set; } = new List<ItensOrcamento>();
    public ICollection<ItensVendas> ItensVenda { get; set; } = new List<ItensVendas>();


    public Produtos() { }

    public Produtos(int id, string nome, int empresaId, string descricao, decimal preco, int quantidadeEstoque)
    {
        Id = id;
        Guid = Guid.NewGuid();
        EmpresaId = empresaId;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        DataCadastro = DateTime.Now;
        DataAtualizacao = DateTime.Now;
        Status = true;
    }
}
