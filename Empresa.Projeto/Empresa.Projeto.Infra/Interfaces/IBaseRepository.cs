using Empresa.Projeto.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infra
{
    public interface IBaseRepository<T> where T : Base
    {      
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id); 
        
    }
}