using System.ComponentModel.DataAnnotations;

namespace asa.asaatendimento.authAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public bool Ativo { get; set; } = true;
    }
}
