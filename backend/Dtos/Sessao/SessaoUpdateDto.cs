using backend.Enums;

namespace backend.Dtos.Sessao
{
    public class SessaoUpdateDto
    {
        public DateTime DataHora { get; set; }
        public SessaoStatus Status { get; set; }

        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Pago { get; set; }

        public int DuracaoMin { get; set; }

        public string? Observacao { get; set; }

        public string? LinkReuniao { get; set; }
        public SessaoTipo TipoAtendimento { get; set; }

        public int? LocalAtendimentoId { get; set; }
    }
}
