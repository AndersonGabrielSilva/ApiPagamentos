namespace Pagamento.Dominio.Exceptions
{
    public class BaseException : Exception
    {
        #region Construtores
        public BaseException():base()
        {
            InicializaPropriedades();
        }

        public BaseException(string mensagem) : base(mensagem)
        {
            InicializaPropriedades();
        }

        public BaseException(string mensagem, Exception ex) : base(mensagem, ex)
        {
            InicializaPropriedades();
        }
        #endregion

        #region Dados Exception
        private void InicializaPropriedades()
        {
            Id = Guid.NewGuid();
            notes = new List<string>();
        }

        public Guid Id{ get; private set; }

        public string TraceId { get; private set; }

        protected List<string> notes { get; set; }
        public IReadOnlyCollection<string> Notes { get => Notes; }

        protected int StatusCode { get; set; }
        #endregion

        #region Comportamentos
        /// <summary>
        /// Adiciona Nota
        /// </summary>
        /// <param name="note">Nota</param>
        public BaseException AddNote(string note)
        {
            notes.Add(note);

            return this;
        }

        public BaseException AddOrUpdateStatusCode(int statusCode)
        {
            StatusCode = statusCode;

            return this;
        }

        public BaseException AddTraceId(string traceId)
        {
            if (!string.IsNullOrEmpty(TraceId))
                TraceId = traceId;

            return this;
        }
        #endregion
    }
}
