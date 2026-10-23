using ClienteEntity = Credisis.Estudos.Domain.Models.Cliente.Cliente;

namespace Credisis.Estudos.Domain.Interfaces.Repository.Cliente;

public interface IClienteRepository
{
    Task AdicionarAsync(ClienteEntity cliente, CancellationToken cancellationToken);
    Task<ClienteEntity?> BuscarAsync(Guid id, CancellationToken cancellationToken);
}
