using Credisis.Estudos.Application;
using Credisis.Estudos.Application.Command.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace Credisis.Estudos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(IClienteService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarClienteCommand command)
        {
            var cliente = await service.CriarAsync(command, CancellationToken.None);
            return CreatedAtAction(nameof(Obter), new { id = cliente.Id }, cliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var cliente = await service.ObterClienteAsync(id, CancellationToken.None);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }
}
