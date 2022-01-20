using Empresa.Projeto.Domain;

namespace Empresa.Projeto.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly AppContext appContext;

        public UsuarioRepository(AppContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }


    }
}