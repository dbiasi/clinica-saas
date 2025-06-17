using backend.Enums;

namespace backend.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        public int CobrancaId { get; set; }
        public Cobranca Cobranca { get; set; } = null!;

        public DateTime Data { get; set; }

        public decimal ValorPago { get; set; }

        public PagamentoForma Forma { get; set; }

        public PagamentoStatus Status { get; set; } = PagamentoStatus.Pendente;

        public string? Observacao { get; set; }
    }
}