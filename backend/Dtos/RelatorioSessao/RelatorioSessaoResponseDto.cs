using backend.Enums;
using backend.Dtos.Tarefa;

namespace backend.Dtos.RelatorioSessao
{
    public class RelatorioSessaoResponseDto
    {
        public int Id { get; set; }

        public int SessaoId { get; set; }

        public Humor HumorPaciente { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        public string Transcricao { get; set; } = string.Empty;
        public string ResumoIA { get; set; } = string.Empty;
        public string HipotesesIA { get; set; } = string.Empty;
        public string TratamentoIA { get; set; } = string.Empty;
        public string LembretesIA { get; set; } = string.Empty;

        // Lista de tarefas vinculadas (resumidas no DTO)
        public List<TarefaResponseDto> Tarefas { get; set; } = new();
    }
}
