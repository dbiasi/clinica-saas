using backend.Data; // Importa o contexto do banco de dados
using backend.Dtos.Psiquiatra; // Importa os DTOs usados nos métodos
using backend.Services.Interfaces; // Importa a interface que estamos implementando
using backend.Models; // Importa a model Psiquiatra
using Microsoft.EntityFrameworkCore; // Importa métodos assíncronos do EF Core

public class PsiquiatraService : IPsiquiatraService
{
    private readonly ClinicaContext _context;

    // Injeção do DbContext via construtor
    public PsiquiatraService(ClinicaContext context)
    {
        _context = context;
    }

    // Cria um novo psiquiatra a partir do DTO recebido
    public async Task<int> CriarAsync(PsiquiatraCreateDto dto)
    {
        var model = new Psiquiatra
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            Email = dto.Email,
            CRM = dto.CRM,
            Especialidade = dto.Especialidade
        };

        _context.Psiquiatras.Add(model);
        await _context.SaveChangesAsync();

        return model.Id;
    }

    // Busca um psiquiatra pelo ID e retorna os dados no formato de DTO
    public async Task<PsiquiatraResponseDto?> BuscarPorIdAsync(int id)
    {
        return await _context.Psiquiatras
            .Where(x => x.Id == id)
            .Select(x => new PsiquiatraResponseDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Telefone = x.Telefone,
                Email = x.Email,
                CRM = x.CRM,
                Especialidade = x.Especialidade
            })
            .FirstOrDefaultAsync();
    }

    // Lista todos os psiquiatras do banco e projeta para DTOs
    public async Task<List<PsiquiatraResponseDto>> ListarTodosAsync()
    {
        return await _context.Psiquiatras
            .Select(x => new PsiquiatraResponseDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Telefone = x.Telefone,
                Email = x.Email,
                CRM = x.CRM,
                Especialidade = x.Especialidade
            })
            .ToListAsync();
    }
}