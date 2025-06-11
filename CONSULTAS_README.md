# 📅 Módulo de Consultas - Clínica SaaS

## ✅ Arquivos Criados

### 📁 Estrutura dos Arquivos
```
src/
├── services/
│   └── consultaService.js          # Service para comunicação com API
├── components/
│   └── consultas/
│       ├── ConsultasList.vue       # Componente da tabela/grid
│       └── ConsultaModal.vue       # Modal para criar/editar
├── views/
│   └── ConsultasView.vue           # Página principal das consultas
└── router/
    └── index.js                    # Atualizado com rota /consultas
```

### 📝 Arquivos Modificados
- `src/router/index.js` → Adicionada rota `/consultas`
- `src/components/SidebarMenu.vue` → Adicionado link para consultas
- `src/views/ConsultasView.vue` → Conectado com modal

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

### 3. Navegar para Consultas
1. Abra o navegador: `http://localhost:8080`
2. Clique em **"Consultas"** no menu lateral
3. Você verá a página de gerenciamento de consultas

## 🎯 Funcionalidades Implementadas

### ✅ Listar Consultas
- Grid/tabela responsiva
- Colunas: ID, Paciente, Data/Hora, Motivo, Status, Observações
- Loading state e tratamento de erro
- Status visual com cores (Agendada/Realizada/Cancelada)

### ✅ Agendar Nova Consulta
1. Clicar no botão **"Nova Consulta"**
2. Selecionar paciente no dropdown
3. Escolher data e hora
4. Preencher motivo e observações (opcionais)
5. Salvar → Lista atualiza automaticamente

### ✅ Editar Consulta
1. Clicar no ícone de lápis na linha da consulta
2. Modal abre com dados preenchidos
3. Modificar campos necessários
4. Alterar status se necessário (Agendada/Realizada/Cancelada)
5. Salvar alterações

### ✅ Cancelar Consulta
1. Clicar no ícone de cancelamento (X)
2. Confirmar no modal de confirmação
3. Consulta fica como "Cancelada"

## 🔒 Regras de Negócio Implementadas

### ⏰ Validações de Data/Hora
- **Novas consultas**: Não podem ser agendadas no passado
- **Data obrigatória**: Campo obrigatório
- **Hora obrigatória**: Campo obrigatório

### 👤 Validações de Paciente
- **Paciente obrigatório**: Deve selecionar um paciente
- **Apenas pacientes ativos**: Dropdown mostra só pacientes ativos

### 🚫 Restrições de Ações
- **Consultas canceladas**: Não podem ser editadas
- **Consultas realizadas**: Não podem ser canceladas
- **Consultas canceladas**: Não podem ser canceladas novamente

## 🏗️ Arquitetura Explicada

### 🔄 Fluxo de Dados
```
ConsultasView.vue (Página)
    ↓
ConsultasList.vue (Tabela)
    ↓
consultaService.js (API calls)
    ↓
Backend C# (ASP.NET Core)
```

### 📋 Responsabilidades

**ConsultasView.vue** (VIEW):
- Página principal da rota `/consultas`
- Coordena componentes
- Gerencia estado dos modais

**ConsultasList.vue** (COMPONENT):
- Renderiza tabela de consultas
- Gerencia loading/erro
- Formatação de data/hora
- Status coloridos com badges
- Emite eventos para o pai

**ConsultaModal.vue** (COMPONENT):
- Formulário para agendar/editar consultas
- Dropdown de pacientes (carregado dinamicamente)
- Validação de dados e regras de negócio
- Comunicação com API

**consultaService.js** (SERVICE):
- Abstrai chamadas HTTP para consultas
- Endpoint para listar pacientes (dropdown)
- Trata erros da API
- Reutilizável em outros componentes

### 🎨 Tecnologias Utilizadas
- **Vue 3** (Composition API)
- **Bootstrap 5** (UI Framework)
- **Bootstrap Icons** (Ícones: calendar, pencil, x-circle)
- **Axios** (HTTP Client)
- **Vue Router** (Roteamento)

## 📊 Status das Consultas

### 🔵 Agendada (bg-primary)
- Consulta marcada mas ainda não realizada
- Pode ser editada ou cancelada

### 🟢 Realizada (bg-success)
- Consulta já foi realizada
- Pode ser editada mas não cancelada

### 🔘 Cancelada (bg-secondary)
- Consulta foi cancelada
- Não pode ser editada nem cancelada novamente

## 🐛 Possíveis Problemas

### Backend não conecta?
- Verificar se está rodando na porta 5059
- Verificar CORS no backend
- Abrir DevTools → Console para ver erros

### Dropdown de pacientes vazio?
- Verificar se há pacientes cadastrados
- Verificar se pacientes estão ativos
- Verificar endpoint `/api/pacientes` no backend

### Erro ao salvar consulta?
- Verificar formato da data/hora
- Verificar se pacienteId é um número
- Verificar backend logs

### Modal não abre?
- Verificar se Bootstrap JS foi carregado
- Verificar console do navegador

## 📱 Responsividade

O sistema está preparado para:
- ✅ Desktop (1200px+)
- ✅ Tablet (768px - 1199px)  
- ✅ Mobile (< 768px)

**Tabela responsiva**: Em telas menores, aparecerá scroll horizontal.

## 🔜 Próximos Passos

### 1. **Melhorias na UI**:
   - Calendario visual para seleção de datas
   - Filtros por período, paciente, status
   - Paginação da tabela
   - Ordenação das colunas

### 2. **Validações Avançadas**:
   - Verificar conflitos de horário
   - Horário de funcionamento da clínica
   - Limite de consultas por dia

### 3. **Funcionalidades**:
   - Relatórios de consultas
   - Exportar agenda para Excel/PDF
   - Notificações de lembrete
   - Reagendamento automático

### 4. **Integrações**:
   - Envio de SMS/email de confirmação
   - Sincronização com Google Calendar
   - WhatsApp Business API

### 5. **Performance**:
   - Lazy loading da tabela
   - Cache de pacientes
   - Paginação server-side

## 🔗 Relacionamentos

### Consulta → Paciente
- **consultaService.js** busca lista de pacientes para dropdown
- **ConsultaModal.vue** mostra nome do paciente selecionado
- **ConsultasList.vue** exibe nome do paciente na tabela

### Dependências
- ✅ Módulo de **Pacientes** deve estar funcionando
- ✅ API endpoint `/api/pacientes` deve retornar pacientes ativos
- ✅ API endpoint `/api/consultas` deve aceitar `pacienteId`

---

**🎉 Parabéns!** Você agora tem um sistema completo de agendamento de consultas!

## 🚦 Checklist de Implementação

- [x] Service de consultas criado
- [x] Componente de lista criado
- [x] Modal de agendamento/edição criado
- [x] View principal criada
- [x] Rota adicionada ao router
- [x] Menu lateral atualizado
- [x] Validações implementadas
- [x] Status coloridos implementados
- [x] Integração com pacientes funcionando

**✨ Tudo pronto para uso!**
