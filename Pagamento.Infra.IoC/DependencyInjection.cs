using Microsoft.Extensions.DependencyInjection;
using Pagamento.Aplicacao.Services;
using Pagamento.Dominio.Interfaces.Services;


namespace Pagamento.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection service)
        {            
            //Repositories

            //Services
            service.AddSingleton<IAuthSicoobService, AuthSicoobService>();

            return service;
        }
    }
}
