// Dtos/PacienteMedicamento/PacienteMedicamentoResponseDto.cs
namespace backend.Dtos.PacienteMedicamento
{
    public class PacienteMedicamentoResponseDto
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public string NomePaciente { get; set; } = string.Empty;

        public int MedicamentoId { get; set; }
        public string NomeMedicamento { get; set; } = string.Empty;

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
