using backend.Dtos.Dimensao;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoDimensaoController : ControllerBase
    {
        private readonly IAvaliacaoDimensaoService _service;

        public AvaliacaoDimensaoController(IAvaliacaoDimensaoService service)
        {
            _service = service;
        }

        // POST: api/avaliacaodimensao
        [HttpPost]
        public async Task<ActionResult<int>> Criar([FromBody] AvaliacaoDimensaoCreateDto dto)
        {
            var id = await _service.CriarAsync(dto);
            return Ok(id);
        }

        // GET: api/avaliacaodimensao/paciente/5
        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<List<AvaliacaoDimensaoResponseDto>>> ListarPorPaciente(int pacienteId)
        {
            var avaliacoes = await _service.ListarPorPacienteAsync(pacienteId);
            return Ok(avaliacoes);
        }

        // GET: api/avaliacaodimensao/paciente/5/dimensao/2
        [HttpGet("paciente/{pacienteId}/dimensao/{dimensaoId}")]
        public async Task<ActionResult<List<AvaliacaoDimensaoResponseDto>>> ListarPorDimensao(int pacienteId, int dimensaoId)
        {
            var avaliacoes = await _service.ListarPorDimensaoAsync(pacienteId, dimensaoId);
            return Ok(avaliacoes);
        }
    }
}
