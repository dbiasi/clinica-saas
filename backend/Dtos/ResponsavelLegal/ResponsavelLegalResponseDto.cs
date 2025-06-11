namespace backend.Dtos.ResponsavelLegal
{
    public class ResponsavelLegalResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Parentesco { get; set; } = string.Empty;
    }
}
