# 🏥 Módulo de Pacientes - Clínica SaaS

## ✅ Arquivos Criados

### 📁 Estrutura dos Arquivos
```
src/
├── services/
│   └── pacienteService.js          # Service para comunicação com API
├── components/
│   └── pacientes/
│       ├── PacientesList.vue       # Componente da tabela/grid
│       └── PacienteModal.vue       # Modal para criar/editar
├── views/
│   └── PacientesView.vue           # Página principal dos pacientes
└── router/
    └── index.js                    # Atualizado com rota /pacientes
```

### 📝 Arquivos Modificados
- `src/main.js` → Adicionado Bootstrap JS
- `public/index.html` → Adicionado Bootstrap Icons
- `src/router/index.js` → Adicionada rota `/pacientes`
- `src/views/PacientesView.vue` → Conectado com modal

## 🚀 Como Testar

### 1. Certificar que o Backend está rodando
```bash
# No terminal, vá para a pasta do backend
cd backend
dotnet run
```
**Deve estar rodando em:** `http://localhost:5059`

### 2. Rodar o Frontend
```bash
# No terminal, vá para a pasta do frontend
cd frontend
npm run serve
```
**Deve estar rodando em:** `http://localhost:8080`

### 3. Navegar para Pacientes
1. Abra o navegador: `http://localhost:8080`
2. Clique em **"Pacientes"** no menu lateral
3. Você verá a página de gerenciamento de pacientes

## 🎯 Funcionalidades Implementadas

### ✅ Listar Pacientes
- Grid/tabela responsiva
- Colunas: ID, Nome, Email, Telefone, Data Nascimento, Status
- Loading state e tratamento de erro
- Status visual (Ativo/Inativo)

### ✅ Criar Paciente
1. Clicar no botão **"Novo Paciente"**
2. Preencher formulário no modal
3. Salvar → Lista atualiza automaticamente

### ✅ Editar Paciente
1. Clicar no ícone de lápis na linha do paciente
2. Modal abre com dados preenchidos
3. Modificar e salvar

### ✅ Excluir Paciente (Soft Delete)
1. Clicar no ícone de lixeira
2. Confirmar no modal
3. Paciente fica como "Inativo"

## 🏗️ Arquitetura Explicada

### 🔄 Fluxo de Dados
```
PacientesView.vue (Página)
    ↓
PacientesList.vue (Tabela)
    ↓
pacienteService.js (API calls)
    ↓
Backend C# (ASP.NET Core)
```

### 📋 Responsabilidades

**PacientesView.vue** (VIEW):
- Página principal da rota `/pacientes`
- Coordena componentes
- Gerencia estado dos modais

**PacientesList.vue** (COMPONENT):
- Renderiza tabela de pacientes
- Gerencia loading/erro
- Emite eventos para o pai

**PacienteModal.vue** (COMPONENT):
- Formulário para criar/editar
- Validação de dados
- Comunicação com API

**pacienteService.js** (SERVICE):
- Abstrai chamadas HTTP
- Trata erros da API
- Reutilizável em outros componentes

### 🎨 Tecnologias Utilizadas
- **Vue 3** (Composition API)
- **Bootstrap 5** (UI Framework)
- **Bootstrap Icons** (Ícones)
- **Axios** (HTTP Client)
- **Vue Router** (Roteamento)

## 🐛 Possíveis Problemas

### Backend não conecta?
- Verificar se está rodando na porta 5059
- Verificar CORS no backend
- Abrir DevTools → Console para ver erros

### Modal não abre?
- Verificar se Bootstrap JS foi carregado
- Verificar console do navegador

### Ícones não aparecem?
- Verificar se Bootstrap Icons foi adicionado no HTML
- Verificar conexão com internet (CDN)

## 🔜 Próximos Passos

1. **Melhorias na UI**:
   - Paginação da tabela
   - Filtros e busca
   - Ordenação das colunas

2. **Validações**:
   - Formatação de telefone
   - Máscara de campos
   - Validações mais robustas

3. **Funcionalidades**:
   - Exportar lista para Excel
   - Importar pacientes via CSV
   - Histórico de consultas do paciente

4. **Performance**:
   - Lazy loading
   - Cache de dados
   - Otimização de requests

## 📱 Responsividade

O sistema está preparado para:
- ✅ Desktop (1200px+)
- ✅ Tablet (768px - 1199px)
- ✅ Mobile (< 768px)

---

**🎉 Parabéns!** Você agora tem um CRUD completo de pacientes funcionando!
