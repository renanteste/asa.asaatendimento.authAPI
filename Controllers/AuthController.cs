using asa.asaatendimento.authAPI.Models;
using asa.asaatendimento.authAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using LoginRequestModel = asa.asaatendimento.authAPI.Models.LoginRequest; // Resolvendo ambiguidade

namespace asa.asaatendimento.authAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public AuthController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            var usuario = await _usuarioService.Autenticar(request.Email, request.Senha);

            if (usuario == null)
                return Unauthorized(new { message = "Credenciais inválidas" });

            var token = _tokenService.GerarToken(usuario);

            return Ok(new { token });
        }

        [HttpGet("perfil")]
        [Authorize]
        public async Task<IActionResult> PerfilAsync()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Usuário não identificado" });

            var usuario = await _usuarioService.GetUsuarioByIdAsync(int.Parse(userId));

            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return Ok(new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.Telefone
            });
        }
        [HttpGet("gerar-chave")]
        public IActionResult GerarChave()
        {
            string chave = ChaveService.GerarChaveJwt();
            return Ok(new { chave });
        }

    }
}
