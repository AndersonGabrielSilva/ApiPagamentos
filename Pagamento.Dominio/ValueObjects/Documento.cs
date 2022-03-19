using Pagamento.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Dominio.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string nroDocumento, TipoDocumento tipoDocumento)
        {
            Numero = nroDocumento;
            Tipo = tipoDocumento;
        }

        public string Numero { get; }
        public TipoDocumento Tipo { get; }


        public static implicit operator string(Documento documento)
        {
            switch (documento.Tipo)
            {
                case TipoDocumento.Cpf:
                    return documento.Numero;
                case TipoDocumento.Cnpj:
                    return documento.Numero;
            }

            return documento.Numero;
        }        
    }
}
