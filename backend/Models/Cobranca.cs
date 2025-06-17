using backend.Enums;

namespace backend.Models
{
    public class Cobranca
    {
        public int Id { get; set; }

        public int PsicologoId { get; set; }
        public Psicologo Psicologo { get; set; } = null!;

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;

        public CobrancaTipo Tipo { get; set; }

        public int? QuantidadeSessoes { get; set; } // Usado se for ACadaXSessoes

        public bool PrePago { get; set; } = true;

        public decimal Valor { get; set; }

        public bool Ativa { get; set; } = true;

        public List<Pagamento> Pagamentos { get; set; } = new();
    }
}
