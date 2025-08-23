using ERP_Compressores.Domain.Enums;

namespace ERP_Compressores.Domain.Entities;

public class Vendas
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal ValorOriginal { get; set; }
    public int DescontoPercentual { get; set; }
    public decimal ValorTotal { get; set; }
    public string Descricao { get; set; }
    public StatusVendasEnum Status { get; set; }
    public int EmpresaId { get; set; }
    public Empresas Empresa { get; set; }
    // Collections
    public ICollection<ItensVendas> ItensVenda { get; set; } = new List<ItensVendas>();
    public Vendas() { }
    public Vendas(int clienteId, DateTime dataVenda, decimal valorTotal, string descricao, int empresaId, decimal valorOriginal, int descontoPercentual)
    {
        Guid = Guid.NewGuid();
        ClienteId = clienteId;
        DataVenda = dataVenda;
        ValorTotal = valorTotal;
        Descricao = descricao;
        Status = StatusVendasEnum.Pendente;
        EmpresaId = empresaId;
        ValorOriginal = valorOriginal;
        DescontoPercentual = descontoPercentual;
    }
}
