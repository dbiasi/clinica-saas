using backend.Dtos.Consulta;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

// Todo 
/*
✅ Próximos aprendizados sugeridos:
- Como adicionar validação automática com [Required], [StringLength], etc. nos DTOs.
- Como tratar erros inesperados com try/catch ou middleware.
- Como proteger endpoints com autenticação/autorização ([Authorize]).
 */

// Esse controller lida com requisições HTTP relacionadas às consultas dos pacientes.
// Ele usa um serviço (ConsultaService) para fazer a lógica de negócio.
namespace backend.Controllers
{
    [ApiController] // Diz para o ASP.NET que esse controller lida com requisições HTTP e valida automaticamente os dados recebidos.
    [Route("api/[controller]")] // A rota será: api/consultas
    public class ConsultasController : ControllerBase
    {
        private readonly ConsultaService _service;

        // Construtor injeta o serviço ConsultaService. Isso segue o padrão de injeção de dependência.
        public ConsultasController(ConsultaService service)
        {
            _service = service;
        }

        // GET: api/consultas
        // Retorna todas as consultas cadastradas.
        [HttpGet]
        public async Task<ActionResult<List<ConsultaResponseDto>>> Get()
        {
            var consultas = await _service.ListarConsultasAsync(); // Chama o serviço para buscar os dados.
            return Ok(consultas); // Retorna status 200 + lista de consultas.
        }

        // GET: api/consultas/5
        // Retorna uma consulta específica pelo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaResponseDto>> Get(int id)
        {
            var consulta = await _service.BuscarPorIdAsync(id); // Busca a consulta no banco.
            if (consulta == null)
                return NotFound(); // Retorna 404 se não encontrar.

            return Ok(consulta); // Retorna 200 + dados da consulta.
        }

        // POST: api/consultas
        // Cria uma nova consulta.
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConsultaCreateDto dto)
        {
            var id = await _service.CriarConsultaAsync(dto); // Cria a consulta e retorna o ID.
            return CreatedAtAction(nameof(Get), new { id }, null); // Retorna 201 (Created) com o link para acessar a nova consulta.
        }

        // PUT: api/consultas/5
        // Atualiza uma consulta existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ConsultaUpdateDto dto)
        {
            var sucesso = await _service.AtualizarConsultaAsync(id, dto); // Tenta atualizar.
            if (!sucesso)
                return NotFound(); // Retorna 404 se o ID não existir.

            return NoContent(); // Retorna 204 - sucesso, mas sem conteúdo no corpo da resposta.
        }

    }
}
