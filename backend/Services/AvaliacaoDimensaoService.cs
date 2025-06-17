using backend.Data;
using backend.Dtos.Dimensao;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AvaliacaoDimensaoService : IAvaliacaoDimensaoService
    {
        private readonly ClinicaContext _context;

        public AvaliacaoDimensaoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(AvaliacaoDimensaoCreateDto dto)
        {
            var avaliacao = new AvaliacaoDimensao
            {
                PacienteId = dto.PacienteId,
                SessaoId = dto.SessaoId,
                DimensaoId = dto.DimensaoId,
                Nota = dto.Nota,
                Observacao = dto.Observacao,
                Data = DateTime.Now
            };

            _context.AvaliacoesDimensao.Add(avaliacao);
            await _context.SaveChangesAsync();

            return avaliacao.Id;
        }

        public async Task<List<AvaliacaoDimensaoResponseDto>> ListarPorPacienteAsync(int pacienteId)
        {
            return await _context.AvaliacoesDimensao
                .Include(a => a.Dimensao)
                .Where(a => a.PacienteId == pacienteId)
                .OrderBy(a => a.Data)
                .Select(a => new AvaliacaoDimensaoResponseDto
                {
                    Id = a.Id,
                    DimensaoId = a.DimensaoId,
                    NomeDimensao = a.Dimensao.Nome,
                    SessaoId = a.SessaoId,
                    Data = a.Data,
                    Nota = a.Nota,
                    Observacao = a.Observacao
                })
                .ToListAsync();
        }

        public async Task<List<AvaliacaoDimensaoResponseDto>> ListarPorDimensaoAsync(int pacienteId, int dimensaoId)
        {
            return await _context.AvaliacoesDimensao
                .Include(a => a.Dimensao)
                .Where(a => a.PacienteId == pacienteId && a.DimensaoId == dimensaoId)
                .OrderBy(a => a.Data)
                .Select(a => new AvaliacaoDimensaoResponseDto
                {
                    Id = a.Id,
                    DimensaoId = a.DimensaoId,
                    NomeDimensao = a.Dimensao.Nome,
                    SessaoId = a.SessaoId,
                    Data = a.Data,
                    Nota = a.Nota,
                    Observacao = a.Observacao
                })
                .ToListAsync();
        }
    }
}
