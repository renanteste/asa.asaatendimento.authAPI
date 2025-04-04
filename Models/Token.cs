using System.ComponentModel.DataAnnotations;

namespace asa.asaatendimento.authAPI.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TokenValue { get; set; }

        [Required]
        public DateTime Expiracao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
