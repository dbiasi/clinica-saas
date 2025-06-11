using Microsoft.AspNetCore.Mvc;
using backend.Dtos.Paciente;
using backend.Services;

namespace backend.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacientesController(PacienteService service)
        {
            _service = service;
        }

        // GET: api/pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteResponseDto>>> GetPacientes()
        {
            var pacientes = await _service.ListarPacientesAsync();
            return Ok(pacientes);
        }

        // GET: api/pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteResponseDto>> GetPaciente(int id)
        {
            var paciente = await _service.BuscarPorIdAsync(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        // POST: api/pacientes
        [HttpPost]
        public async Task<ActionResult> PostPaciente([FromBody] PacienteCreateDto dto)
        {
            var id = await _service.CriarPacienteAsync(dto);
            return CreatedAtAction(nameof(GetPaciente), new { id }, null);
        }

        // PUT: api/pacientes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPaciente(int id, [FromBody] PacienteUpdateDto dto)
        {
            var sucesso = await _service.AtualizarPacienteAsync(id, dto);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        // DELETE (DESATIVAR): api/pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DesativarPaciente(int id)
        {
            var sucesso = await _service.DesativarPacienteAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
