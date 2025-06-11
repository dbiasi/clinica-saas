using backend.Data;
using backend.Dtos.Psicologo;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PsicologoService : IPsicologoService
    {
        private readonly ClinicaContext _context;

        public PsicologoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<PsicologoResponseDto> CriarAsync(PsicologoCreateDto dto)
        {
            var psicologo = new Psicologo
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                CRP = dto.CRP,
                DadosBancarios = dto.DadosBancarios,
                DisponibilidadeAgenda = dto.DisponibilidadeAgenda,
                LocaisAtendimento = dto.LocaisAtendimento
                    .Select(endereco => new LocalAtendimento { Endereco = endereco })
                    .ToList()
            };

            _context.Psicologos.Add(psicologo);
            await _context.SaveChangesAsync();

            return await BuscarPorIdAsync(psicologo.Id)
                ?? throw new Exception("Erro ao criar psicóloga.");
        }

        public async Task<List<PsicologoResponseDto>> BuscarTodasAsync()
        {
            return await _context.Psicologos
                .Include(p => p.LocaisAtendimento)
                .Select(p => new PsicologoResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Telefone = p.Telefone,
                    CRP = p.CRP,
                    DadosBancarios = p.DadosBancarios,
                    DisponibilidadeAgenda = p.DisponibilidadeAgenda,
                    LocaisAtendimento = p.LocaisAtendimento
                        .Select(l => l.Endereco)
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<PsicologoResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Psicologos
                .Include(p => p.LocaisAtendimento)
                .Where(p => p.Id == id)
                .Select(p => new PsicologoResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Telefone = p.Telefone,
                    CRP = p.CRP,
                    DadosBancarios = p.DadosBancarios,
                    DisponibilidadeAgenda = p.DisponibilidadeAgenda,
                    LocaisAtendimento = p.LocaisAtendimento
                        .Select(l => l.Endereco)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AtualizarAsync(int id, PsicologoUpdateDto dto)
        {
            var psicologo = await _context.Psicologos
                .Include(p => p.LocaisAtendimento)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (psicologo == null) return false;

            if (dto.Nome != null) psicologo.Nome = dto.Nome;
            if (dto.Telefone != null) psicologo.Telefone = dto.Telefone;
            if (dto.CRP != null) psicologo.CRP = dto.CRP;
            if (dto.DadosBancarios != null) psicologo.DadosBancarios = dto.DadosBancarios;
            if (dto.DisponibilidadeAgenda != null) psicologo.DisponibilidadeAgenda = dto.DisponibilidadeAgenda;

            if (dto.LocaisAtendimento != null)
            {
                psicologo.LocaisAtendimento.Clear();
                foreach (var endereco in dto.LocaisAtendimento)
                {
                    psicologo.LocaisAtendimento.Add(new LocalAtendimento { Endereco = endereco });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var psicologo = await _context.Psicologos.FindAsync(id);
            if (psicologo == null) return false;

            _context.Psicologos.Remove(psicologo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
