namespace backend.Dtos.Consulta
{
    public class ConsultaUpdateDto
    {
        public DateTime DataHora { get; set; }
        public string Status { get; set; } = "Agendada";
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
    }
}
