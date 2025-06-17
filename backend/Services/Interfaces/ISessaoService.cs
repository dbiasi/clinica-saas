using backend.Dtos.Sessao;

namespace backend.Services.Interfaces
{
    public interface ISessaoService
    {
        Task<int> CriarSessaoAsync(SessaoCreateDto dto);
        Task<List<SessaoResponseDto>> ListarSessoesAsync();
        Task<SessaoResponseDto?> BuscarPorIdAsync(int id);
        Task<bool> AtualizarSessaoAsync(int id, SessaoUpdateDto dto);
    }
}
