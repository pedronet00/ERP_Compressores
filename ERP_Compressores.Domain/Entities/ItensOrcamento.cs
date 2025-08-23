namespace ERP_Compressores.Domain.Entities;

public class ItensOrcamento
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public int OrcamentoId { get; set; }
    public Orcamentos Orcamento { get; set; }
    public int ProdutoId { get; set; }
    public Produtos Produto { get; set; }
    public decimal PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
    public ItensOrcamento() { }
    public ItensOrcamento(int orcamentoId, int produtoId, decimal precoUnitario, int quantidade, decimal valorTotal)
    {
        Guid = Guid.NewGuid();
        OrcamentoId = orcamentoId;
        ProdutoId = produtoId;
        PrecoUnitario = precoUnitario;
        Quantidade = quantidade;
        ValorTotal = valorTotal;
    }
}
