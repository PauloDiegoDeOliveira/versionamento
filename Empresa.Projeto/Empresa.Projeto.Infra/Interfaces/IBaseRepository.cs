using Empresa.Projeto.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infra
{
    public interface IBaseRepository<T> where T : Base
    {      
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> PostAsync(T obj);       
        Task<T> PutAsync(T obj);
        Task<T> DeleteAsync(int id);
    }
}