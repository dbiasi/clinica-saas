# Clínica SaaS — Guia Git e GitHub

Sistema completo para clínicas psicológicas com backend em .NET e frontend em Vue.js, usando submódulo Git para o frontend.

========================================
📁 ESTRUTURA DO PROJETO
========================================

clinica-saas/
├── backend/            # API principal em .NET Core
├── backend.tests/      # Testes automatizados
├── frontend/           # Submódulo Git (Vue.js)
└── README.md

========================================
🚀 COMO CLONAR O PROJETO COM SUBMÓDULO
========================================

# Clonar o projeto e incluir o frontend automaticamente
git clone --recurse-submodules https://github.com/dbiasi/clinica-saas.git

# Entrar no projeto
cd clinica-saas

# (Opcional) Atualizar os submódulos manualmente, se necessário
git submodule update --init --recursive

========================================
🔄 COMO ENVIAR ALTERAÇÕES PARA O GITHUB
========================================

1. SE ALTEROU O BACKEND OU TESTES:
-----------------------------------
cd clinica-saas
git add .
git commit -m "Alterações no backend ou testes"
git push

2. SE ALTEROU O FRONTEND (SUBMÓDULO):
-------------------------------------
cd frontend
git add .
git commit -m "Alterações no frontend"
git push

3. ATUALIZAR O PONTEIRO DO FRONTEND NO PROJETO PRINCIPAL:
----------------------------------------------------------
cd ..
git add frontend
git commit -m "Atualiza ponteiro do submódulo frontend"
git push

========================================
🧪 COMO VERIFICAR O STATUS
========================================

# Ver arquivos modificados ou pendentes
git status

# Ver repositórios remotos conectados
git remote -v

========================================
✅ FLUXO COMPLETO DE TRABALHO
========================================

# 1. Alterar e versionar o frontend
cd frontend
git add .
git commit -m "Nova funcionalidade no frontend"
git push

# 2. Voltar à raiz e atualizar o submódulo
cd ..
git add frontend
git commit -m "Atualiza submódulo após alterações"
git push

========================================
🧠 DICAS
========================================

- O frontend é um repositório separado. Ele precisa de commits e push independentes.
- O repositório principal só aponta para o commit mais recente do frontend.
- Use sempre `--recurse-submodules` para clonar corretamente.
- Use `.gitignore` para evitar versionar `node_modules`, `bin/`, `obj/`, `.env`, etc.

========================================
👨‍💻 AUTOR
========================================

Jefferson Bressan
https://github.com/dbiasi
