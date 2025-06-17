using backend.Dtos.Paciente;

namespace backend.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<int> CriarPacienteAsync(PacienteCreateDto dto);
        Task<List<PacienteResponseDto>> ListarPacientesAsync();
        Task<PacienteResponseDto?> BuscarPorIdAsync(int id);
        Task<bool> AtualizarPacienteAsync(int id, PacienteUpdateDto dto);
        Task<bool> DesativarPacienteAsync(int id);
    }
}
