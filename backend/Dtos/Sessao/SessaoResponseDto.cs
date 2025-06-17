using backend.Enums;

namespace backend.Dtos.Sessao
{
    public class SessaoResponseDto
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public string NomePaciente { get; set; } = string.Empty;

        public int PsicologoId { get; set; }
        public string NomePsicologo { get; set; } = string.Empty;

        public int? LocalAtendimentoId { get; set; }
        public string? NomeLocalAtendimento { get; set; }

        public DateTime DataHora { get; set; }
        public string? LinkReuniao { get; set; }

        public SessaoTipo TipoAtendimento { get; set; }
        public string Status { get; set; } = string.Empty;

        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Pago { get; set; }

        public int DuracaoMin { get; set; }

        public string? Observacao { get; set; }

        // opcional: incluir URLs de arquivos ou dados do relatório
    }
}
