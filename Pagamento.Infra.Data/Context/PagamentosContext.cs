using Microsoft.EntityFrameworkCore;
using Pagamento.Dominio.Entities.Auth;
using Pagamento.Dominio.Entities.Sicoob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamento.Infra.Data.Context
{
    public class PagamentosContext : DbContext
    {
        
        public PagamentosContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Credencias> Credencias { get; set; }
        public DbSet<AcessTokenRequest> AcessTokenRequest { get; set; }

    }
}
