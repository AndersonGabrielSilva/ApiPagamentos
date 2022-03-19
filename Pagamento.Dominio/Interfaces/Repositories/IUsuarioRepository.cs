using Pagamento.Dominio.DTO.Sicoob;
using Pagamento.Dominio.Entities.Sicoob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Interfaces.Repositories
{
    public interface IUsuarioRepository : INotifications
    {
        Task<Credencias> ObterCredencial(int usuarioId, int credenciasId);
        Task<Credencias> ObterCredencialParaAtualizarAcessToken(int credenciasId);
        Task AtualizaAcessTokenRequest(int credenciasId, AcessTokenRequestResponseDTO response);
    }
}
