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
        public async Task<IActionResult> Criar([FromBody] CriarClienteCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await service.CriarAsync(command, cancellationToken);
                return CreatedAtAction(nameof(Obter), new { id = cliente.Id }, cliente);
            }
            catch (ArgumentException exception)
            {
                ModelState.AddModelError(exception.ParamName ?? string.Empty, exception.Message);
                return ValidationProblem(ModelState);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(Guid id, CancellationToken cancellationToken)
        {
            var cliente = await service.ObterClienteAsync(id, cancellationToken);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }
}
