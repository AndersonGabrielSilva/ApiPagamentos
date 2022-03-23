using Microsoft.EntityFrameworkCore;
using Pagamento.Dominio.DTO.Sicoob;
using Pagamento.Dominio.Entities.Auth;
using Pagamento.Dominio.Entities.Sicoob;
using Pagamento.Dominio.Exceptions;
using Pagamento.Dominio.Extensions;
using Pagamento.Dominio.Interfaces.Repositories;
using Pagamento.Infra.Data.Context;

namespace Pagamento.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public PagamentosContext PagContext { get; }

        //public UsuarioRepository(PagamentosContext pagContext)
        //{
        //    PagContext = pagContext;
        //}

        public UsuarioRepository()
        {

        }

        public async Task<Credencias> ObterCredencial(int usuarioId, int credenciasId)
        {
            try
            {
                var teste = Credencias.GetCredenciasFactory();
                //return await PagContext.Credencias.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId && c.Id == credenciasId && c.IsActive);
                return await Task.FromResult(teste.FirstOrDefault(c => c.UsuarioId == usuarioId && c.Id == credenciasId && c.IsActive));
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex)
                         .AddTraceId("C4288E76")
                         .AddNote("Não foi possivel encontrar a credencial de usuario");
            }
        }

        public async Task<Credencias> ObterCredencialParaAtualizarAcessToken(int credenciasId)
        {
            return await Task.FromResult(Credencias.GetCredenciasFactory().Where(x => x.Id == credenciasId).FirstOrDefault());
        }

        public async Task AtualizaAcessTokenRequest(int credenciasId, AcessTokenRequestResponseDTO response)
        {
            var acessToken = await PagContext.AcessTokenRequest.FirstOrDefaultAsync(acess => acess.CredenciasId == credenciasId);

            if(acessToken == null)
            {
                var newAcessToken = new AcessTokenRequest()
                {
                    CredenciasId = credenciasId,
                    acess_token = response.acess_token,
                    refresh_token = response.refresh_token,
                    scope = response.scope,
                    token_type = response.token_type,
                    expires_in = response.ObterPeriodoExpiracao(),
                    DtaExpiracao = response.ObterDtaDeExpiracao()
                };

                PagContext.Add(newAcessToken);

                //Log
                var IncludeLog = newAcessToken.CreateLog(null, "Adicionando AcessTokenRequest");
                PagContext.Add(IncludeLog);
            }
            else
            {
                var _oldAcessToken = acessToken.GetClone();
                acessToken.Update(response);

                //Log
                var updateLog = _oldAcessToken.CreateLog(acessToken,"Atualizando AcessTokenRequest");
                PagContext.Add(updateLog);
            }        

            await PagContext.SaveChangesAsync();
        }
    }
}
