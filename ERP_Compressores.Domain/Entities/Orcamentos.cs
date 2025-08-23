using ERP_Compressores.Domain.Enums;

namespace ERP_Compressores.Domain.Entities;

public class Orcamentos
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }
    public DateTime DataOrcamento { get; set; }
    public decimal ValorOriginal { get; set; }
    public int DescontoPercentual { get; set; }
    public decimal ValorTotal { get; set; }
    public string Descricao { get; set; }
    public StatusOrcamentosEnum Status { get; set; }
    public int EmpresaId { get; set; }
    public Empresas Empresa { get; set; }
    // Collections
    public ICollection<ItensOrcamento> ItensOrcamento { get; set; } = new List<ItensOrcamento>();
    public Orcamentos() { }
    public Orcamentos(int clienteId, DateTime dataOrcamento, decimal valorTotal, string descricao, int empresaId, decimal valorOriginal, int descontoPercentual)
    {
        Guid = Guid.NewGuid();
        ClienteId = clienteId;
        DataOrcamento = dataOrcamento;
        ValorTotal = valorTotal;
        Descricao = descricao;
        Status = StatusOrcamentosEnum.Pendente;
        EmpresaId = empresaId;
        ValorOriginal = valorOriginal;
        DescontoPercentual = descontoPercentual;
    }
}
