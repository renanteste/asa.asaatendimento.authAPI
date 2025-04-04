using asa.asaatendimento.authAPI.Data;
using asa.asaatendimento.authAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace asa.asaatendimento.authAPI.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
