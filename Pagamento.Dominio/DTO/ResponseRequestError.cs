namespace Pagamento.Dominio.DTO
{
    public class ResponseRequestError : ResponseRequestBase
    {
        public ResponseRequestError(string mensagem, IList<string> notes) 
            : base(mensagem, notes)
        {

        }
    }
}
