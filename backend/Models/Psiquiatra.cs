namespace backend.Models
{
    public class Psiquiatra
    {
        public int Id { get; set; } // Chave primária. O EF Core irá gerar automaticamente como identidade.

        public string Nome { get; set; } = string.Empty;      // Nome do psiquiatra
        public string Telefone { get; set; } = string.Empty;  // Telefone de contato
        public string Email { get; set; } = string.Empty;     // Email do psiquiatra
        public string CRM { get; set; } = string.Empty;       // CRM (registro profissional)
        public string Especialidade { get; set; } = string.Empty;// Especialidade do psiquiatra

        // Relacionamento 1:N - Um psiquiatra pode estar vinculado a vários pacientes
        public List<Paciente> Pacientes { get; set; } = new(); // Propriedade de navegação
    }
}