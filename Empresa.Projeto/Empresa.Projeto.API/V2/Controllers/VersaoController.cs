using Microsoft.AspNetCore.Mvc;

namespace Empresa.Projeto.API.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/versao")]
    public class VersaoController : ControllerBase 
    {
        [HttpGet]
        public string Valor()
        {
            return "Sou a V2";
        }
    }
}
