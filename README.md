# To-Do App API

Esta é uma API backend para um aplicativo de lista de tarefas (To-Do) desenvolvido em C#. A API fornece endpoints para criar, ler, atualizar e excluir tarefas.

## Tecnologias Utilizadas

- C# (.NET Core)
- ASP.NET Core
- Entity Framework Core (ORM)
- Swagger (para documentação da API)

## Pré-requisitos

- .NET Core SDK 8.0
- SQL Server (ou outro banco de dados suportado pelo Entity Framework Core)

## Configuração

1. Clone este repositório: `git clone https://github.com/ArilsonB/csharp-todo-backend.git`

2. Navegue até o diretório do projeto: `cd todo-app-api`

3. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`.

4. Execute as migrações para criar o esquema do banco de dados: `dotnet ef database update`

5. Execute o projeto: `dotnet run`

A API estará acessível em `http://localhost:5000`.

## Endpoints

A documentação da API pode ser acessada em `http://localhost:5000/swagger`.

## Contribuindo

Contribuições são bem-vindas! Se você deseja contribuir com este projeto, por favor, siga estas etapas:

1. Fork este repositório.
2. Crie um branch com sua feature (`git checkout -b minha-feature`).
3. Faça commit de suas alterações (`git commit -am 'Adicionando nova feature'`).
4. Faça push para o branch (`git push origin minha-feature`).
5. Abra um pull request.

## Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.
