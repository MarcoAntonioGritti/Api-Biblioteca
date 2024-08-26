# 📚 Projeto Api-Biblioteca

## Descrição

O projeto **Api-Biblioteca** é uma API completa para gerenciar uma biblioteca. Ele inclui um CRUD completo para gerenciar livros e seus detalhes, além de um método PATCH adicional para atualizar parcialmente os dados dos livros.

---

## Funcionalidades 🚀

- **CRUD Completo:**
  - **Create**: Adicionar novos livros. ✍️
  - **Read**: Recuperar informações sobre livros. 📖
  - **Update**: Atualizar detalhes dos livros existentes. 🔄
  - **Delete**: Remover livros da biblioteca. 🗑️

- **Método PATCH:** Atualiza parcialmente as informações dos livros usando JSON Patch. 🛠️

---

## Tecnologias Utilizadas 🛠️

- **ASP.NET Core**: Framework para desenvolvimento da API.
- **SQL Server**: Banco de dados utilizado para persistência dos dados.
- **Newtonsoft.Json**: Biblioteca para manipulação de JSON.
- **JsonPatch**: Biblioteca para suporte a atualizações parciais usando JSON Patch.

---

## Pacotes Necessários 📦

Para garantir que sua API funcione corretamente, instale os seguintes pacotes NuGet:

- **Microsoft.EntityFrameworkCore.Tools**: Ferramentas para Entity Framework Core.
- **Microsoft.EntityFrameworkCore.Design**: Design e ferramentas de suporte para EF Core.
- **Microsoft.EntityFrameworkCore.SqlServer**: Provedor de banco de dados SQL Server para EF Core.
- **Microsoft.AspNetCore.JsonPatch**: Suporte para JSON Patch no ASP.NET Core.
- **Newtonsoft.Json**: Biblioteca para manipulação de JSON.

## Você pode adicionar esses pacotes ao seu projeto usando o seguinte comando no **Package Manager Console**:

- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Microsoft.EntityFrameworkCore.Design
- Install-Package Microsoft.EntityFrameworkCore.SqlServer
- Install-Package Microsoft.AspNetCore.JsonPatch
- Install-Package Newtonsoft.Json

Ou, se você estiver usando o .NET CLI, use:

- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.AspNetCore.JsonPatch
- dotnet add package Newtonsoft.Json

Configuração 🔧

1. Clone o Repositório:
- git clone <URL_DO_REPOSITORIO>

2. Navegue até o Diretório do Projeto:
- cd Api-Biblioteca

3.Configure a String de Conexão:
- Atualize o arquivo appsettings.json com a string de conexão do seu banco de dados SQL Server.

4. Execute as Migrações:
- Execute as migrações para criar o banco de dados e as tabelas necessárias.

- dotnet ef migrations add InitialCreate
- dotnet ef database update
 
5. Inicie o Projeto!

## Endpoints 📍

| Método | Endpoint                         | Descrição                                              |
|--------|----------------------------------|--------------------------------------------------------|
| `GET`  | `/ListarLivros`                  | Recupera todos os livros.                              |
| `GET`  | `/ProcurarLivroPorIsbn/{isbn}`   | Recupera um livro específico pelo ISBN.                |
| `POST` | `/AdicionarLivro`                | Adiciona um novo livro.                                |
| `PUT`  | `/AtualizarLivroComPut/{id}`     | Atualiza um livro específico pelo ID.                  | 
| `PATCH`| `/AtualizarLivroComPatch/{id}`   | Atualiza parcialmente um livro específico pelo ID.     |
| `DELETE`| `/RemoverLivro/{id}`            | Remove um livro específico pelo ID.                    |

Contribuição 🤝
Sinta-se à vontade para contribuir com o projeto. Para fazer isso, siga os seguintes passos:

## Fork o repositório.
- Crie uma nova branch (git checkout -b feature-nova).
- Faça suas alterações e commit (git commit -a "Adiciona nova feature").
- Faça o push para a branch (git push origin feature-nova).
- Abra um Pull Request.
  
