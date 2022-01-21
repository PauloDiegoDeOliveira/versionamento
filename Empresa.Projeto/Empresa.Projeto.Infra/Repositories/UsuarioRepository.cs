using Empresa.Projeto.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly AppContext appContext;

        public UsuarioRepository(AppContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }

        public async Task<List<Usuario>> GetBuscarNomeAsync(string nome) 
        {
            var consultado = await appContext.Usuarios
                                        .Where(ns => EF.Functions.Like(ns.Nome, $"%{nome}%"))
                                        .AsNoTracking()
                                        .ToListAsync();
            return consultado;
        }
    }
}