using asa.asaatendimento.authAPI.Models;

namespace asa.asaatendimento.authAPI.Services
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
