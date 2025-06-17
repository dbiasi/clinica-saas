using backend.Dtos.Cobranca;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CobrancaController : ControllerBase
    {
        private readonly ICobrancaService _service;

        public CobrancaController(ICobrancaService service)
        {
            _service = service;
        }

        // POST: api/cobranca
        [HttpPost]
        public async Task<ActionResult<int>> Criar([FromBody] CobrancaCreateDto dto)
        {
            var id = await _service.CriarAsync(dto);
            return Ok(id);
        }

        // GET: api/cobranca/paciente/5
        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<List<CobrancaResponseDto>>> ListarPorPaciente(int pacienteId)
        {
            var lista = await _service.ListarPorPacienteAsync(pacienteId);
            return Ok(lista);
        }

        // GET: api/cobranca/12
        [HttpGet("{id}")]
        public async Task<ActionResult<CobrancaResponseDto>> BuscarPorId(int id)
        {
            var cobranca = await _service.BuscarPorIdAsync(id);
            if (cobranca == null)
                return NotFound();

            return Ok(cobranca);
        }
    }
}
