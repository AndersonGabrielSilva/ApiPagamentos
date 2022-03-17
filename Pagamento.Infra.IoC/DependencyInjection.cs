using Microsoft.Extensions.DependencyInjection;

namespace Pagamento.Infra.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection service)
        {
            // Settings

            service.AddSingleton(App)

            return service;
        }
    }
}
