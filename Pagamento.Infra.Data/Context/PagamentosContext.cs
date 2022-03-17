using Microsoft.EntityFrameworkCore;
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



    }
}
