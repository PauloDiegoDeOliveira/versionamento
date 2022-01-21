using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Service
{
    public interface IUsuarioService
    {
        Task<List<ViewUsuario>> GetAllAsync();
        Task<ViewUsuario> GetByIdAsync(int id);
        Task<ViewUsuario> PostAsync(PostUsuario post);
        Task<ViewUsuario> PutAsync(PutUsuario put);
        Task<ViewUsuario> DeleteAsync(int id);      
        Task<List<ViewUsuario>> GetBuscarNomeAsync(string nome); 
    }
}