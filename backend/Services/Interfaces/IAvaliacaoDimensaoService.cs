using backend.Dtos.Dimensao;

namespace backend.Services.Interfaces
{
    public interface IAvaliacaoDimensaoService
    {
        Task<int> CriarAsync(AvaliacaoDimensaoCreateDto dto);
        Task<List<AvaliacaoDimensaoResponseDto>> ListarPorPacienteAsync(int pacienteId);
        Task<List<AvaliacaoDimensaoResponseDto>> ListarPorDimensaoAsync(int pacienteId, int dimensaoId);
    }
}
