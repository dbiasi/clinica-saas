using backend.Dtos.Pagamento;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _service;

        public PagamentoController(IPagamentoService service)
        {
            _service = service;
        }

        // POST: api/pagamento
        [HttpPost]
        public async Task<ActionResult<int>> Criar([FromBody] PagamentoCreateDto dto)
        {
            var id = await _service.CriarAsync(dto);
            return Ok(id);
        }

        // GET: api/pagamento/cobranca/5
        [HttpGet("cobranca/{cobrancaId}")]
        public async Task<ActionResult<List<PagamentoResponseDto>>> ListarPorCobranca(int cobrancaId)
        {
            var lista = await _service.ListarPorCobrancaAsync(cobrancaId);
            return Ok(lista);
        }
    }
}
