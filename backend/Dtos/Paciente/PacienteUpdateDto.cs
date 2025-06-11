namespace backend.Dtos.Paciente
{
    public class PacienteUpdateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
