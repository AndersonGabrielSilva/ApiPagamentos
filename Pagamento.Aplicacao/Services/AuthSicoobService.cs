using Pagamento.Dominio.Exceptions;
using Pagamento.Dominio.Interfaces.Repositories;
using Pagamento.Dominio.Interfaces.Services;
using Pagamento.Dominio.Services;

namespace Pagamento.Aplicacao.Services
{
    public class AuthSicoobService : BaseService, IAuthSicoobService
    {
        public IUsuarioRepository UsuarioRepository { get; }

        public AuthSicoobService(IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }


        public async Task<string> GerarUrloAuth2(int usuarioId, int credenciasId)
        {
            var credencial = await UsuarioRepository.ObterCredencial(usuarioId, credenciasId);

            if (string.IsNullOrEmpty(credencial?.URLAuthorize))
                throw new BaseException()
                          .AddTraceId("7D8DF826")
                          .AddNote("Url");

                return credencial.URLAuthorize;
        }
    }
}
