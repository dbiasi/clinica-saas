namespace backend.Dtos.Tarefa
{
    public class TarefaResponseDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Concluida { get; set; }
        public string? ObservacoesPaciente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataLimite { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string? ComentarioPsicologo { get; set; }

        public int PacienteId { get; set; }
        public string? NomePaciente { get; set; }

        public int PsicologoId { get; set; }
        public string? NomePsicologo { get; set; }
    }
}
