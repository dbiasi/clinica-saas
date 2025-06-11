using backend.Dtos.Psicologa;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PsicologaController : ControllerBase
    {
        private readonly IPsicologaService _service;

        public PsicologaController(IPsicologaService service)
        {
            _service = service;
        }

        // POST: /Psicologa
        [HttpPost]
        public async Task<ActionResult<PsicologaResponseDto>> Criar([FromBody] PsicologaCreateDto dto)
        {
            var nova = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = nova.Id }, nova);
        }

        // GET: /Psicologa
        [HttpGet]
        public async Task<ActionResult<List<PsicologaResponseDto>>> BuscarTodas()
        {
            var lista = await _service.BuscarTodasAsync();
            return Ok(lista);
        }

        // GET: /Psicologa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PsicologaResponseDto>> BuscarPorId(int id)
        {
            var psicologa = await _service.BuscarPorIdAsync(id);
            if (psicologa == null)
                return NotFound();

            return Ok(psicologa);
        }

        // PUT: /Psicologa/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] PsicologaUpdateDto dto)
        {
            var sucesso = await _service.AtualizarAsync(id, dto);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        // DELETE: /Psicologa/5
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
