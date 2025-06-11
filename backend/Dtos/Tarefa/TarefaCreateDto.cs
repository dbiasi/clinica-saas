namespace backend.Dtos.Tarefa
{
    public class TarefaCreateDto
    {
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataLimite { get; set; }

        public int PacienteId { get; set; }
        public int PsicologoId { get; set; }
    }
}
