using asa.asaatendimento.authAPI.Models;

namespace asa.asaatendimento.authAPI.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
