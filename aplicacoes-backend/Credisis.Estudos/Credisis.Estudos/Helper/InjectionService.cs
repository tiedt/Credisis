using Credisis.Estudos.Application;
using Credisis.Estudos.Application.Services.Cliente;

namespace Credisis.Estudos.API.Helper
{
    public static class InjectionService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
        }
    }
}
