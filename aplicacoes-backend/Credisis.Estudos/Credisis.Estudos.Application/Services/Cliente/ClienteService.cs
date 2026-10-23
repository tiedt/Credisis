using Credisis.Estudos.Application.Command.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
namespace Credisis.Estudos.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        public Task<Domain.Models.Cliente.Cliente> CriarAsync(CriarClienteCommand cliente, CancellationToken cancellationToken)
        {
            var clienteEntity = new Domain.Models.Cliente.Cliente(cliente.Nome, cliente.Email);

            return null;
        }

        public Task<Domain.Models.Cliente.Cliente> ObterClienteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
