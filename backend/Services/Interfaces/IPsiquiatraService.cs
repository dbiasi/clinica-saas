// Importa os DTOs usados nos métodos da interface
using backend.Dtos.Psiquiatra;

namespace backend.Services.Interfaces
{

    // using System.Collections.Generic;
    // using System.Threading.Tasks;

    // Interface que define o contrato do serviço de Psiquiatra
    public interface IPsiquiatraService
    {
        // Método para criar um novo psiquiatra.
        // Recebe um DTO com os dados e retorna o ID gerado no banco.
        Task<int> CriarAsync(PsiquiatraCreateDto dto);

        // Método para buscar um psiquiatra pelo ID.
        // Retorna um DTO de resposta com os dados do psiquiatra ou null se não encontrado.
        Task<PsiquiatraResponseDto?> BuscarPorIdAsync(int id);

        // Método para listar todos os psiquiatras cadastrados.
        // Retorna uma lista com os DTOs de resposta.
        Task<List<PsiquiatraResponseDto>> ListarTodosAsync();
    }
}
// Criamos a interface IPsiquiatraService para definir os métodos que o serviço PsiquiatraService deve implementar.
// Essa interface contém três métodos:
// 1. CriarAsync: Recebe um DTO de criação de psiquiatra e retorna o ID do novo psiquiatra criado.
// 2. BuscarPorIdAsync: Recebe um ID e retorna um DTO de resposta com os detalhes do psiquiatra correspondente.
// 3. ListarTodosAsync: Retorna uma lista de DTOs de resposta com todos os psiquiatras cadastrados.
//
// Por que criamos uma interface?
// Para seguir boas práticas (SOLID). Isso permite:
// - Testar com facilidade (mock)
// - Trocar a implementação sem afetar o resto do código
// - Injetar a dependência no controller com flexibilidade
//