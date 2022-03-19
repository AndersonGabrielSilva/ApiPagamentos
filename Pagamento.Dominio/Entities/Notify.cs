using Pagamento.Dominio.Extensions;
using Pagamento.Dominio.Interfaces;

namespace Pagamento.Dominio.Entities
{
    public abstract class Notify : INotifications
    {
        public Notify()
        {
            Id = Guid.NewGuid();
            _notes = new List<string>();
        }

        public Guid Id { get; }
        public string TraceId { get; private set; }
        public int StatusCode { get; private set; }

        private List<string> _notes { get; set; }

        public IReadOnlyCollection<string> Notes { get => _notes; }

        public bool ContainNotes => !_notes.IsNullOrEmpty();

        public INotifications AddNote(string note)
        {
            _notes.IsNullOrEmpty(CreateInstance: true);
            _notes.Add(note);

            return this;
        }

        public INotifications AddNotes(IList<string> notes)
        {
            _notes.IsNullOrEmpty(CreateInstance: true);

            if (!notes.IsNullOrEmpty())
                _notes.AddRange(notes);

            return this;
        }

        public INotifications AddOrUpdateStatusCode(int statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public INotifications AddTraceId(string traceId)
        {
            if (string.IsNullOrEmpty(TraceId))
                TraceId = traceId;

            return this;
        }
    }
}
