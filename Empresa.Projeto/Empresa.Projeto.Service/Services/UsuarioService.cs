using AutoMapper;
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
    }
}