using Credisis.Estudos.Application;
using Credisis.Estudos.Application.Services.Cliente;
using Credisis.Estudos.Domain.Interfaces.Repository.Cliente;
using Credisis.Estudos.Infra.Repository;

namespace Credisis.Estudos.API.Helper
{
    public static class InjectionRepository
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
