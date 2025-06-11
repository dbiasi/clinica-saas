namespace backend.Models
{
    public class ResponsavelLegal
    {
        public int Id { get; set; } // Chave primária. O EF Core irá gerar automaticamente como identidade.

        public string Nome { get; set; } = string.Empty;      // Nome do responsável
        public string Telefone { get; set; } = string.Empty;  // Telefone de contato
        public string Email { get; set; } = string.Empty;     // Email do responsável
        public string CPF { get; set; } = string.Empty;       // CPF (documento de identificação)
        public string Parentesco { get; set; } = string.Empty;// Grau de parentesco com o paciente

        // Relacionamento 1:N - Um responsável pode estar vinculado a vários pacientes
        public List<Paciente> Pacientes { get; set; } = new(); // Propriedade de navegação
    }
}

// Criamos essa Model para que o EF Core possa mapear a tabela ResponsavelLegal no banco de dados.
// Ela contém as propriedades básicas de um responsável legal, como Nome, Telefone, Email, CPF e Parentesco.
// Além disso, ela possui uma lista de Pacientes, representando o relacionamento entre Responsável Legal e Pacientes.
// O EF Core irá criar a tabela ResponsavelLegal com essas colunas e gerenciar o relacionamento com a tabela Paciente.
// A Model também possui um Id, que é a chave primária da tabela.
// O EF Core irá gerar automaticamente o Id como uma coluna de identidade, ou seja, ele será incrementado automaticamente a cada novo registro inserido na tabela.
// Essa Model é essencial para que possamos realizar operações de CRUD (Create, Read, Update, Delete) na tabela ResponsavelLegal através do EF Core.
// A Model ResponsavelLegal é utilizada pelo serviço ResponsavelLegalService para realizar operações de criação, busca e listagem de responsáveis legais no banco de dados.
// O EF Core irá mapear essa Model para a tabela ResponsavelLegal no banco de dados, permitindo que possamos realizar operações de CRUD (Create, Read, Update, Delete) na tabela ResponsavelLegal através do EF Core.
// A Model ResponsavelLegal é essencial para que possamos gerenciar os responsáveis legais dos pacientes na clínica.
// Ela permite que possamos armazenar informações sobre os responsáveis legais, como Nome, Telefone, Email, CPF e Parentesco.