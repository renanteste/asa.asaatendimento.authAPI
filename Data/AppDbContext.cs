using Microsoft.EntityFrameworkCore;
using asa.asaatendimento.authAPI.Models;

namespace asa.asaatendimento.authAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<AutenticacaoWhatsApp> AutenticacoesWhatsApp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de chave estrangeira entre Token e Usuario
            modelBuilder.Entity<Token>()
                .HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId);

            // Configuração de chave estrangeira entre AutenticacaoWhatsApp e Usuario
            modelBuilder.Entity<AutenticacaoWhatsApp>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId);
        }
    }
}
