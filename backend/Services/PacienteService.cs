using backend.Models;
using backend.Dtos.Paciente;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Services.Interfaces;


namespace backend.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ClinicaContext _context;

        public PacienteService(ClinicaContext context)
        {
            _context = context;
        }

        // 1. Criar novo paciente
        public async Task<int> CriarPacienteAsync(PacienteCreateDto dto)
        {
            var paciente = new Paciente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                DataNascimento = dto.DataNascimento,
                Ativo = true
            };

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente.Id;
        }

        // 2. Listar todos os pacientes
        public async Task<List<PacienteResponseDto>> ListarPacientesAsync()
        {
            return await _context.Pacientes
                .Where(p => p.Ativo)
                .OrderBy(p => p.Nome)
                .Select(p => new PacienteResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Email = p.Email,
                    Telefone = p.Telefone,
                    DataNascimento = p.DataNascimento,
                    Ativo = p.Ativo
                })
                .ToListAsync();
        }

        // 3. Buscar por ID
        public async Task<PacienteResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Pacientes
                .Where(p => p.Id == id)
                .Select(p => new PacienteResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Email = p.Email,
                    Telefone = p.Telefone,
                    DataNascimento = p.DataNascimento,
                    Ativo = p.Ativo
                })
                .FirstOrDefaultAsync();
        }

        // 4. Atualizar dados do paciente
        public async Task<bool> AtualizarPacienteAsync(int id, PacienteUpdateDto dto)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                return false;

            paciente.Nome = dto.Nome;
            paciente.Email = dto.Email;
            paciente.Telefone = dto.Telefone;
            paciente.DataNascimento = dto.DataNascimento;
            paciente.Ativo = dto.Ativo;

            await _context.SaveChangesAsync();
            return true;
        }

        // 5. Desativar paciente
        public async Task<bool> DesativarPacienteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                return false;

            paciente.Ativo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
