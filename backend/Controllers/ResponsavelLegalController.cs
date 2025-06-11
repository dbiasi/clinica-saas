using backend.Dtos.ResponsavelLegal;
using Microsoft.AspNetCore.Mvc;
using backend.Services.Interfaces;

namespace backend.Controllers{
    [ApiController] // Diz ao ASP.NET Core que essa classe será usada como API REST. Ela ativa comportamentos automáticos como:
                    // Validação automática de modelos ([FromBody] ou [FromQuery])
                    // Respostas HTTP 400 (Bad Request) se os dados estiverem inválidos
                    // Binding de parâmetros (ex: pegar JSON e transformar em DTO automaticamente)
                    // Documentação automática via Swagger

    [Route("api/[controller]")]   //Significa: usar o nome da classe (sem "Controller") como rota. Ou seja:
                                // /api/ResponsavelLegal para acessar esse controller.
                                // O ASP.NET Core irá substituir [controller] pelo nome da classe (ResponsavelLegalController)
                                // e remover o sufixo "Controller" automaticamente.

    // A herança de ControllerBase fornece métodos e propriedades essenciais como:
        // Ok(...) → Retorna 200
        // NotFound() → Retorna 404
        // CreatedAtAction(...) → Retorna 201
        // BadRequest() → Retorna 400
        // Acesso ao HttpContext, Request, User, etc.
        // Sem ControllerBase, você teria que escrever isso tudo na mão.
    public class ResponsavelLegalController : ControllerBase
    {
    // Essa é a injeção de dependência. A interface IResponsavelLegalService representa um serviço que contém a lógica de negócio e comunicação com o banco.
    // Ao manter como uma propriedade privada _service, conseguimos usar os métodos implementados no service dentro dos endpoints, como CriarAsync, BuscarPorIdAsync, ListarTodosAsync.    
        private readonly IResponsavelLegalService _service;

    // O ASP.NET Core, ao iniciar a aplicação, injeta uma instância concreta do serviço configurado (ex: ResponsavelLegalService) que implementa a interface IResponsavelLegalService.
        public ResponsavelLegalController(IResponsavelLegalService service)
        {
            _service = service; // Armazena a instância para usar nos endpoints
        }

        // POST /ResponsavelLegal
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ResponsavelLegalCreateDto dto)
        {
            var id = await _service.CriarAsync(dto); // Cria o responsável e retorna o ID criado
            return CreatedAtAction(nameof(Get), new { id }, id); // Retorna 201 Created + rota para consultar
        }

        // GET /ResponsavelLegal/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsavelLegalResponseDto>> Get(int id)
        {
            var resp = await _service.BuscarPorIdAsync(id); // Busca o responsável por ID
            if (resp == null)
                return NotFound(); // Retorna 404 se não encontrar

            return Ok(resp); // Retorna 200 + dados do responsável
        }

        // GET /ResponsavelLegal
        [HttpGet]
        public async Task<ActionResult<List<ResponsavelLegalResponseDto>>> GetAll()
        {
            return Ok(await _service.ListarTodosAsync()); // Retorna todos os responsáveis cadastrados
        }
    }
}

