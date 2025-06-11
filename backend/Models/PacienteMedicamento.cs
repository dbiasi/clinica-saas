namespace backend.Models
{
    public class PacienteMedicamento
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public int MedicamentoId { get; set; }
        public Medicamento? Medicamento { get; set; }

        public string Dosagem { get; set; } = string.Empty; // Ex: "2mg"
        public string FormaFarmaceutica { get; set; } = string.Empty; // Ex: "comprimido"

        public string FrequenciaUso { get; set; } = string.Empty; // Ex: "1x ao dia"
        public string ViaAdministracao { get; set; } = string.Empty; // Ex: oral

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public bool UsoContinuo { get; set; }

        public string? Prescritor { get; set; }
        public string? Observacoes { get; set; }
    }
}