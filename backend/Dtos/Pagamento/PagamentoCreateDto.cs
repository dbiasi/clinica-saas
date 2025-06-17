using backend.Enums;

namespace backend.Dtos.Pagamento
{
    public class PagamentoCreateDto
    {
        public int CobrancaId { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public PagamentoForma Forma { get; set; }
        public string? Observacao { get; set; }
    }
}
