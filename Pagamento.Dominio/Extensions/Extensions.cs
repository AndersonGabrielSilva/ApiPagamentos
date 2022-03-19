using Pagamento.Dominio.Entities.Auth;
using Pagamento.Dominio.Entities.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Extensions
{
    public static class Extensions
    {
        //public static bool IsNullOrEmpty<T>(this IList<T> list) =>
        //    list == null || list.Count() == 0;

        /// <summary>
        /// Verifica se a lista é nula ou vazia.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="list"></param>
        /// <param name="CreateInstance">Caso a coleção seja nula já cria uma nova instancia. </param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TClass>(this IList<TClass> list, bool CreateInstance = false)
        {
            if (list is null && CreateInstance)
            {
                list = new List<TClass>();
                return false;
            }

            return list is null || list.Count() == 0;
        }    

    }

    public static class LogExtensions 
    {
        public static LogAcessTokenRequest CreateLog(this AcessTokenRequest acessTokenRequest, AcessTokenRequest acessTokenRequestNovo = null, string Observacao = "")
        {
            return new LogAcessTokenRequest(acessTokenRequest, acessTokenRequestNovo, Observacao);
        }
    }
}

