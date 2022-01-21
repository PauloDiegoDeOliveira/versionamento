using AutoMapper;
using Empresa.Projeto.Domain;
using Empresa.Projeto.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<List<ViewUsuario>> GetAllAsync()
        {
            var consulta = await usuarioRepository.GetAllAsync();
            return mapper.Map<List<ViewUsuario>>(consulta);
        }

        public async Task<ViewUsuario> GetByIdAsync(int id) 
        {
            var consulta = await usuarioRepository.GetByIdAsync(id);
            return mapper.Map<ViewUsuario>(consulta);
        }

        public async Task<List<ViewUsuario>> GetBuscarNomeAsync(string nome)
        {
            List<Usuario> consulta = await usuarioRepository.GetBuscarNomeAsync(nome);
            if (consulta == null)
            {
                return null;
            }
            return mapper.Map<List<ViewUsuario>>(consulta);
        }
    }
}