namespace Pagamento.Dominio.Interfaces
{
    public interface INotifications
    {
        Guid Id { get; }
        string TraceId { get;}
        int StatusCode { get;}

        bool ContainErrors { get; }

        INotifications Notifications { get; }

        IReadOnlyCollection<string> Notes { get; }

        INotifications AddNotify(INotifications notifications);
        INotifications AddNote(string note);
        INotifications AddNotes(IList<string> notes);
        INotifications AddOrUpdateStatusCode(int statusCode);
        INotifications AddTraceId(string traceId);

        //Retorna as notas da classe atual;
        IList<string> GetNotes();

        /// <summary>
        /// /Retorna as Notas da classe atual e das filhas
        /// </summary>
        /// <returns></returns>
        IList<string> GetAllNotes();
    }
}
