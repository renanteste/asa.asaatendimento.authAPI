asa.asaatendimento.authAPI

📄 Overview

asa.asaatendimento.authAPI is a lightweight authentication API developed in ASP.NET Core 8.0. It is designed to serve authentication needs. It utilizes JWT tokens for secure authentication and SQLite for persistent storage.

📊 Architecture

The project follows a layered architecture:

Controllers: Handle incoming HTTP requests.

Services: Contain the business logic, separated via interfaces for maintainability and testing.

Data Layer: Uses Entity Framework Core with a SQLite provider for data persistence.

Dependency Injection: Managed through built-in ASP.NET Core dependency injection.

JWT Authentication: Secures endpoints using JSON Web Tokens.

Folder Structure

asa.asaatendimento.authAPI/
├── Controllers/
│   └── AuthController.cs
│   └── UsuariosController.cs
├── Data/
│   └── AppDbContext.cs
│   └── DbInitializer.cs
├── Models/
│   └── Usuario.cs
│   └── AutenticacaoWhatsApp.cs
├── Services/
│   └── IUsuarioService.cs
│   └── ITokenService.cs
│   └── UsuarioService.cs
│   └── TokenService.cs
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── Program.cs

🚀 Key Features

JWT-based authentication

Secure password hashing using BCrypt.Net

Entity Framework Core with SQLite

Swagger UI for API documentation and testing

Dependency injection and interface-based design

🔧 NuGet Packages Used

Package

Description

Microsoft.AspNetCore.Authentication.JwtBearer

JWT Authentication support

Microsoft.EntityFrameworkCore

ORM Framework

Microsoft.EntityFrameworkCore.Sqlite

SQLite support for EF Core

Microsoft.EntityFrameworkCore.Design

Design-time tools for EF Core

Microsoft.EntityFrameworkCore.Tools

Migration and DB update tooling

Swashbuckle.AspNetCore

Swagger UI generator

BCrypt.Net-Next

Secure password hashing

📁 Configuration - appsettings.json

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Jwt": {
    "Key": "K7mHETAFVvkaetrkM7DmeSjeGgYMloW0Fw7lzDTrI0M=",
    "Issuer": "asa.authAPI",
    "Audience": "asa.authAPI"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}

📂 JWT Authentication

A token is generated upon valid login

The token contains user claims and is signed with a secure key

Token is used in the Authorization: Bearer {token} header to access protected endpoints

📊 Dependency Injection

All services are injected through the DI container using interfaces:

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITokenService, TokenService>();

This allows easier testing, abstraction, and decoupling of business logic.

📆 Database

Database used: SQLite

Connection string: Data Source=app.db

Managed via Entity Framework Core

To apply migrations:

dotnet ef migrations add InitialCreate
dotnet ef database update

📖 Example Properties

Usuario.cs

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; } // hashed password
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}

AutenticacaoWhatsApp.cs

public class AutenticacaoWhatsApp
{
    public int Id { get; set; }
    public string NumeroTelefone { get; set; }
    public string CodigoVerificacao { get; set; }
    public DateTime ExpiraEm { get; set; }
    public Usuario Usuario { get; set; }
}

✅ How to Run

git clone https://github.com/renanteste/asa.asaatendimento.authAPI.git
cd asa.asaatendimento.authAPI
dotnet restore
dotnet ef database update
dotnet run

Access via: https://localhost:{PORT}/swagger

📄 Author

RenanEmail: renan_mtvroa@hotmail.comGitHub: renanteste

✉️ License

MIT License
