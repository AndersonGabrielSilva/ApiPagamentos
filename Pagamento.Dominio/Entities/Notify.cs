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

        private bool _containErrors;
        public bool ContainErrors { get => _containErrors; }

        private INotifications _notifications;
        public INotifications Notifications => _notifications;

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
            _containErrors = true;

            if (string.IsNullOrEmpty(TraceId))
                TraceId = traceId;

            return this;
        }

        public IList<string> GetNotes() => _notes;

        public INotifications AddNotify(INotifications notifications)
        {
            _notifications = notifications;

            return this;
        }

        public IList<string> GetAllNotes()
        {
            var result = new List<string>();
            var notesAll = Notifications?.GetAllNotes();

            if (!_notes.IsNullOrEmpty())
                result.AddRange(_notes);

            if (!notesAll.IsNullOrEmpty())
                result.AddRange(notesAll);

            return result;
        }
    }
}
