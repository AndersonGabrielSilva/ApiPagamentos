using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.DTO
{
    public class ResponseRequestBase
    {
        public ResponseRequestBase(string mensagem, IList<string> notes = null)
        {
            this.Mensagem = mensagem;
            this.Notes = notes;
        }

        public string Mensagem { get; set; }

        public IList<string> Notes { get; set; }
    }
}
