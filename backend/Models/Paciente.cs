namespace backend.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Endereco { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool MoraSozinho { get; set; }
        public string? ContatoEmergencia { get; set; }
        public string? PlanoSaude { get; set; }
        public string? Diario { get; set; }
        public bool Ativo { get; set; } = true;

        // Relacionamento
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
        public List<PacienteMedicamento> MedicamentosUsados { get; set; } = new(); // 🔁 Lista de medicamentos que ele usa
        // public List<Arquivo> Anexos { get; set; } = new();
        public int? ResponsavelLegalId { get; set; }
        public ResponsavelLegal? ResponsavelLegal { get; set; }
        public int? PsiquiatraId { get; set; }
        public Psiquiatra? DadosPsiquiatra { get; set; }
    }
}
