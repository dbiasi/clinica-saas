using backend.Dtos.Cobranca;

namespace backend.Services.Interfaces
{
    public interface ICobrancaService
    {
        Task<int> CriarAsync(CobrancaCreateDto dto);
        Task<List<CobrancaResponseDto>> ListarPorPacienteAsync(int pacienteId);
        Task<CobrancaResponseDto?> BuscarPorIdAsync(int id);
    }
}
