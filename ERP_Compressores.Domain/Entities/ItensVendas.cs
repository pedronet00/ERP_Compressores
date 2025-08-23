namespace ERP_Compressores.Domain.Entities;

public class ItensVendas
{
    public int Id { get; private set; }
    public Guid Guid { get; private set; }
    public int VendaId { get; private set; }
    public Vendas Venda { get; private set; }
    public int ProdutoId { get; private set; }
    public Produtos Produto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public decimal Subtotal => Quantidade * ValorUnitario;

    private ItensVendas() { }

    public ItensVendas(int produtoId, int quantidade, decimal valorUnitario, int vendaId)
    {
        Guid = Guid.NewGuid();
        ProdutoId = produtoId;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        VendaId = vendaId;
    }
}
