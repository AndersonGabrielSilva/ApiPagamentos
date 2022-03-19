using Pagamento.Dominio.DTO;
using Pagamento.Dominio.DTO.Sicoob;
using Pagamento.Dominio.Entities.Sicoob;
using Pagamento.Dominio.Interfaces.Repositories;
using Pagamento.Dominio.Interfaces.Services;
using Pagamento.Dominio.Services;
using Pagamento.Dominio.Settings;
using RestSharp;
using RestSharp.Authenticators;
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

        public async Task<ResponseRequestBase> GerarAcessToken(int credenciasId, string code)
        {
            var credencial = await UsuarioRepository.ObterCredencialParaAtualizarAcessToken(credenciasId);

            var baseUri = AppSettings.Sicoob.UrlAccessToken;

            var options = new RestClientOptions(baseUri);
            var client = new RestClient(options);
            
            var request = new RestRequest()
                          .AddHeader("Content-type", @"www/form-url-encoded")
                          .AddHeader("Authorization", $"Basic {credencial.TokenBasic}")
                          .AddParameter("grant_type", "authorization_code")
                          .AddParameter("code", $"{code}")
                          .AddParameter("redirect_uri", $"{credencial.CallBackUrl}");

            var response = await client.PostAsync<AcessTokenRequestResponseDTO>(request);

            if (response.PossuiErros())
                return new ResponseRequestError("Houve um erro ao tentar gerar o AcessToken",
                       new List<string>() { response.error_description, response.invalid_grant});

            await UsuarioRepository.AtualizaAcessTokenRequest(credenciasId, response);

            return new ResponseRequestBase("Token atualizado com sucesso",
                   new List<string> {$"Scopos autotizados {response.scope}"});
        }
    }
}
