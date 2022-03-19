using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }

        public DateTime DtaCreate { get; set; }
        public DateTime DtaUpdate { get; set; }
        public string NoteUpdate { get; set; }

        public bool IsActive { get; set; }
    }
}
