using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Application.Interfaces;

public interface IUserContextService
{
    int GetEmpresaId();
    string GetUserName();

}
