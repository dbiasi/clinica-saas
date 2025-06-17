namespace backend.Models;
public class Psicologo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    // Conselho Regional de Psicologia
    public string CRP { get; set; } = string.Empty;

    // Dados bancários encapsulados
    public string? DadosBancarios { get; set; }

    // JSON ou string estruturada para disponibilidade
    public string? DisponibilidadeAgenda { get; set; }

    // Relacionamentos
    public List<LocalAtendimento> LocaisAtendimento { get; set; } = new();
    public List<Paciente> Pacientes { get; set; } = new();
    public List<Tarefa> Tarefas { get; set; } = new();
    public List<Sessao> Consultas { get; set; } = new();
}
