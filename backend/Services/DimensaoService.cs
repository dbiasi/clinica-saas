using backend.Data;
using backend.Dtos.Dimensao;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class DimensaoService : IDimensaoService
    {
        private readonly ClinicaContext _context;

        public DimensaoService(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAsync(DimensaoCreateDto dto)
        {
            var dimensao = new Dimensao
            {
                Nome = dto.Nome
            };

            _context.Dimensoes.Add(dimensao);
            await _context.SaveChangesAsync();

            return dimensao.Id;
        }

        public async Task<List<DimensaoResponseDto>> ListarAsync()
        {
            return await _context.Dimensoes
                .OrderBy(d => d.Nome)
                .Select(d => new DimensaoResponseDto
                {
                    Id = d.Id,
                    Nome = d.Nome
                })
                .ToListAsync();
        }
    }
}
