using Xunit; // Usamos o framework xUnit para escrever testes unitários

// Importa os models, contexto e serviços do projeto principal
using backend.Models;
using backend.Data;
using backend.Services;
using backend.Dtos.ResponsavelLegal;
using Microsoft.EntityFrameworkCore; // Importa o pacote do Entity Framework Core (usado com o banco em memória)
using System.Threading.Tasks;  // Para permitir o uso de async/await nos testes

namespace backend.tests.Services
{
    // Define uma classe de teste unitário para a camada de serviço de Responsável Legal
    public class ResponsavelLegalServiceTests
    {
        // Método auxiliar para criar um contexto do Entity Framework com banco em memória
        private ClinicaContext CriarContextoInMemory()
        {
            var options = new DbContextOptionsBuilder<ClinicaContext>()
                .UseInMemoryDatabase(databaseName: "TestDb") // Gera um "banco de dados falso" na memória
                .Options;

            return new ClinicaContext(options); // Cria o contexto com as opções in-memory
        }

        // Esse atributo [Fact] diz que esse é um teste que será executado
        [Fact]
        public async Task CriarAsync_DeveSalvarResponsavelNoBancoERetornarId()
        {
            // ---------- ARRANGE ----------
            // Prepara os objetos necessários para o teste

            var context = CriarContextoInMemory(); // Cria o contexto simulado (sem tocar no banco real)
            var service = new ResponsavelLegalService(context); // Cria o serviço com o contexto falso

            // Cria um DTO de entrada simulando dados de um novo responsável
            var dto = new ResponsavelLegalCreateDto
            {
                Nome = "Carlos",
                Telefone = "99999-9999",
                Email = "carlos@email.com",
                CPF = "12345678900",
                Parentesco = "Pai"
            };

            // ---------- ACT ----------
            // Executa a ação que está sendo testada
            var idCriado = await service.CriarAsync(dto); // Chama o método que deve salvar no "banco"

            // ---------- ASSERT ----------
            // Verifica se o resultado foi o esperado

            // Busca no contexto se o ID foi realmente salvo
            var responsavel = await context.ResponsaveisLegais.FindAsync(idCriado);

            // Verifica se o responsável foi criado
            Assert.NotNull(responsavel); // Confirma que o resultado não é nulo

            // Confirma que o nome está correto (ou seja, foi salvo corretamente)
            Assert.Equal("Carlos", responsavel.Nome);
            Assert.Equal("99999-9999", responsavel.Telefone);
            Assert.Equal("carlos@email.com", responsavel.Email);
            Assert.Equal("12345678900", responsavel.CPF);
            Assert.Equal("Pai", responsavel.Parentesco);
            Assert.True(idCriado > 0); // Verifica se o ID retornado é maior que zero (significa que foi criado com sucesso)
            
            Assert.Single(context.ResponsaveisLegais.ToList()); // Verifica se apenas um responsável foi adicionado ao contexto
        }
    }
}
