using backend.Dtos.Psiquiatra; // Importa os DTOs usados nos métodos da interface
using Microsoft.AspNetCore.Mvc; // Importa o namespace para controllers
using backend.Services.Interfaces; // Importa a interface que estamos implementando

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PsiquiatraController : ControllerBase
    {
        private readonly IPsiquiatraService _service;

        public PsiquiatraController(IPsiquiatraService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] PsiquiatraCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var psiquiatra = await _service.BuscarPorIdAsync(id);
            if (psiquiatra == null)
                return NotFound();

            return Ok(psiquiatra);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var psiquiatras = await _service.ListarTodosAsync();
            return Ok(psiquiatras);
        }
    }
}