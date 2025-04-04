using System.ComponentModel.DataAnnotations;

namespace asa.asaatendimento.authAPI.Models
{
    public class AutenticacaoWhatsApp
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public DateTime Expiracao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
