using backend.Data; // Importa o ClinicaContext : DbContext (onde estão as tabelas do banco)
using backend.Dtos.Consulta; // Importa os DTOs para entrada e saída de dados
using backend.Models; // Importa o modelo Consulta
using Microsoft.EntityFrameworkCore; // Para usar funcionalidades async com o banco

namespace backend.Services
{
    public class ConsultaService
    {
        private readonly ClinicaContext _context;

        // Construtor recebe o DbContext por injeção de dependência
        public ConsultaService(ClinicaContext context)
        {
            _context = context;
        }

        // Cria uma nova consulta no banco
        public async Task<int> CriarConsultaAsync(ConsultaCreateDto dto)
        {
            var consulta = new Consulta
            {
                PacienteId = dto.PacienteId,
                DataHora = dto.DataHora,
                Valor = dto.Valor,
                Observacao = dto.Observacao,
                Status = "Agendada" // Status padrão ao criar
            };

            _context.Consultas.Add(consulta);  // Marca para adicionar no banco
            await _context.SaveChangesAsync(); // Salva de verdade no banco
            return consulta.Id; // Retorna o ID gerado
        }

        // Lista todas as consultas, com nome do paciente
        public async Task<List<ConsultaResponseDto>> ListarConsultasAsync()
        {
            return await _context.Consultas
                .Include(c => c.Paciente) // Inclui os dados do paciente (JOIN)
                .OrderBy(c => c.DataHora) // Ordena pela data da consulta
                .Select(c => new ConsultaResponseDto // Monta o DTO de resposta
                {
                    Id = c.Id,
                    PacienteId = c.PacienteId,
                    NomePaciente = c.Paciente != null ? c.Paciente.Nome : string.Empty,
                    DataHora = c.DataHora,
                    Status = c.Status,
                    Valor = c.Valor,
                    Observacao = c.Observacao
                })
                .ToListAsync(); // Executa a query e retorna a lista
        }

        // Busca uma consulta específica pelo ID
        public async Task<ConsultaResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Where(c => c.Id == id)
                .Select(c => new ConsultaResponseDto
                {
                    Id = c.Id,
                    PacienteId = c.PacienteId,
                    NomePaciente = c.Paciente != null ? c.Paciente.Nome : string.Empty,
                    DataHora = c.DataHora,
                    Status = c.Status,
                    Valor = c.Valor,
                    Observacao = c.Observacao
                })
                .FirstOrDefaultAsync(); 
        }


        public async Task<bool> AtualizarConsultaAsync(int id, ConsultaUpdateDto dto)
        {
            var consulta = await _context.Consultas.FindAsync(id); // Busca a consulta no banco
            if (consulta == null) 
                return false; // Se não achou, retorna falso

            // Atualiza os campos
            consulta.DataHora = dto.DataHora;
            consulta.Status = dto.Status;
            consulta.Valor = dto.Valor;
            consulta.Observacao = dto.Observacao;

            await _context.SaveChangesAsync(); // Salva as alterações
            return true;
        }
    }
}
