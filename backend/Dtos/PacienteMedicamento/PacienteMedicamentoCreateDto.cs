// Dtos/PacienteMedicamento/PacienteMedicamentoCreateDto.cs
namespace backend.Dtos.PacienteMedicamento
{
    public class PacienteMedicamentoCreateDto
    {
        public int PacienteId { get; set; }
        public int MedicamentoId { get; set; }

        public string Dosagem { get; set; } = string.Empty;
        public string FormaFarmaceutica { get; set; } = string.Empty;
        public string FrequenciaUso { get; set; } = string.Empty;
        public string ViaAdministracao { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public bool UsoContinuo { get; set; }

        public string? Prescritor { get; set; }
        public string? Observacoes { get; set; }
    }
}
