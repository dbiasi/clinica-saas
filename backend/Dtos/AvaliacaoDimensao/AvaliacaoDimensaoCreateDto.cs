namespace backend.Dtos.Dimensao
{
    public class AvaliacaoDimensaoCreateDto
    {
        public int PacienteId { get; set; }
        public int SessaoId { get; set; }
        public int DimensaoId { get; set; }
        public int Nota { get; set; } // Ex: 0 a 10
        public string? Observacao { get; set; }
    }
}
