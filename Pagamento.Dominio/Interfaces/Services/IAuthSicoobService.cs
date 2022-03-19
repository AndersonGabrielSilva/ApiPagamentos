using Pagamento.Dominio.DTO.Sicoob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Interfaces.Services
{
    public interface IAuthSicoobService : INotifications
    {
        Task<UrlAutorizeoAuth2DTO> GerarUrloAuth2(int usuarioId, int credenciasId);
    }
}
