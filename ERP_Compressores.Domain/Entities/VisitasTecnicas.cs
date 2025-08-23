using ERP_Compressores.Domain.Enums;

namespace ERP_Compressores.Domain.Entities;

public class VisitasTecnicas
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }
    public DateTime DataVisita { get; set; }
    public string Descricao { get; set; }
    public StatusVisitasTecnicasEnum Status { get; set; }
    public int EmpresaId { get; set; }
    public Empresas Empresa { get; set; }

    public VisitasTecnicas() { }
    public VisitasTecnicas(int clienteId, DateTime dataVisita, string descricao, int empresaId)
    {
        Guid = Guid.NewGuid();
        ClienteId = clienteId;
        DataVisita = dataVisita;
        Descricao = descricao;
        Status = StatusVisitasTecnicasEnum.Pendente;
        EmpresaId = empresaId;
    }
}
