namespace Pagamento.Dominio.DTO
{
    public class ResponseError
    {
        public Guid? Id { get; set; }

        public string Mensagem { get; set; }

        public List<string> Notes { get; set; } = new List<string>();
    }
}
