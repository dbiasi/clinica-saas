using backend.Dtos.Pagamento;

namespace backend.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<int> CriarAsync(PagamentoCreateDto dto);
        Task<List<PagamentoResponseDto>> ListarPorCobrancaAsync(int cobrancaId);
    }
}
