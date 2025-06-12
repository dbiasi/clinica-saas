namespace backend.Dtos.Psicologo
{
    public class PsicologoUpdateDto
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? CRP { get; set; }
        public string? DadosBancarios { get; set; }
        public string? DisponibilidadeAgenda { get; set; }

        public List<LocalAtendimentoCreateDto>? LocaisAtendimento { get; set; } = new();
    }
}
