using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.Settings
{
    public class AppSettings
    {

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
