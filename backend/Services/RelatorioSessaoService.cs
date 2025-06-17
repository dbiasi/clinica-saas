using backend.Data;
using backend.Dtos.RelatorioSessao;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class RelatorioSessaoService : IRelatorioSessaoService
    {
        private readonly ClinicaContext _context;

        public RelatorioSessaoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<RelatorioSessaoResponseDto> CriarOuAtualizarAsync(int sessaoId, RelatorioSessaoCreateDto dto)
        {
            var existente = await _context.RelatoriosSessoes
                .Include(r => r.Tarefas)
                .FirstOrDefaultAsync(r => r.SessaoId == sessaoId);

            var tarefas = await _context.Tarefas
                .Where(t => dto.IdsTarefas.Contains(t.Id))
                .ToListAsync();

            if (existente != null)
            {
                // Atualiza
                existente.HumorPaciente = dto.HumorPaciente;
                existente.Observacoes = dto.Observacoes;
                existente.Transcricao = dto.Transcricao;
                existente.ResumoIA = dto.ResumoIA;
                existente.HipotesesIA = dto.HipotesesIA;
                existente.TratamentoIA = dto.TratamentoIA;
                existente.LembretesIA = dto.LembretesIA;
                existente.Tarefas = tarefas;

                await _context.SaveChangesAsync();
                return await BuscarPorSessaoIdAsync(sessaoId) ?? throw new Exception("Erro ao atualizar relatório");
            }

            // Cria novo
            var relatorio = new RelatorioSessao
            {
                SessaoId = sessaoId,
                HumorPaciente = dto.HumorPaciente,
                Observacoes = dto.Observacoes,
                Transcricao = dto.Transcricao,
                ResumoIA = dto.ResumoIA,
                HipotesesIA = dto.HipotesesIA,
                TratamentoIA = dto.TratamentoIA,
                LembretesIA = dto.LembretesIA,
                Tarefas = tarefas
            };

            _context.RelatoriosSessoes.Add(relatorio);
            await _context.SaveChangesAsync();

            return await BuscarPorSessaoIdAsync(sessaoId) ?? throw new Exception("Erro ao criar relatório");
        }

        public async Task<RelatorioSessaoResponseDto?> BuscarPorSessaoIdAsync(int sessaoId)
        {
            return await _context.RelatoriosSessoes
                .Include(r => r.Tarefas)
                .ThenInclude(t => t.Paciente)
                .Include(r => r.Tarefas)
                .ThenInclude(t => t.Psicologo)
                .Where(r => r.SessaoId == sessaoId)
                .Select(r => new RelatorioSessaoResponseDto
                {
                    Id = r.Id,
                    SessaoId = r.SessaoId,
                    HumorPaciente = r.HumorPaciente,
                    Observacoes = r.Observacoes,
                    Transcricao = r.Transcricao,
                    ResumoIA = r.ResumoIA,
                    HipotesesIA = r.HipotesesIA,
                    TratamentoIA = r.TratamentoIA,
                    LembretesIA = r.LembretesIA,
                    Tarefas = r.Tarefas.Select(t => new Dtos.Tarefa.TarefaResponseDto
                    {
                        Id = t.Id,
                        Descricao = t.Descricao,
                        Concluida = t.Concluida,
                        PacienteId = t.PacienteId,
                        PsicologoId = t.PsicologoId,
                        DataCriacao = t.DataCriacao,
                        DataLimite = t.DataLimite,
                        DataConclusao = t.DataConclusao,
                        ComentarioPsicologo = t.ComentarioPsicologo,
                        ObservacoesPaciente = t.ObservacoesPaciente,
                        NomePaciente = t.Paciente.Nome ?? "Desconhecido",
                        NomePsicologo = t.Psicologo.Nome ?? "Desconhecido"
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AtualizarAsync(int id, RelatorioSessaoUpdateDto dto)
        {
            var relatorio = await _context.RelatoriosSessoes
                .Include(r => r.Tarefas)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (relatorio == null)
                return false;

            relatorio.HumorPaciente = dto.HumorPaciente;
            relatorio.Observacoes = dto.Observacoes;
            relatorio.Transcricao = dto.Transcricao;
            relatorio.ResumoIA = dto.ResumoIA;
            relatorio.HipotesesIA = dto.HipotesesIA;
            relatorio.TratamentoIA = dto.TratamentoIA;
            relatorio.LembretesIA = dto.LembretesIA;

            var tarefas = await _context.Tarefas
                .Where(t => dto.IdsTarefas.Contains(t.Id))
                .ToListAsync();

            relatorio.Tarefas = tarefas;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
