using ERP_Compressores.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardViewModel> ObterDashboardAsync();
}
