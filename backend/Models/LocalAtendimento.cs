namespace backend.Models
{
    public class LocalAtendimento
    {
        public int Id { get; set; }

        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public string TipoEndereco { get; set; } = "Casa"; // "Casa", "Apartamento", etc.
        public string? NumeroApartamento { get; set; }
        public string? Andar { get; set; }

        public string? NomeRecepcionista { get; set; }
        public string? Complemento { get; set; }
        public bool PossuiEstacionamento { get; set; } = false;
        public string? Observacoes { get; set; }

        public int PsicologoId { get; set; }
        public Psicologo? Psicologo { get; set; }
    }
}
