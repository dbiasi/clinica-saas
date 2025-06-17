using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }

        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<LocalAtendimento> LocaisAtendimento { get; set; } = null!;
        public DbSet<Medicamento> Medicamentos { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade Medicamento nas migrations e no banco de dados
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteMedicamento> PacienteMedicamentos { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade PacienteMedicamento nas migrations e no banco de dados
        public DbSet<Psicologo> Psicologos { get; set; } = null!;
        public DbSet<Psiquiatra> Psiquiatras { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade Psiquiatra nas migrations e no banco de dados.
        public DbSet<RelatorioSessao> RelatoriosSessoes { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade RelatorioSessao nas migrations e no banco de dados
        public DbSet<ResponsavelLegal> ResponsaveisLegais { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade REsponsavelLegal nas migrations e no banco de dados
        public DbSet<Sessao> Sessoes { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade Sessoes nas migrations e no banco de dados
        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        public DbSet<Dimensao> Dimensoes { get; set; } = null!; // 👈 Estamos pedindo para o EF incluir a nova entidade Dimensao nas migrations e no banco de dados
        public DbSet<AvaliacaoDimensao> AvaliacoesDimensao { get; set; } = null!; // 👈 Estamos pedindo para o EF incluir a nova entidade AvaliacaoDimensao nas migrations e no banco de dados
        public DbSet<Cobranca> Cobrancas { get; set; } = null!; // 👈 Estamos pedindo para o EF incluir a nova entidade Cobranca nas migrations e no banco de dados
        public DbSet<Pagamento> Pagamentos { get; set; } = null!; // 👈 Estamos pedindo para o EF incluir a nova entidade Pagamento nas migrations e no banco de dados
    }
}
