using backend.Enums;

namespace backend.Dtos.Sessao
{
    public class SessaoCreateDto
    {
        public int PacienteId { get; set; }
        public int PsicologoId { get; set; }
        public int? LocalAtendimentoId { get; set; }

        public DateTime DataHora { get; set; }
        public string? LinkReuniao { get; set; }
        public SessaoTipo TipoAtendimento { get; set; }

        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Pago { get; set; }

        public int DuracaoMin { get; set; }

        public string? Observacao { get; set; }
    }
}
