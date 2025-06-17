using backend.Dtos.RelatorioSessao;

namespace backend.Services.Interfaces
{
    public interface IRelatorioSessaoService
    {
        Task<RelatorioSessaoResponseDto> CriarOuAtualizarAsync(int sessaoId, RelatorioSessaoCreateDto dto);
        Task<RelatorioSessaoResponseDto?> BuscarPorSessaoIdAsync(int sessaoId);
        Task<bool> AtualizarAsync(int id, RelatorioSessaoUpdateDto dto);
    }
}
