namespace backend.Models;
public class Tarefa
{
    public int Id { get; set; }

    // Descrição da tarefa (ex: "Escrever diário da semana")
    public string Descricao { get; set; } = string.Empty;

    // Se a tarefa foi concluída pelo paciente
    public bool Concluida { get; set; }

    // Observações feitas pelo paciente após concluir a tarefa (ex: "Me senti melhor")
    public string? ObservacoesPaciente { get; set; }

    // Data que a tarefa foi atribuída
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    // Data prevista para conclusão (definida pelo psicólogo)
    public DateTime? DataLimite { get; set; }

    // Data real de conclusão (preenchida quando o paciente conclui)
    public DateTime? DataConclusao { get; set; }

    // Campo opcional para psicólogo fazer anotações sobre a tarefa depois da entrega
    public string? ComentarioPsicologo { get; set; }

    // Relação com o paciente
    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    // Psicólogo que criou a tarefa (caso o sistema permita múltiplos psicólogos)
    public int PsicologoId { get; set; }
    public Psicologo? Psicologo { get; set; }
}
