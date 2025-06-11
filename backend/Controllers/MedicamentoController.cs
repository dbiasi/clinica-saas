using backend.Dtos.Medicamento;
using Microsoft.AspNetCore.Mvc;
using backend.Services.Interfaces;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _service;

        public MedicamentoController(IMedicamentoService service)
        {
            _service = service; // Armazena a instância para usar nos endpoints
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] MedicamentoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.CriarAsync(dto); // Cria o Medicamento e retorna o ID criado
            return CreatedAtAction(nameof(Get), new { id }, id); // Retorna 201 Created + rota para consultar
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicamentoResponseDto>> Get(int id)
        {
            var resp = await _service.BuscarPorIdAsync(id); // Busca o Medicamento por ID
            if (resp == null)
                return NotFound(); // Retorna 404 se não encontrar

            return Ok(resp); // Retorna 200 + dados do medicamento
        }

        // GET /ResponsavelLegal
        [HttpGet]
        public async Task<ActionResult<List<MedicamentoResponseDto>>> GetAll()
        {
            var lista = await _service.ListarTodosAsync();
            return Ok(lista);
        }
    }
}

