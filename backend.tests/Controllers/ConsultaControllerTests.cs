// using System;
// using System.Threading.Tasks;
// using backend.Controllers;
// using backend.Dtos.Consulta;
// using backend.Services.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using Xunit;

// namespace backend.Tests.Controllers
// {
//     public class ConsultaControllerTests
//     {
//         [Fact]
//         public async Task Get_DeveRetornarOk_QuandoConsultaExiste()
//         {
//             // Arrange
//             var consultaId = 1;
//             var consultaEsperada = new ConsultaResponseDto
//             {
//                 Id = consultaId,
//                 PacienteId = 10,
//                 NomePaciente = "João",
//                 DataHora = DateTime.Now,
//                 Status = "Agendada",
//                 Valor = 100,
//                 Observacao = "Retorno"
//             };

//             var mockService = new Mock<IConsultaService>();
//             mockService.Setup(s => s.BuscarPorIdAsync(consultaId))
//                        .ReturnsAsync(consultaEsperada);

//             var controller = new ConsultaController(mockService.Object);

//             // Act
//             var resultado = await controller.Get(consultaId);

//             // Assert
//             var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
//             var consultaRetornada = Assert.IsType<ConsultaResponseDto>(okResult.Value);
//             Assert.Equal(consultaEsperada.Id, consultaRetornada.Id);
//         }

//         [Fact]
//         public async Task Get_DeveRetornarNotFound_QuandoConsultaNaoExiste()
//         {
//             // Arrange
//             var consultaId = 999;

//             var mockService = new Mock<IConsultaService>();
//             mockService.Setup(s => s.BuscarPorIdAsync(consultaId))
//                        .ReturnsAsync((ConsultaResponseDto?)null);

//             var controller = new ConsultaController(mockService.Object);

//             // Act
//             var resultado = await controller.Get(consultaId);

//             // Assert
//             Assert.IsType<NotFoundResult>(resultado.Result);
//         }
//     }
// }
