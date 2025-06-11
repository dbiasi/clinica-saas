namespace backend.Dtos.Tarefa
{
    public class TarefaUpdateDto
    {
        public string? Descricao { get; set; }
        public bool? Concluida { get; set; }
        public string? ObservacoesPaciente { get; set; }
        public DateTime? DataLimite { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string? ComentarioPsicologo { get; set; }
    }
}
