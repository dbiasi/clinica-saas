using backend.Dtos.RelatorioSessao;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioSessaoController : ControllerBase
    {
        private readonly IRelatorioSessaoService _service;

        public RelatorioSessaoController(IRelatorioSessaoService service)
        {
            _service = service;
        }

        // POST: api/relatoriosessao/sessao/5
        [HttpPost("sessao/{sessaoId}")]
        public async Task<ActionResult<RelatorioSessaoResponseDto>> CriarOuAtualizar(int sessaoId, [FromBody] RelatorioSessaoCreateDto dto)
        {
            var resultado = await _service.CriarOuAtualizarAsync(sessaoId, dto);
            return Ok(resultado);
        }

        // GET: api/relatoriosessao/sessao/5
        [HttpGet("sessao/{sessaoId}")]
        public async Task<ActionResult<RelatorioSessaoResponseDto>> BuscarPorSessao(int sessaoId)
        {
            var relatorio = await _service.BuscarPorSessaoIdAsync(sessaoId);
            if (relatorio == null)
                return NotFound();

            return Ok(relatorio);
        }

        // PUT: api/relatoriosessao/3
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] RelatorioSessaoUpdateDto dto)
        {
            var atualizado = await _service.AtualizarAsync(id, dto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }
    }
}
