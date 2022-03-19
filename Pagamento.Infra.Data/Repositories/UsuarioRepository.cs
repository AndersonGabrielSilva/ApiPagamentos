using Microsoft.EntityFrameworkCore;
using Pagamento.Dominio.Entities.Sicoob;
using Pagamento.Dominio.Exceptions;
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
    }
}
