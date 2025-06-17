using backend.Enums;

namespace backend.Models
{
    public class Sessao
    {
        public int Id { get; set; }

        // Relacionamento com o paciente
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // Relacionamento com o psicólogo
        public int PsicologoId { get; set; }
        public Psicologo? Psicologo { get; set; }

        // Relacionamento com o local de atendimento (usado se for presencial)
        public int? LocalAtendimentoId { get; set; }
        public LocalAtendimento? LocalAtendimento { get; set; }

        public DateTime DataHora { get; set; }

        public string? LinkReuniao { get; set; } // Usado se for uma sessão online (ex: Google Meet)

        public SessaoTipo TipoAtendimento { get; set; } // Enum indicando se é presencial ou online
        public SessaoStatus Status { get; set; } // Enum indicando o status da sessão (Agendada, Realizada, Cancelada, etc.)

        // Valores financeiros
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Pago { get; set; }

        public int DuracaoMin { get; set; }

        public string? Observacao { get; set; }

        // Relacionamentos
        public List<Arquivo> Arquivos { get; set; } = new();
        public RelatorioSessao? Relatorio { get; set; }

        // ✅ Construtor com valores padrão
        public Sessao()
        {
            Status = SessaoStatus.Agendada;
            TipoAtendimento = SessaoTipo.Online;
            Valor = 0;
            Desconto = 0;
            DuracaoMin = 50;
            Pago = false;
        }
    }
}