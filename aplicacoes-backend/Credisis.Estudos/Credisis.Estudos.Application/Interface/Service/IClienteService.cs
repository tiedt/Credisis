using Credisis.Estudos.Application.Command.Cliente;
using Credisis.Estudos.Application.Dto.Cliente;

namespace Credisis.Estudos.Application;

public interface IClienteService
{
    Task<ClienteDto> CriarAsync(CriarClienteCommand command, CancellationToken cancellationToken);
    Task<ClienteDto?> ObterClienteAsync(Guid id, CancellationToken cancellationToken);
}
