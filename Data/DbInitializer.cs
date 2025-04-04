using System;
using System.Linq;
using asa.asaatendimento.authAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace asa.asaatendimento.authAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Aplica as migrações automaticamente
                context.Database.Migrate();

                // Verifica se já há usuários cadastrados
                if (context.Usuarios.Any()) return;

                // Adiciona um usuário administrador padrão
                context.Usuarios.Add(new Usuario
                {
                    Nome = "Admin",
                    Email = "admin@asa.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("Admin123", workFactor: 12),
                    Telefone = "+5511999999999",
                    DataCadastro = DateTime.UtcNow,
                    Ativo = true
                });

                context.SaveChanges();
            }
        }
    }
}
