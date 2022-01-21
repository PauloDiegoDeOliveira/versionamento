using Empresa.Projeto.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var consulta = await usuarioService.GetAllAsync();
            if (consulta.Any())
            {
                return Ok(consulta);
            }
            return NotFound(new { mensagem = "Nenhum usuário foi encontrado." });
        }

        /// <summary>
        /// Retorna um usuário consultado pelo nome.
        /// </summary>
        /// <returns></returns>
        [HttpGet("buscar-nome")]
        public async Task<IActionResult> GetBuscarNomeAsync(string nome)
        {
            var consulta = await usuarioService.GetBuscarNomeAsync(nome);
            if (consulta.Any())
            {
                return Ok(consulta);
            }
            return NotFound(new { mensagem = "Nenhum usuário foi encontrado com o nome informado" });
        }
    }
}

//TODO: CTRL M O fechar
//TODO: CTRL M L abrir
//TODO: CTRL K X listar Snippet
//TODO: CTRL SHIFT V copiar e colar avançado
