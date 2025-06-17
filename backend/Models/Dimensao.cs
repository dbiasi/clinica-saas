namespace backend.Models
{
    public class Dimensao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<AvaliacaoDimensao> Avaliacoes { get; set; } = new();
    }
}
