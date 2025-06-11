using backend.Dtos.Tarefa;

namespace backend.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaResponseDto> CriarAsync(TarefaCreateDto dto);
        Task<List<TarefaResponseDto>> BuscarPorPacienteAsync(int pacienteId);
        Task<TarefaResponseDto?> BuscarPorIdAsync(int id);
        Task<bool> AtualizarAsync(int id, TarefaUpdateDto dto);
        Task<bool> DeletarAsync(int id);
    }
}
