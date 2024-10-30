🐾 Sistema de Gerenciamento de Adoção de Animais

Este projeto é uma aplicação completa para gerenciar o processo de adoção de animais em abrigos, desenvolvida com ASP.NET Core no backend e React no frontend. A aplicação possibilita o controle de abrigos, animais, adotantes e adoções, tornando o processo de adoção mais eficiente e organizado. 🏡🐶🐱

⚙️ Funcionalidades
📌 Cadastro e listagem de abrigos
🐕 Cadastro, atualização, listagem e exclusão de animais
👤 Cadastro e listagem de adotantes
💼 Registro, atualização e exclusão de adoções
🛠️ Tecnologias Utilizadas
- Backend
- ORM para banco de dados
- Banco de dados leve
- Frontend
- Requisições HTTP no frontend
🌐 Estrutura de Endpoints

Abrigos
🔹 POST /adopet/abrigos/cadastrar - Cadastrar abrigo
🔹 GET /adopet/abrigos/listar - Listar abrigos

Animais
🐾 POST /adopet/animais/cadastrar - Cadastrar animal
🐾 GET /adopet/animais/listar - Listar animais
🐾 PUT /adopet/animais/{id} - Atualizar animal
🐾 DELETE /adopet/animais/{id} - Deletar animal

Adotantes
👥 POST /adopet/adotantes/cadastrar - Cadastrar adotante
👥 GET /adopet/adotantes/listar - Listar adotantes

Adoções
❤️ POST /adopet/adocoes/cadastrar - Registrar adoção
❤️ GET /adopet/adocoes/listar - Listar adoções
❤️ PUT /adopet/adocoes/{id} - Atualizar adoção
❤️ DELETE /adopet/adocoes/{id} - Deletar adoção
📂 Estrutura do Banco de Dados
O banco de dados SQLite (adopet.db) é criado automaticamente e armazena todas as informações necessárias para o gerenciamento de abrigos, animais, adotantes e adoções.
