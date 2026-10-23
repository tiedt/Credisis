using Credisis.Estudos.Application.Command.Cliente;
using Credisis.Estudos.Application.Dto.Cliente;
using Credisis.Estudos.Domain.Interfaces.Repository.Cliente;
using ClienteEntity = Credisis.Estudos.Domain.Models.Cliente.Cliente;

namespace Credisis.Estudos.Application.Services.Cliente;

public class ClienteService(IClienteRepository repository) : IClienteService
{
    public async Task<ClienteDto> CriarAsync(CriarClienteCommand command, CancellationToken cancellationToken)
    {
        var cliente = new ClienteEntity(command.Nome, command.Email);
        await repository.AdicionarAsync(cliente, cancellationToken);
        return Mapear(cliente);
    }

    public async Task<ClienteDto?> ObterClienteAsync(Guid id, CancellationToken cancellationToken)
    {
        var cliente = await repository.BuscarAsync(id, cancellationToken);
        return cliente is null ? null : Mapear(cliente);
    }

    private static ClienteDto Mapear(ClienteEntity cliente) =>
        new(cliente.Id, cliente.Nome, cliente.Email);
}
