namespace backend.Models
{
    public class Arquivo
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty; // Caminho ou link do arquivo
        public string Tipo { get; set; } = string.Empty; // Ex: "pdf", "imagem", "áudio"
        public bool VisivelParaPaciente { get; set; } = false; // Indica se o arquivo é público ou privado

        // Relacionamento com a Sessão
        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; } = null!;
    }
}
