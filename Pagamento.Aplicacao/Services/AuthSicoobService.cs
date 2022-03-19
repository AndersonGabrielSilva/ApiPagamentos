using Pagamento.Dominio.DTO.Sicoob;
using Pagamento.Dominio.Entities.Sicoob;
using Pagamento.Dominio.Interfaces.Repositories;
using Pagamento.Dominio.Interfaces.Services;
using Pagamento.Dominio.Services;
using Pagamento.Dominio.Settings;
using System.Configuration;

namespace Pagamento.Aplicacao.Services
{
    public class AuthSicoobService : BaseService, IAuthSicoobService
    {
        public AppSettings AppSettings { get; }
        public IUsuarioRepository UsuarioRepository { get; }

        public AuthSicoobService(
            AppSettings appSettings, 
            IUsuarioRepository usuarioRepository)
        {
            AppSettings = appSettings;
            UsuarioRepository = usuarioRepository;
        }


        public async Task<UrlAutorizeoAuth2DTO> GerarUrloAuth2(int usuarioId, int credenciasId)
        {
            var credencial = await UsuarioRepository.ObterCredencial(usuarioId, credenciasId);

            AddNotify(UsuarioRepository);

            if (credencial is null)
            {
                AddTraceId("07286062");
                AddNote("Credencial não encontrada");
                AddOrUpdateStatusCode(404);

                return null;
            }
            
            var urlAutorize = $"{AppSettings.Sicoob.UrlAutenticaOAuth2}response_type=code" +
                              $"&redirect_uri={credencial.CallBackUrl}" +
                              $"&client_id={credencial.ClientID}"+
                              $"&scope={Credencias.ScopesSicoob()}"+
                              $"&cooperativa={credencial.Cooperativa}"+
                              $"&contaCorrente={credencial.Conta}"+
                              $"&versaoHash={3}";

            return new UrlAutorizeoAuth2DTO(usuarioId, credenciasId, urlAutorize);
        }
    }
}
