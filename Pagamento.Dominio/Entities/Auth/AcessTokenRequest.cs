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
        public string acess_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }

        #region Relacionamentos
        public int? CredenciasId { get; set; }
        public Credencias credencias { get; set; }
    }
    #endregion
}

