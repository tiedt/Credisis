using Credisis.Estudos.Application.Command.Cliente;
using Credisis.Estudos.Domain.Models.Cliente;

namespace Credisis.Estudos.Application
{
    public interface IClienteService
    {
        Task<Cliente> CriarAsync(CriarClienteCommand cliente, CancellationToken cancellationToken);
        Task<Cliente> ObterClienteAsync(int id, CancellationToken cancellationToken);
    }
}
