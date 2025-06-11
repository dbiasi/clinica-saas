namespace backend.Dtos.Consulta
{
    public class ConsultaCreateDto
    {
        public int PacienteId { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
    }
}
