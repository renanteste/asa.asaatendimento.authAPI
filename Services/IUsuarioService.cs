// IUsuarioService.cs

using asa.asaatendimento.authAPI.Models;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetUsuariosAsync();
    Task<Usuario?> GetUsuarioByIdAsync(int id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<Usuario?> UpdateUsuarioAsync(Usuario usuario);
    Task<bool> DeleteUsuarioAsync(int id);
    Task<Usuario?> Autenticar(string email, string senha);

    // Remova isso, se não for usar:
    // Task<Usuario?> ObterPorId(int id);
}
