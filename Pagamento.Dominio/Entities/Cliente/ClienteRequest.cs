using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Entities.Cliente
{
    public class ClienteRequest 
    {
        public ClienteRequest()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string acess_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }

    }
}
