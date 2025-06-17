namespace backend.Dtos.Dimensao
{
    public class AvaliacaoDimensaoResponseDto
    {
        public int Id { get; set; }
        public int DimensaoId { get; set; }
        public string NomeDimensao { get; set; } = string.Empty;

        public int SessaoId { get; set; }
        public DateTime Data { get; set; }

        public int Nota { get; set; }
        public string? Observacao { get; set; }
    }
}
