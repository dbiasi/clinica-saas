using backend.Dtos.PacienteMedicamento;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteMedicamentoController : ControllerBase
    {
        private readonly IPacienteMedicamentoService _service;

        public PacienteMedicamentoController(IPacienteMedicamentoService service)
        {
            _service = service;
        }

        // POST: api/PacienteMedicamento
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PacienteMedicamentoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        // GET: api/PacienteMedicamento/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteMedicamentoResponseDto>> Get(int id)
        {
            var registro = await _service.BuscarPorIdAsync(id);
            if (registro == null)
                return NotFound();

            return Ok(registro);
        }

        // GET: api/PacienteMedicamento/paciente/{pacienteId}
        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<List<PacienteMedicamentoResponseDto>>> GetByPaciente(int pacienteId)
        {
            var lista = await _service.ListarPorPacienteAsync(pacienteId);
            return Ok(lista);
        }
    }
}
