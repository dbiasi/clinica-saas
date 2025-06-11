using backend.Data;
using backend.Dtos.Tarefa;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ClinicaContext _context;

        public TarefaService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<TarefaResponseDto> CriarAsync(TarefaCreateDto dto)
        {
            var tarefa = new Tarefa
            {
                Descricao = dto.Descricao,
                DataLimite = dto.DataLimite,
                DataCriacao = DateTime.Now,
                PacienteId = dto.PacienteId,
                PsicologoId = dto.PsicologoId,
                Concluida = false
            };

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return await BuscarPorIdAsync(tarefa.Id) ?? throw new Exception("Erro ao criar tarefa");
        }

        public async Task<List<TarefaResponseDto>> BuscarPorPacienteAsync(int pacienteId)
        {
            return await _context.Tarefas
                .Where(t => t.PacienteId == pacienteId)
                .Include(t => t.Paciente)
                .Include(t => t.Psicologo)
                .Select(t => new TarefaResponseDto
                {
                    Id = t.Id,
                    Descricao = t.Descricao,
                    Concluida = t.Concluida,
                    ObservacoesPaciente = t.ObservacoesPaciente,
                    DataCriacao = t.DataCriacao,
                    DataLimite = t.DataLimite,
                    DataConclusao = t.DataConclusao,
                    ComentarioPsicologo = t.ComentarioPsicologo,
                    PacienteId = t.PacienteId,
                    NomePaciente = t.Paciente!.Nome,
                    PsicologoId = t.PsicologoId,
                    NomePsicologo = t.Psicologo!.Nome
                })
                .ToListAsync();
        }

        public async Task<TarefaResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Tarefas
                .Include(t => t.Paciente)
                .Include(t => t.Psicologo)
                .Where(t => t.Id == id)
                .Select(t => new TarefaResponseDto
                {
                    Id = t.Id,
                    Descricao = t.Descricao,
                    Concluida = t.Concluida,
                    ObservacoesPaciente = t.ObservacoesPaciente,
                    DataCriacao = t.DataCriacao,
                    DataLimite = t.DataLimite,
                    DataConclusao = t.DataConclusao,
                    ComentarioPsicologo = t.ComentarioPsicologo,
                    PacienteId = t.PacienteId,
                    NomePaciente = t.Paciente!.Nome,
                    PsicologoId = t.PsicologoId,
                    NomePsicologo = t.Psicologo!.Nome
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AtualizarAsync(int id, TarefaUpdateDto dto)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return false;

            if (dto.Descricao != null) tarefa.Descricao = dto.Descricao;
            if (dto.Concluida != null) tarefa.Concluida = dto.Concluida.Value;
            if (dto.ObservacoesPaciente != null) tarefa.ObservacoesPaciente = dto.ObservacoesPaciente;
            if (dto.DataLimite != null) tarefa.DataLimite = dto.DataLimite;
            if (dto.DataConclusao != null) tarefa.DataConclusao = dto.DataConclusao;
            if (dto.ComentarioPsicologo != null) tarefa.ComentarioPsicologo = dto.ComentarioPsicologo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return false;

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
