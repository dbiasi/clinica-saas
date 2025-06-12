using backend.Data;
using backend.Dtos.Psicologo;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PsicologoService : IPsicologoService
    {
        private readonly ClinicaContext _context;

        public PsicologoService(ClinicaContext context)
        {
            _context = context;
        }

        /*
        Esse endpoint é responsável por criar um novo psicólogo.
        Ele recebe um DTO com os dados necessários, cria uma instância do modelo Psicologo,
        adiciona ao contexto e salva as alterações no banco de dados.
        Retorna um DTO com os dados do psicólogo criado ou lança uma exceção em caso de erro.
        */

        public async Task<PsicologoResponseDto> CriarAsync(PsicologoCreateDto dto)
        {
            var psicologo = new Psicologo
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                CRP = dto.CRP,
                DadosBancarios = dto.DadosBancarios,
                DisponibilidadeAgenda = dto.DisponibilidadeAgenda,
                LocaisAtendimento = dto.LocaisAtendimento
                    .Select(l => new LocalAtendimento
                    {
                        Cep = l.Cep,
                        Logradouro = l.Logradouro,
                        Numero = l.Numero,
                        Bairro = l.Bairro,
                        Cidade = l.Cidade,
                        Estado = l.Estado,
                        TipoEndereco = l.TipoEndereco,
                        NumeroApartamento = l.NumeroApartamento,
                        Andar = l.Andar,
                        NomeRecepcionista = l.NomeRecepcionista,
                        Complemento = l.Complemento,
                        PossuiEstacionamento = l.PossuiEstacionamento,
                        Observacoes = l.Observacoes
                    })
                    .ToList()
            };

            _context.Psicologos.Add(psicologo);
            await _context.SaveChangesAsync();

            return await BuscarPorIdAsync(psicologo.Id)
                ?? throw new Exception("Erro ao criar psicóloga.");
        }

        public async Task<List<PsicologoResponseDto>> BuscarTodasAsync()
        {
            return await _context.Psicologos
                .Include(p => p.LocaisAtendimento)
                .Select(p => new PsicologoResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Telefone = p.Telefone,
                    CRP = p.CRP,
                    DadosBancarios = p.DadosBancarios,
                    DisponibilidadeAgenda = p.DisponibilidadeAgenda,
                    LocaisAtendimento = p.LocaisAtendimento
                        .Select(l => new LocalAtendimentoResponseDto
                        {
                            Id = l.Id,
                            Cep = l.Cep,
                            Logradouro = l.Logradouro,
                            Numero = l.Numero,
                            Bairro = l.Bairro,
                            Cidade = l.Cidade,
                            Estado = l.Estado,
                            TipoEndereco = l.TipoEndereco,
                            NumeroApartamento = l.NumeroApartamento,
                            Andar = l.Andar,
                            NomeRecepcionista = l.NomeRecepcionista,
                            Complemento = l.Complemento,
                            PossuiEstacionamento = l.PossuiEstacionamento,
                            Observacoes = l.Observacoes
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<PsicologoResponseDto?> BuscarPorIdAsync(int id)
        {
            return await _context.Psicologos
                .Include(p => p.LocaisAtendimento)
                .Where(p => p.Id == id)
                .Select(p => new PsicologoResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Telefone = p.Telefone,
                    CRP = p.CRP,
                    DadosBancarios = p.DadosBancarios,
                    DisponibilidadeAgenda = p.DisponibilidadeAgenda,
                    LocaisAtendimento = p.LocaisAtendimento
                        .Select(l => new LocalAtendimentoResponseDto
                        {
                            Id = l.Id,
                            Cep = l.Cep,
                            Logradouro = l.Logradouro,
                            Numero = l.Numero,
                            Bairro = l.Bairro,
                            Cidade = l.Cidade,
                            Estado = l.Estado,
                            TipoEndereco = l.TipoEndereco,
                            NumeroApartamento = l.NumeroApartamento,
                            Andar = l.Andar,
                            NomeRecepcionista = l.NomeRecepcionista,
                            Complemento = l.Complemento,
                            PossuiEstacionamento = l.PossuiEstacionamento,
                            Observacoes = l.Observacoes
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AtualizarAsync(int id, PsicologoUpdateDto dto)
        {
            var psicologo = await _context.Psicologos
                .Include(p => p.LocaisAtendimento)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (psicologo == null) return false;

            if (dto.Nome != null) psicologo.Nome = dto.Nome;
            if (dto.Telefone != null) psicologo.Telefone = dto.Telefone;
            if (dto.CRP != null) psicologo.CRP = dto.CRP;
            if (dto.DadosBancarios != null) psicologo.DadosBancarios = dto.DadosBancarios;
            if (dto.DisponibilidadeAgenda != null) psicologo.DisponibilidadeAgenda = dto.DisponibilidadeAgenda;

            if (dto.LocaisAtendimento != null)
            {
                // Remove todos os locais antigos
                _context.LocaisAtendimento.RemoveRange(psicologo.LocaisAtendimento);

                // Cria novos objetos com os dados recebidos no DTO
                psicologo.LocaisAtendimento = dto.LocaisAtendimento.Select(l => new LocalAtendimento
                {
                    Cep = l.Cep,
                    Logradouro = l.Logradouro,
                    Numero = l.Numero,
                    Bairro = l.Bairro,
                    Cidade = l.Cidade,
                    Estado = l.Estado,
                    TipoEndereco = l.TipoEndereco,
                    NumeroApartamento = l.NumeroApartamento,
                    Andar = l.Andar,
                    NomeRecepcionista = l.NomeRecepcionista,
                    Complemento = l.Complemento,
                    PossuiEstacionamento = l.PossuiEstacionamento,
                    Observacoes = l.Observacoes
                }).ToList();
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var psicologo = await _context.Psicologos.FindAsync(id);
            if (psicologo == null) return false;

            _context.Psicologos.Remove(psicologo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
