using System.Collections.Concurrent;
using Credisis.Estudos.Domain.Interfaces.Repository.Cliente;
using Credisis.Estudos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using ClienteEntity = Credisis.Estudos.Domain.Models.Cliente.Cliente;

namespace Credisis.Estudos.Infra.Repository;

public sealed class ClienteRepository(CredisisEstudosDbContext context) : IClienteRepository
{
    public async Task AdicionarAsync(ClienteEntity cliente, CancellationToken cancellationToken)
    {
        context.Clientes.Add(cliente);
        await context.SaveChangesAsync();
    }

    public async Task<ClienteEntity?> BuscarAsync(Guid id, CancellationToken cancellationToken) => await context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}
