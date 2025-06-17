using backend.Data; // Importa o ClinicaContext : DbContext (onde estão as tabelas do banco)
using backend.Dtos.Sessao; // Importa os DTOs para entrada e saída de dados
using backend.Models; // Importa o modelo Sessao
using backend.Enums;
using Microsoft.EntityFrameworkCore; // Para usar funcionalidades async com o banco
using backend.Services.Interfaces;

namespace backend.Services
{
    public class SessaoService : ISessaoService
    {
        private readonly ClinicaContext _context;

        // Construtor recebe o DbContext por injeção de dependência
        public SessaoService(ClinicaContext context)
        {
            _context = context;
        }

        // Cria uma nova consulta no banco
        public async Task<int> CriarSessaoAsync(SessaoCreateDto dto)
        {
            var sessao = new Sessao
            {
                PacienteId = dto.PacienteId,
                DataHora = dto.DataHora,
                Valor = dto.Valor,
                Observacao = dto.Observacao,
                Status = SessaoStatus.Agendada // Status padrão ao criar
            };

            _context.Sessoes.Add(sessao);  // Marca para adicionar no banco
            await _context.SaveChangesAsync(); // Salva de verdade no banco
            return sessao.Id; // Retorna o ID gerado
        }

        // Lista todas as sessoes, com nome do paciente
        public async Task<List<SessaoResponseDto>> ListarSessoesAsync()
        {
            return await _context.Sessoes
                .Include(c => c.Paciente) // Inclui os dados do paciente (JOIN)
                .OrderBy(c => c.DataHora) // Ordena pela data da sessao
                .Select(c => new SessaoResponseDto // Monta o DTO de resposta
                {
                    Id = c.Id,
                    PacienteId = c.PacienteId,
                    NomePaciente = c.Paciente != null ? c.Paciente.Nome : string.Empty,
                    DataHora = c.DataHora,
                    Status = c.Status.ToString(), // Converte o enum para string
                    Valor = c.Valor,
                    Observacao = c.Observacao
                })
                .ToListAsync(); // Executa a query e retorna a lista
        }

        // Busca uma sessao específica pelo ID
        public async Task<SessaoResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Sessoes
                .Include(c => c.Paciente)
                .Where(c => c.Id == id)
                .Select(c => new SessaoResponseDto
                {
                    Id = c.Id,
                    PacienteId = c.PacienteId,
                    NomePaciente = c.Paciente != null ? c.Paciente.Nome : string.Empty,
                    DataHora = c.DataHora,
                    Status = c.Status.ToString(),
                    Valor = c.Valor,
                    Observacao = c.Observacao
                })
                .FirstOrDefaultAsync(); 
        }


        public async Task<bool> AtualizarSessaoAsync(int id, SessaoUpdateDto dto)
        {
            var sessao = await _context.Sessoes.FindAsync(id); // Busca a sessao no banco
            if (sessao == null) 
                return false; // Se não achou, retorna falso

            // Atualiza os campos
            sessao.DataHora = dto.DataHora;
            sessao.Status = dto.Status;
            sessao.Valor = dto.Valor;
            sessao.Observacao = dto.Observacao;

            await _context.SaveChangesAsync(); // Salva as alterações
            return true;
        }
    }
}
