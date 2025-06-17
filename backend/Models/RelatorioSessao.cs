using backend.Enums;

namespace backend.Models
{
    public class RelatorioSessao
    {
        public int Id { get; set; }

        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; } = null!;

        // Dados clínicos
        public Humor HumorPaciente { get; set; } // enum: Alegre, Triste, Ansioso etc.
        public string Observacoes { get; set; } = string.Empty;

        // Transcrição e conteúdo processado por IA
        public string Transcricao { get; set; } = string.Empty;
        public string ResumoIA { get; set; } = string.Empty;
        public string HipotesesIA { get; set; } = string.Empty;
        public string TratamentoIA { get; set; } = string.Empty;
        public string LembretesIA { get; set; } = string.Empty;

        // Relacionamento com tarefas associadas à sessão
        public List<Tarefa> Tarefas { get; set; } = new();
    }
}
