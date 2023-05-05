using Empresa.Projeto.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infra
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly AppContext appContext;

        public BaseRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await appContext.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var obj = await appContext.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<T> PostAsync(T obj)
        {
            appContext.Add(obj);
            await appContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> PutAsync(T obj)
        {
            appContext.Entry(obj).State = EntityState.Modified;
            await appContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> DeleteAsync(int id) 
        {
            var obj = await GetByIdAsync(id);

            if (obj != null)
            {
                appContext.Remove(obj);
                await appContext.SaveChangesAsync();
            }

            return obj;
        }
    }
}