namespace Pagamento.Dominio.Settings
{
    public class AppSettings
    {
        public string Ambiente { get; set; }

        public Sicoob Sicoob { get; set; }
    }

    public class Sicoob
    {
        public string UrlAutenticaOAuth2 { get; set; }
        public string UrlAccessToken { get; set; }

        public string HomoUrlAutenticaOAuth2 { get; set; }        
        public string HomoUrlAccessToken { get; set; }
    }
}
