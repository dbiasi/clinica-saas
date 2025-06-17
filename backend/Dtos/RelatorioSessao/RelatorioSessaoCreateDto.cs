using backend.Enums;

namespace backend.Dtos.RelatorioSessao
{
    public class RelatorioSessaoCreateDto
    {
        public Humor HumorPaciente { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        public string Transcricao { get; set; } = string.Empty;
        public string ResumoIA { get; set; } = string.Empty;
        public string HipotesesIA { get; set; } = string.Empty;
        public string TratamentoIA { get; set; } = string.Empty;
        public string LembretesIA { get; set; } = string.Empty;
        public List<int> IdsTarefas { get; set; } = new(); // IDs das tarefas associadas
    }
}
