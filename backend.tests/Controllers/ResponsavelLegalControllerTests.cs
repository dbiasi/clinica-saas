using Xunit;
using Moq;
using backend.Controllers;
using backend.Services.Interfaces;
using backend.Dtos.ResponsavelLegal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.tests.Controllers
{
    public class ResponsavelLegalControllerTests
    {
        [Fact]
        public async Task GetAll_DeveRetornarListaDeResponsaveis()
        {
            // Arrange: cria mock do serviço
            var mockService = new Mock<IResponsavelLegalService>();
            mockService.Setup(s => s.ListarTodosAsync())
                .ReturnsAsync(new List<ResponsavelLegalResponseDto>
                {
                    new() { Id = 1, Nome = "João", Telefone = "123", Email = "joao@email.com", CPF = "12345678900", Parentesco = "Pai" }
                });

            var controller = new ResponsavelLegalController(mockService.Object);

            // Act: chama o método do controller
            var resultado = await controller.GetAll();

            // Assert: verifica o retorno
            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
            var dados = Assert.IsType<List<ResponsavelLegalResponseDto>>(okResult.Value);
            Assert.Single(dados);
            Assert.Equal("João", dados[0].Nome);
        }
    }
}
