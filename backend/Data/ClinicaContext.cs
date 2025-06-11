using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade Consulta nas migrations e no banco de dados
        public DbSet<ResponsavelLegal> ResponsaveisLegais { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade REsponsavelLegal nas migrations e no banco de dados
        public DbSet<Psiquiatra> Psiquiatras { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade Psiquiatra nas migrations e no banco de dados.
        public DbSet<Medicamento> Medicamentos { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade Medicamento nas migrations e no banco de dados
        public DbSet<PacienteMedicamento> PacienteMedicamentos { get; set; } // 👈 Estamos pedindo para o EF incluir a nova entidade PacienteMedicamento nas migrations e no banco de dados
        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        public DbSet<Psicologo> Psicologos { get; set; } = null!;
    }
}
