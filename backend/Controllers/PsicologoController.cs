using backend.Dtos.Psicologo;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PsicologoController : ControllerBase
    {
        private readonly IPsicologoService _service;

        public PsicologoController(IPsicologoService service)
        {
            _service = service;
        }

        // POST: /Psicologo
        [HttpPost]
        public async Task<ActionResult<PsicologoResponseDto>> Criar([FromBody] PsicologoCreateDto dto)
        {
            var nova = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = nova.Id }, nova);
        }

        // GET: /Psicologo
        [HttpGet]
        public async Task<ActionResult<List<PsicologoResponseDto>>> BuscarTodas()
        {
            var lista = await _service.BuscarTodasAsync();
            return Ok(lista);
        }

        // GET: /Psicologo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PsicologoResponseDto>> BuscarPorId(int id)
        {
            var psicologo = await _service.BuscarPorIdAsync(id);
            if (psicologo == null)
                return NotFound();

            return Ok(psicologo);
        }

        // PUT: /Psicologo/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] PsicologoUpdateDto dto)
        {
            var sucesso = await _service.AtualizarAsync(id, dto);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        // DELETE: /Psicologo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var sucesso = await _service.DeletarAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
