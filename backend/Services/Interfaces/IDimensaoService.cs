using backend.Dtos.Dimensao;

namespace backend.Services.Interfaces
{
    public interface IDimensaoService
    {
        Task<int> CriarAsync(DimensaoCreateDto dto);
        Task<List<DimensaoResponseDto>> ListarAsync();
    }
}
