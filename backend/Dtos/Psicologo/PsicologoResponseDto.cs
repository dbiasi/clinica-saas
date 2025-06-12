namespace backend.Dtos.Psicologo
{
    public class PsicologoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string CRP { get; set; } = string.Empty;
        public string? DadosBancarios { get; set; }
        public string? DisponibilidadeAgenda { get; set; }

        public List<LocalAtendimentoResponseDto> LocaisAtendimento { get; set; } = new();
    }
}
