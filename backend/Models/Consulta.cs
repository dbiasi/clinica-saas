namespace backend.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public int PacienteId { get; set; } // Foreign Key
        public Paciente? Paciente { get; set; } // Navigation property (posso fazer JOIN com Paciente usando EF Core)

        public DateTime DataHora { get; set; }
        public string Status { get; set; } = "Agendada"; // Agendada, Realizada, Cancelada
        public decimal Valor { get; set; }
        public string? Observacao { get; set; }
    }
}