using Pagamento.Dominio.Entities.Sicoob;
using Pagamento.Dominio.ValueObjects;

namespace Pagamento.Dominio.Entities.Auth
{

    /// <summary>
    /// É a empresa que deseja utilizar a API
    /// </summary>
    public class Usuario : Entity
    {
        public string Nome{ get; set; }

        public int? ExternalId { get; set; }

        public Documento Documento { get; set; }

        public List<Credencias> Credencias { get; set; }

    }
}
