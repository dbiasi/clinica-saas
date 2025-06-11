// Importa os DTOs usados nos métodos da interface
using backend.Dtos.ResponsavelLegal;

namespace backend.Services.Interfaces
{
    // Interface que define o contrato do serviço de Responsável Legal
    public interface IResponsavelLegalService
    {
        // Método para criar um novo responsável legal.
        // Recebe um DTO com os dados e retorna o ID gerado no banco.
        Task<int> CriarAsync(ResponsavelLegalCreateDto dto);

        // Método para buscar um responsável legal pelo ID.
        // Retorna um DTO de resposta com os dados do responsável ou null se não encontrado.
        Task<ResponsavelLegalResponseDto?> BuscarPorIdAsync(int id);

        // Método para listar todos os responsáveis legais cadastrados.
        // Retorna uma lista com os DTOs de resposta.
        Task<List<ResponsavelLegalResponseDto>> ListarTodosAsync();
    }
}

// Criamos a interface IResponsavelLegalService para definir os métodos que o serviço ResponsavelLegalService deve implementar.
// Essa interface contém três métodos:
// 1. CriarAsync: Recebe um DTO de criação de responsável legal e retorna o ID do novo responsável legal criado.
// 2. BuscarPorIdAsync: Recebe um ID e retorna um DTO de resposta com os detalhes do responsável legal correspondente.
// 3. ListarTodosAsync: Retorna uma lista de DTOs de resposta com todos os responsáveis legais cadastrados.

// Por que criamos uma interface?
// Para seguir boas práticas (SOLID). Isso permite:
// Testar com facilidade (mock)
// Trocar a implementação sem afetar o resto do código
// Injetar a dependência no controller com flexibilidade