namespace backend.Dtos.Psicologo
{
    public class PsicologoCreateDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string CRP { get; set; } = string.Empty;
        public string? DadosBancarios { get; set; }
        public string? DisponibilidadeAgenda { get; set; }

        public List<string> LocaisAtendimento { get; set; } = new(); // Lista de endereços simples
    }
}
