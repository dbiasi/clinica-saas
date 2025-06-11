using backend.Dtos.Medicamento;
using backend.Models;
using backend.Services.Interfaces;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly ClinicaContext _context;

        public MedicamentoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(MedicamentoCreateDto dto)
        {
            var medicamento = new Medicamento
            {
                Nome = dto.Nome
            };

            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();

            return medicamento.Id;
        }

        public async Task<MedicamentoResponseDto?> BuscarPorIdAsync(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);

            if (medicamento == null) return null;

            return new MedicamentoResponseDto
            {
                Id = medicamento.Id,
                Nome = medicamento.Nome
            };
        }

        public async Task<List<MedicamentoResponseDto>> ListarTodosAsync()
        {
            return await _context.Medicamentos
                .Select(m => new MedicamentoResponseDto
                {
                    Id = m.Id,
                    Nome = m.Nome
                })
                .ToListAsync();
        }
    }
}
