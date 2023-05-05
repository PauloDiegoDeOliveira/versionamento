using Empresa.Projeto.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infra
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<List<Usuario>> GetBuscarNomeAsync(string nome);
        Task<Usuario> GetBuscarEmailAsync(string email); 
    }
}