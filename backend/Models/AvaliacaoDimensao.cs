namespace backend.Models
{
    public class AvaliacaoDimensao
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;

        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; } = null!;

        public int DimensaoId { get; set; }
        public Dimensao Dimensao { get; set; } = null!;

        public int Nota { get; set; } // Ex: 0 a 10
        public DateTime Data { get; set; } = DateTime.Now;

        public string? Observacao { get; set; }
    }
}
