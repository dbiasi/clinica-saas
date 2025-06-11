using backend.Dtos.Medicamento;

namespace backend.Services.Interfaces
{
    public interface IMedicamentoService
    {
        Task<int> CriarAsync(MedicamentoCreateDto dto); // Retorna o ID criado
        Task<MedicamentoResponseDto?> BuscarPorIdAsync(int id);
        Task<List<MedicamentoResponseDto>> ListarTodosAsync();
    }
}
