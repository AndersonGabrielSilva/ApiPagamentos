using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Exceptions
{
    public class RepositoryException : BaseException
    {
        #region Construtor
        public RepositoryException() : base("Lancada na camada de Repository")
        {

        }

        public RepositoryException(string mensagem) : base(mensagem)
        {

        }

        public RepositoryException(string mensagem, Exception ex) : base(mensagem,ex)
        {

        }

        public RepositoryException(Exception ex) : base("Lancada na camada de Repository", ex)
        {

        }
        #endregion
    }
}
