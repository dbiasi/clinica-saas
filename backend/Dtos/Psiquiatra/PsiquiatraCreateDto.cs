namespace backend.Dtos.Psiquiatra
{
    public class PsiquiatraCreateDto
    {
        public string Nome { get; set; } = string.Empty;          // Nome do psiquiatra
        public string Telefone { get; set; } = string.Empty;      // Telefone de contato
        public string Email { get; set; } = string.Empty;         // Email do psiquiatra
        public string CRM { get; set; } = string.Empty;           // CRM (registro profissional)
        public string Especialidade { get; set; } = string.Empty; // Especialidade do psiquiatra
    }
}