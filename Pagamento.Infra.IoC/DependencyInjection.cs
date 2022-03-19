using Microsoft.Extensions.DependencyInjection;
using Pagamento.Aplicacao.Services;
using Pagamento.Dominio.Interfaces.Repositories;
using Pagamento.Dominio.Interfaces.Services;
using Pagamento.Infra.Data.Repositories;

namespace Pagamento.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection service)
        {            
            //Repositories
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services
            service.AddScoped<IAuthSicoobService, AuthSicoobService>();

            return service;
        }
    }
}
