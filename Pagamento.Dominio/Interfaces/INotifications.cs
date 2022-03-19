namespace Pagamento.Dominio.Interfaces
{
    public interface INotifications
    {
        Guid Id { get; }
        string TraceId { get;}
        int StatusCode { get;}

        bool ContainNotes { get; }

        IReadOnlyCollection<string> Notes { get; }

        INotifications AddNote(string note);
        INotifications AddNotes(IList<string> notes);
        INotifications AddOrUpdateStatusCode(int statusCode);
        INotifications AddTraceId(string traceId);
    }
}
