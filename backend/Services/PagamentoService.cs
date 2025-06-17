using backend.Data;
using backend.Dtos.Pagamento;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly ClinicaContext _context;

        public PagamentoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(PagamentoCreateDto dto)
        {
            var pagamento = new Pagamento
            {
                CobrancaId = dto.CobrancaId,
                Data = dto.DataPagamento,
                ValorPago = dto.Valor,
                Forma = dto.Forma,
                Observacao = dto.Observacao,
                Status = Enums.PagamentoStatus.Pago
            };

            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();

            return pagamento.Id;
        }

        public async Task<List<PagamentoResponseDto>> ListarPorCobrancaAsync(int cobrancaId)
        {
            return await _context.Pagamentos
                .Where(p => p.CobrancaId == cobrancaId)
                .OrderBy(p => p.Data)
                .Select(p => new PagamentoResponseDto
                {
                    Id = p.Id,
                    CobrancaId = p.CobrancaId,
                    DataPagamento = p.Data,
                    Valor = p.ValorPago,
                    Forma = p.Forma,
                    Observacao = p.Observacao
                })
                .ToListAsync();
        }
    }
}
