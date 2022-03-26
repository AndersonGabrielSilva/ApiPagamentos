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
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

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
                              $"&client_id={credencial.ClientID}" +
                              $"&scope={Credencias.ScopesSicoob()}" +
                              $"&cooperativa={credencial.Cooperativa}" +
                              $"&contaCorrente={credencial.Conta}" +
                              $"&versaoHash={3}";

            return new UrlAutorizeoAuth2DTO(usuarioId, credenciasId, urlAutorize);
        }

        public async Task<ResponseRequestBase> GerarAcessToken(int credenciasId, string code)
        {
            return await GerarAcessToken2(credenciasId, code);

            //var credencial = await UsuarioRepository.ObterCredencialParaAtualizarAcessToken(credenciasId);

            //var baseUri = AppSettings.Sicoob.UrlAccessToken;

            //var options = new RestClientOptions(baseUri);
            //var client = new RestClient(options);

            //var request = new RestRequest("", Method.Post)
            //              .AddHeader("content-type", @"application/x-www-form-urlencoded")
            //              .AddHeader("Authorization", $"Basic {credencial.TokenBasic}")
            ////.AddParameter("application/x-www-form-urlencoded",
            ////$"grant_type=authorization_code&code={code}&redirect_uri={credencial.CallBackUrl}",
            ////             ParameterType.RequestBody);
            ////.AddBody(new Teste
            //// {
            ////    grant_type = "authorization_code",
            ////    code = code,
            ////    redirect_uri = credencial.CallBackUrl
            ////}, "application/x-www-form-urlencoded");
            ////.AddParameter("grant_type", "authorization_code", ParameterType.RequestBody)
            ////.AddParameter("code", code, ParameterType.RequestBody)
            ////.AddParameter("redirect_uri", credencial.CallBackUrl, ParameterType.RequestBody);
            //.AddParameter(CreateParameterForm("grant_type", "authorization_code"))
            //.AddParameter(CreateParameterForm("code", code))
            //.AddParameter(CreateParameterForm("redirect_uri", credencial.CallBackUrl));
            ////.AddParameter(CreateParameterForm("application/x-www-form-urlencoded", $"grant_type=authorization_code&code={code}&redirect_uri={credencial.CallBackUrl}"));
            ////.AddParameter("", "", ParameterType.RequestBody);
            
            //var response = await client.PostAsync(request);
            ////var response = await client.PostAsync<AcessTokenRequestResponseDTO>(request);
            //AcessTokenRequestResponseDTO AcessToken = null;
            //if (response.IsSuccessful)
            //{
            //    AcessToken = JsonSerializer.Deserialize<AcessTokenRequestResponseDTO>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = false });

            //    await UsuarioRepository.AtualizaAcessTokenRequest(credenciasId, AcessToken);

            //    return new ResponseRequestBase("Token atualizado com sucesso",
            //           new List<string> { $"Scopos autotizados {AcessToken.scope}" });
            //}
            //else
            //    return new ResponseRequestError("Houve um erro ao tentar gerar o AcessToken",
            //           new List<string>() { response.Content?.ToString() });

        }

        public async Task<ResponseRequestBase> GerarAcessToken2(int credenciasId, string code)
        {
            var credencial = await UsuarioRepository.ObterCredencialParaAtualizarAcessToken(credenciasId);

            var baseUri = AppSettings.Sicoob.UrlAccessToken;

            using HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUri);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {credencial.TokenBasic}"); 
            //_httpClient.DefaultRequestHeaders.Add("content-type", @"application/x-www-form-urlencoded");
            //dados form
            var data = new Dictionary<string, string>();
            data.Add("grant_type", "authorization_code");
            data.Add("code", code);
            data.Add("redirect_uri", credencial.CallBackUrl);

            using var body = new FormUrlEncodedContent(data);
            body.Headers.Clear();
            //body.Headers.Add("Authorization", $"Basic {credencial.TokenBasic}");
            body.Headers.Add("content-type", @"application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync("",body);

            AcessTokenRequestResponseDTO AcessToken = null;
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                AcessToken = JsonSerializer.Deserialize<AcessTokenRequestResponseDTO>(jsonContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                await UsuarioRepository.AtualizaAcessTokenRequest(credenciasId, AcessToken);

                return new ResponseRequestBase("Token atualizado com sucesso",
                       new List<string> { $"Scopos autotizados {AcessToken.scope}" });
            }
            else
                return new ResponseRequestError("Houve um erro ao tentar gerar o AcessToken",
                       new List<string>() { await response.Content.ReadAsStringAsync() });

        }

        public BodyParameter CreateParameterForm(string Name, string Value)
        {
            return new BodyParameter(Name, Value, "application/x-www-form-urlencoded");
        }
        public class Teste
        {
            internal string grant_type;
            internal string code;
            internal string redirect_uri;
        }
    }
}
