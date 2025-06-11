using backend.Dtos.Tarefa;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefaController(ITarefaService service)
        {
            _service = service;
        }

        // POST: /Tarefa
        [HttpPost]
        public async Task<ActionResult<TarefaResponseDto>> Criar([FromBody] TarefaCreateDto dto)
        {
            var novaTarefa = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaTarefa.Id }, novaTarefa);
        }

        // GET: /Tarefa/paciente/5
        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<List<TarefaResponseDto>>> BuscarPorPaciente(int pacienteId)
        {
            var tarefas = await _service.BuscarPorPacienteAsync(pacienteId);
            return Ok(tarefas);
        }

        // GET: /Tarefa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaResponseDto>> BuscarPorId(int id)
        {
            var tarefa = await _service.BuscarPorIdAsync(id);
            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        // PUT: /Tarefa/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] TarefaUpdateDto dto)
        {
            var sucesso = await _service.AtualizarAsync(id, dto);
            if (!sucesso)
                return NotFound();

            return NoContent(); // Atualização bem-sucedida sem conteúdo
        }

        // DELETE: /Tarefa/5
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
