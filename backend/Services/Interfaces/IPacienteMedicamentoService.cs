using backend.Dtos.PacienteMedicamento;

namespace backend.Services.Interfaces
{
    public interface IPacienteMedicamentoService
    {
        Task<int> CriarAsync(PacienteMedicamentoCreateDto dto); // Retorna o ID criado
        Task<PacienteMedicamentoResponseDto?> BuscarPorIdAsync(int id);
        Task<List<PacienteMedicamentoResponseDto>> ListarPorPacienteAsync(int pacienteId);
    }
}
