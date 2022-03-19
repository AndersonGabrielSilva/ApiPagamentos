namespace Pagamento.Dominio.DTO.Sicoob
{
    public class UrlAutorizeoAuth2DTO
    {
        public UrlAutorizeoAuth2DTO(int usuarioId, int credenciasId, string urlAutorize)
        {
            this.UsuarioId = usuarioId;
            this.CredencialId = credenciasId;
            this.UrlAutorizeoAuth2 = urlAutorize;
        }

        public int UsuarioId { get; set; }
        public int CredencialId { get; set; }

        public string UrlAutorizeoAuth2 { get; set; }
    }
}
