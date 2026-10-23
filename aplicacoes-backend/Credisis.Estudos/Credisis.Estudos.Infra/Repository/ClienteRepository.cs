using System.Collections.Concurrent;
using Credisis.Estudos.Domain.Interfaces.Repository.Cliente;
using ClienteEntity = Credisis.Estudos.Domain.Models.Cliente.Cliente;

namespace Credisis.Estudos.Infra.Repository;

public sealed class ClienteRepository : IClienteRepository
{
    private readonly ConcurrentDictionary<Guid, ClienteEntity> _clientes = new();

    public Task AdicionarAsync(ClienteEntity cliente, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (!_clientes.TryAdd(cliente.Id, cliente))
            throw new InvalidOperationException("Cliente já cadastrado.");
        return Task.CompletedTask;
    }

    public Task<ClienteEntity?> BuscarAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _clientes.TryGetValue(id, out var cliente);
        return Task.FromResult(cliente);
    }
}
