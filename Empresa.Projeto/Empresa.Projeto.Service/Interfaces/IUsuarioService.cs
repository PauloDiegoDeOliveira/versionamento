using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Service
{
    public interface IUsuarioService
    {
        Task<List<ViewUsuario>> GetAllAsync();
        Task<List<ViewUsuario>> GetBuscarNomeAsync(string nome); 
    }
}