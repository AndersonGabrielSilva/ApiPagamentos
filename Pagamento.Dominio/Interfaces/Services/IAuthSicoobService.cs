using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Interfaces.Services
{
    public interface IAuthSicoobService
    {
        string GerarUrloAuth2(string clienteId);
    }
}
