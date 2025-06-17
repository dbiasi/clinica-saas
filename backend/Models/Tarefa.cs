namespace backend.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = string.Empty;   // Descrição da tarefa (ex: "Escrever diário da semana")

        public bool Concluida { get; set; } // Se a tarefa foi concluída pelo paciente

        public string? ObservacoesPaciente { get; set; }    // Observações feitas pelo paciente após concluir a tarefa (ex: "Me senti melhor")

        public DateTime DataCriacao { get; set; } = DateTime.Now;   // Data que a tarefa foi atribuída

        public DateTime? DataLimite { get; set; }   // Data prevista para conclusão (definida pelo psicólogo)

        public DateTime? DataConclusao { get; set; }    // Data real de conclusão (preenchida quando o paciente conclui)

        public string? ComentarioPsicologo { get; set; }    // Campo opcional para psicólogo fazer anotações sobre a tarefa depois da entrega

        // Relação com o paciente
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // Psicólogo que criou a tarefa (caso o sistema permita múltiplos psicólogos)
        public int PsicologoId { get; set; }
        public Psicologo? Psicologo { get; set; }
    }

}
