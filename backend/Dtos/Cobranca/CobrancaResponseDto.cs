using backend.Enums;
using backend.Dtos.Pagamento;

namespace backend.Dtos.Cobranca
{
    public class CobrancaResponseDto
    {
        public int Id { get; set; }

        public int PsicologoId { get; set; }
        public string NomePsicologo { get; set; } = string.Empty;

        public int PacienteId { get; set; }
        public string NomePaciente { get; set; } = string.Empty;

        public CobrancaTipo Tipo { get; set; }
        public int? QuantidadeSessoes { get; set; }

        public bool PrePago { get; set; }
        public decimal Valor { get; set; }
        public bool Ativa { get; set; }

        public List<PagamentoResponseDto> Pagamentos { get; set; } = new();
    }
}
