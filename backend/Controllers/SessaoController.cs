using backend.Dtos.Sessao;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

// Todo 
/*
✅ Próximos aprendizados sugeridos:
- Como adicionar validação automática com [Required], [StringLength], etc. nos DTOs.
- Como tratar erros inesperados com try/catch ou middleware.
- Como proteger endpoints com autenticação/autorização ([Authorize]).
 */

// Esse controller lida com requisições HTTP relacionadas às sessao dos pacientes.
// Ele usa um serviço (SessaoService) para fazer a lógica de negócio.
namespace backend.Controllers
{
    [ApiController] // Diz para o ASP.NET que esse controller lida com requisições HTTP e valida automaticamente os dados recebidos.
    [Route("api/[controller]")] // A rota será: api/sessoes
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _service;

        // Construtor injeta o serviço SessaoService. Isso segue o padrão de injeção de dependência.
        public SessaoController(SessaoService service)
        {
            _service = service;
        }

        // GET: api/sessoes
        // Retorna todas as sessoes cadastradas.
        [HttpGet]
        public async Task<ActionResult<List<SessaoResponseDto>>> Get()
        {
            var sessoes = await _service.ListarSessoesAsync(); // Chama o serviço para buscar os dados.
            return Ok(sessoes); // Retorna status 200 + lista de sessoes.
        }

        // GET: api/sessoes/5
        // Retorna uma sessao específica pelo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<SessaoResponseDto>> Get(int id)
        {
            var sessao = await _service.BuscarPorIdAsync(id); // Busca a sessao no banco.
            if (sessao == null)
                return NotFound(); // Retorna 404 se não encontrar.

            return Ok(sessao); // Retorna 200 + dados da sessao.
        }

        // POST: api/sessoes
        // Cria uma nova sessoes.
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SessaoCreateDto dto)
        {
            var id = await _service.CriarSessaoAsync(dto); // Cria a sessao e retorna o ID.
            return CreatedAtAction(nameof(Get), new { id }, null); // Retorna 201 (Created) com o link para acessar a nova sessao.
        }

        // PUT: api/sessoes/5
        // Atualiza uma sessao existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SessaoUpdateDto dto)
        {
            var sucesso = await _service.AtualizarSessaoAsync(id, dto); // Tenta atualizar.
            if (!sucesso)
                return NotFound(); // Retorna 404 se o ID não existir.

            return NoContent(); // Retorna 204 - sucesso, mas sem conteúdo no corpo da resposta.
        }

    }
}
