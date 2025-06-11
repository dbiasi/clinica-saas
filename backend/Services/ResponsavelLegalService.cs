using backend.Data; // - O contexto do banco (ClinicaContext)
using backend.Dtos.ResponsavelLegal; // - Os DTOs de entrada/saída
using backend.Services.Interfaces; // - A interface que estamos implementando
using backend.Models; // - A model ResponsavelLegal
using Microsoft.EntityFrameworkCore; // - Métodos assíncronos do EF Core

// Classe concreta que implementa a interface IResponsavelLegalService
public class ResponsavelLegalService : IResponsavelLegalService
{
    private readonly ClinicaContext _context;

    // Injeção do DbContext via construtor
    public ResponsavelLegalService(ClinicaContext context)
    {
        _context = context;
    }

    // Cria um novo responsável legal a partir do DTO recebido
    public async Task<int> CriarAsync(ResponsavelLegalCreateDto dto)
    {
        // Mapeia o DTO para a entidade que será salva no banco
        var model = new ResponsavelLegal
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            Email = dto.Email,
            CPF = dto.CPF,
            Parentesco = dto.Parentesco
        };

        // Adiciona no contexto (em memória, ainda não foi persistido)
        _context.ResponsaveisLegais.Add(model);

        // Salva no banco de dados de fato
        await _context.SaveChangesAsync();

        // Retorna o ID gerado (Identity)
        return model.Id;
    }

    // Busca um responsável legal pelo ID e retorna os dados no formato de DTO
    public async Task<ResponsavelLegalResponseDto?> BuscarPorIdAsync(int id)
    {
        return await _context.ResponsaveisLegais
            .Where(x => x.Id == id) // Filtra pelo ID
            .Select(x => new ResponsavelLegalResponseDto // Projeta os dados diretamente para DTO (evita carregar a entidade completa)
            {
                Id = x.Id,
                Nome = x.Nome,
                Telefone = x.Telefone,
                Email = x.Email,
                CPF = x.CPF,
                Parentesco = x.Parentesco
            })
            .FirstOrDefaultAsync(); // Retorna o primeiro resultado ou null
    }

    // Lista todos os responsáveis legais do banco e projeta para DTOs
    public async Task<List<ResponsavelLegalResponseDto>> ListarTodosAsync()
    {
        return await _context.ResponsaveisLegais
            .Select(x => new ResponsavelLegalResponseDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Telefone = x.Telefone,
                Email = x.Email,
                CPF = x.CPF,
                Parentesco = x.Parentesco
            })
            .ToListAsync(); // Executa a consulta no banco e retorna a lista
    }
}

// O serviço ResponsavelLegalService implementa a interface IResponsavelLegalService e fornece a lógica de negócios para gerenciar responsáveis legais.
// Ele utiliza o contexto do Entity Framework (ClinicaContext) para interagir com o banco de dados.
// O serviço possui três métodos principais:
// 1. CriarAsync: Cria um novo responsável legal no banco de dados a partir de um DTO de criação.
// 2. BuscarPorIdAsync: Busca um responsável legal pelo ID e retorna um DTO de resposta com os detalhes do responsável legal.
// 3. ListarTodosAsync: Lista todos os responsáveis legais cadastrados no banco de dados, retornando uma lista de DTOs de resposta.
// Por que fizemos isso?
// Para colocar a regra de negócio da entidade. O Controller não deve fazer regras diretamente — deve apenas receber a requisição e chamar os métodos do Service.