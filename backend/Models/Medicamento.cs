namespace backend.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Ex: Clonazepam
        

        // 🔁 Propriedade de navegação (opcional)
        public List<PacienteMedicamento> PacientesMedicamentos { get; set; } = new(); // Lista de pacientes que usam este medicamento
    }
}