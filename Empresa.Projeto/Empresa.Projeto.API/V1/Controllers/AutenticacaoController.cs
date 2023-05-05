using Empresa.Projeto.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Empresa.Projeto.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService; 
        }

        /// <summary>
        /// Autentica um usuário.
        /// </summary>
        /// <param name="viewAutenticacao"></param>
        /// <returns></returns>
        [HttpPost("entrar")]        
        public async Task<IActionResult> AutenticacaoAsync([FromBody] ViewAutenticacao viewAutenticacao)
        {
            var consultado = await usuarioService.AutenticacaoAsync(viewAutenticacao); 
            if (consultado != null) 
            {
                return Ok(consultado);
            }
            return Unauthorized(new { mensagem = "Usuário e/ou senha inválidos" });
        }
    }
}
