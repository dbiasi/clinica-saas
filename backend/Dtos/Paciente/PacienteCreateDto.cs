namespace backend.Dtos.Paciente
{
    public class PacienteCreateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
