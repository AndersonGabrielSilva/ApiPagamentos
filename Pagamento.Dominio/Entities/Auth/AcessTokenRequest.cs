using Pagamento.Dominio.DTO.Sicoob;
using Pagamento.Dominio.Entities.Auth;
using Pagamento.Dominio.Entities.Sicoob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Entities.Auth
{
    public class AcessTokenRequest
    {
        public AcessTokenRequest()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public DateTime? DtaExpiracao { get; set; }

        #region Relacionamentos
        public int? CredenciasId { get; set; }
        public Credencias credencias { get; set; }

        public void Update(AcessTokenRequestResponseDTO response)
        {
            access_token = response.access_token;
            refresh_token = response.refresh_token;
            scope = response.scope;
            token_type = response.token_type;
            expires_in = response.ObterPeriodoExpiracao();
            DtaExpiracao = response.ObterDtaDeExpiracao();
        }

        public AcessTokenRequest GetClone()=>
            (AcessTokenRequest)this.MemberwiseClone();
        
    }
    #endregion
}

