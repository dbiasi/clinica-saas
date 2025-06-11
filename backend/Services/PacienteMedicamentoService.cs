using backend.Dtos.PacienteMedicamento;
using backend.Models;
using backend.Services.Interfaces;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PacienteMedicamentoService : IPacienteMedicamentoService
    {
        private readonly ClinicaContext _context;

        public PacienteMedicamentoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(PacienteMedicamentoCreateDto dto)
        {
            var registro = new PacienteMedicamento
            {
                PacienteId = dto.PacienteId,
                MedicamentoId = dto.MedicamentoId,
                Dosagem = dto.Dosagem,
                FormaFarmaceutica = dto.FormaFarmaceutica,
                FrequenciaUso = dto.FrequenciaUso,
                ViaAdministracao = dto.ViaAdministracao,
                DataInicio = dto.DataInicio,
                DataFim = dto.DataFim,
                UsoContinuo = dto.UsoContinuo,
                Prescritor = dto.Prescritor,
                Observacoes = dto.Observacoes
            };

            _context.PacienteMedicamentos.Add(registro);
            await _context.SaveChangesAsync();

            return registro.Id;
        }

        public async Task<PacienteMedicamentoResponseDto?> BuscarPorIdAsync(int id)
        {
            var registro = await _context.PacienteMedicamentos
                .Include(pm => pm.Paciente)
                .Include(pm => pm.Medicamento)
                .FirstOrDefaultAsync(pm => pm.Id == id);

            if (registro == null) return null;

            return new PacienteMedicamentoResponseDto
            {
                Id = registro.Id,
                PacienteId = registro.PacienteId,
                NomePaciente = registro.Paciente?.Nome ?? "",
                MedicamentoId = registro.MedicamentoId,
                NomeMedicamento = registro.Medicamento?.Nome ?? "",
                Dosagem = registro.Dosagem,
                FormaFarmaceutica = registro.FormaFarmaceutica,
                FrequenciaUso = registro.FrequenciaUso,
                ViaAdministracao = registro.ViaAdministracao,
                DataInicio = registro.DataInicio,
                DataFim = registro.DataFim,
                UsoContinuo = registro.UsoContinuo,
                Prescritor = registro.Prescritor,
                Observacoes = registro.Observacoes
            };
        }

        public async Task<List<PacienteMedicamentoResponseDto>> ListarPorPacienteAsync(int pacienteId)
        {
            return await _context.PacienteMedicamentos
                .Where(pm => pm.PacienteId == pacienteId)
                .Include(pm => pm.Medicamento)
                .Include(pm => pm.Paciente)
                .Select(pm => new PacienteMedicamentoResponseDto
                {
                    Id = pm.Id,
                    PacienteId = pm.PacienteId,
                    NomePaciente = pm.Paciente!.Nome,
                    MedicamentoId = pm.MedicamentoId,
                    NomeMedicamento = pm.Medicamento!.Nome,
                    Dosagem = pm.Dosagem,
                    FormaFarmaceutica = pm.FormaFarmaceutica,
                    FrequenciaUso = pm.FrequenciaUso,
                    ViaAdministracao = pm.ViaAdministracao,
                    DataInicio = pm.DataInicio,
                    DataFim = pm.DataFim,
                    UsoContinuo = pm.UsoContinuo,
                    Prescritor = pm.Prescritor,
                    Observacoes = pm.Observacoes
                })
                .ToListAsync();
        }
    }
}
