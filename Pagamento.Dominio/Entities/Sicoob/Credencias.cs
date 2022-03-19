using Pagamento.Dominio.Entities.Auth;
using Pagamento.Dominio.Enum;
using System.Collections.Generic;

namespace Pagamento.Dominio.Entities.Sicoob
{
    public class Credencias : Entity
    {
        #region Dados da Credencial
        public string Cooperativa { get; set; }
        public string Conta { get; set; }
        public string ChaveAcesso { get; set; }
        public string Senha { get; set; }

        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string TokenBasic { get; set; }
        public string URLAuthorize { get; set; }

        public TipoPessoa Tipo { get; set; }
        #endregion

        #region Relacionamentos
        public int? AcessTokenRequestId { get; set; }
        public virtual AcessTokenRequest AcessTokenRequest { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        #endregion

        #region Dados Mokados
        public static List<Credencias> GetCredenciasFactory()
        {
            return new List<Credencias> 
            {
                new Credencias() 
                {
                    Cooperativa = "0001",
                    Conta = "700033690",
                    Senha = "12345678",

                    ClientID = "Kn9R_9aQem4GBoD6883JDjFICNka", 
                    ClientSecret = "DaC1YcEcmEgUR1R5yCerp2pHsv8a", 
                    TokenBasic = "S245Ul85YVFlbTRHQm9ENjg4M0pEakZJQ05rYTpEYUMxWWNFY21FZ1VSMVI1eUNlcnAycEhzdjhh", 
                    URLAuthorize = @"https://sandbox.sicoob.com.br/oauth2/authorize?response_type=code&redirect_uri=null&client_id=Kn9R_9aQem4GBoD6883JDjFICNka" ,
                    Tipo = TipoPessoa.PessoaFisica
                } ,
                
                new Credencias()
                {
                    Cooperativa = "0001",
                    ChaveAcesso = "SD0002",
                    Senha = "12345678",

                    ClientID = "EYepH4GHTPrtTUGOUvNf8UAIOc0a",
                    ClientSecret = "Aw9IvaWEeFq_Si83fSxbaNuzKDca",
                    TokenBasic = "RVllcEg0R0hUUHJ0VFVHT1V2TmY4VUFJT2MwYTpBdzlJdmFXRWVGcV9TaTgzZlN4YmFOdXpLRGNh",
                    URLAuthorize = @"https://sandbox.sicoob.com.br/oauth2/authorize?response_type=code&redirect_uri=null&client_id=EYepH4GHTPrtTUGOUvNf8UAIOc0a",
                    Tipo = TipoPessoa.PessoaJuridica
                } 
            };
            
        }
        #endregion
    }
}
