using backend.Enums;

namespace backend.Dtos.Cobranca
{
    public class CobrancaCreateDto
    {
        public int PsicologoId { get; set; }
        public int PacienteId { get; set; }

        public CobrancaTipo Tipo { get; set; } // PorSessao, PorQuantidadeSessoes, Mensal

        public int? QuantidadeSessoes { get; set; } // Obrigatório se Tipo = PorQuantidadeSessoes

        public bool PrePago { get; set; } = true;

        public decimal Valor { get; set; }
    }
}
