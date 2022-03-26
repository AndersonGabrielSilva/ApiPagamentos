using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.DTO.Sicoob
{
    public class AcessTokenRequestResponseDTO
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }


        //Mensagem de erro

        public string error_description { get; set; }
        public string invalid_grant { get; set; }

        public bool PossuiErros() =>
            !string.IsNullOrEmpty(error_description) || !string.IsNullOrEmpty(invalid_grant);

        public long ObterPeriodoExpiracao()
        {           
            return expires_in;
        }

        public DateTime? ObterDtaDeExpiracao()
        {
            var dtaExpiracao = DateTime.UtcNow;

            return dtaExpiracao;
        }
    }
}
