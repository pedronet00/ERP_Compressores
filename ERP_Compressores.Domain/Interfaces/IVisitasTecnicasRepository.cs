using ERP_Compressores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Interfaces;

public interface IVisitasTecnicasRepository
{
    Task<IEnumerable<VisitasTecnicas>> GetAlVisitasAsync(int empresaId);

    Task<VisitasTecnicas> GetVisitaByIdAsync(int empresaId, int id);

    Task<VisitasTecnicas> AddVisitaAsync(VisitasTecnicas visita);

    Task<VisitasTecnicas> UpdateVisitaAsync(int empresaId, VisitasTecnicas visita);

    Task<bool> DeleteVisitaAsync(int empresaId, int id);

    Task<bool> ConcluirVisita(int empresaId, VisitasTecnicas visita);

    Task<bool> CancelarVisita(int empresaId, VisitasTecnicas visita);
}
