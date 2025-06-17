using backend.Dtos.Dimensao;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DimensaoController : ControllerBase
    {
        private readonly IDimensaoService _service;

        public DimensaoController(IDimensaoService service)
        {
            _service = service;
        }

        // POST: api/dimensao
        [HttpPost]
        public async Task<ActionResult<int>> Criar([FromBody] DimensaoCreateDto dto)
        {
            var id = await _service.CriarAsync(dto);
            return Ok(id);
        }

        // GET: api/dimensao
        [HttpGet]
        public async Task<ActionResult<List<DimensaoResponseDto>>> Listar()
        {
            var lista = await _service.ListarAsync();
            return Ok(lista);
        }
    }
}
