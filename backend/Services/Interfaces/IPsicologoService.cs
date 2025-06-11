using backend.Dtos.Psicologo;

namespace backend.Services.Interfaces
{
    public interface IPsicologoService
    {
        Task<PsicologoResponseDto> CriarAsync(PsicologoCreateDto dto);
        Task<List<PsicologoResponseDto>> BuscarTodasAsync();
        Task<PsicologoResponseDto?> BuscarPorIdAsync(int id);
        Task<bool> AtualizarAsync(int id, PsicologoUpdateDto dto);
        Task<bool> DeletarAsync(int id);
    }
}
