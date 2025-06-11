namespace backend.Dtos.Consulta
{
    public class ConsultaResponseDto
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string NomePaciente { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public string Status { get; set; } = "Agendada";
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
    }
}
