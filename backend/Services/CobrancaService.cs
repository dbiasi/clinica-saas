using backend.Data;
using backend.Dtos.Cobranca;
using backend.Dtos.Pagamento;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CobrancaService : ICobrancaService
    {
        private readonly ClinicaContext _context;

        public CobrancaService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(CobrancaCreateDto dto)
        {
            var cobranca = new Cobranca
            {
                PsicologoId = dto.PsicologoId,
                PacienteId = dto.PacienteId,
                Tipo = dto.Tipo,
                PrePago = dto.PrePago,
                QuantidadeSessoes = dto.QuantidadeSessoes,
                Valor = dto.Valor,
                Ativa = true
            };

            _context.Cobrancas.Add(cobranca);
            await _context.SaveChangesAsync();

            return cobranca.Id;
        }

        public async Task<List<CobrancaResponseDto>> ListarPorPacienteAsync(int pacienteId)
        {
            return await _context.Cobrancas
                .Include(c => c.Paciente)
                .Include(c => c.Psicologo)
                .Include(c => c.Pagamentos)
                .Where(c => c.PacienteId == pacienteId)
                .Select(c => new CobrancaResponseDto
                {
                    Id = c.Id,
                    PsicologoId = c.PsicologoId,
                    NomePsicologo = c.Psicologo.Nome,
                    PacienteId = c.PacienteId,
                    NomePaciente = c.Paciente.Nome,
                    Tipo = c.Tipo,
                    PrePago = c.PrePago,
                    QuantidadeSessoes = c.QuantidadeSessoes,
                    Valor = c.Valor,
                    Ativa = c.Ativa,
                    Pagamentos = c.Pagamentos.Select(p => new PagamentoResponseDto
                    {
                        Id = p.Id,
                        CobrancaId = p.CobrancaId,
                        DataPagamento = p.Data,
                        Valor = p.ValorPago,
                        Forma = p.Forma,
                        Observacao = p.Observacao
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<CobrancaResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Cobrancas
                .Include(c => c.Paciente)
                .Include(c => c.Psicologo)
                .Include(c => c.Pagamentos)
                .Where(c => c.Id == id)
                .Select(c => new CobrancaResponseDto
                {
                    Id = c.Id,
                    PsicologoId = c.PsicologoId,
                    NomePsicologo = c.Psicologo.Nome,
                    PacienteId = c.PacienteId,
                    NomePaciente = c.Paciente.Nome,
                    Tipo = c.Tipo,
                    PrePago = c.PrePago,
                    QuantidadeSessoes = c.QuantidadeSessoes,
                    Valor = c.Valor,
                    Ativa = c.Ativa,
                    Pagamentos = c.Pagamentos.Select(p => new PagamentoResponseDto
                    {
                        Id = p.Id,
                        CobrancaId = p.CobrancaId,
                        DataPagamento = p.Data,
                        Valor = p.ValorPago,
                        Forma = p.Forma,
                        Observacao = p.Observacao
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
