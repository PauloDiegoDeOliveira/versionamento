using AutoMapper;
using Empresa.Projeto.Domain;
using Empresa.Projeto.Infra;
using Microsoft.AspNetCore.Identity;
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

        public async Task<ViewUsuario> PostAsync(PostUsuario post)
        {
            ConverteSenhaEmHash(post);

            var consulta = mapper.Map<Usuario>(post);
            consulta = await usuarioRepository.PostAsync(consulta);
            return mapper.Map<ViewUsuario>(consulta);
        }

        private static void ConverteSenhaEmHash(PostUsuario post)
        {
            var passwordHasher = new PasswordHasher<PostUsuario>();
            post.Senha = passwordHasher.HashPassword(post, post.Senha);
        }

        public async Task<ViewUsuario> PutAsync(PutUsuario put)
        {
            ConverteSenhaEmHash(put);

            var consulta = mapper.Map<Usuario>(put);
            consulta = await usuarioRepository.PutAsync(consulta);
            return mapper.Map<ViewUsuario>(consulta);
        }

        private static void ConverteSenhaEmHash(PutUsuario put)
        {
            var passwordHasher = new PasswordHasher<PutUsuario>();
            put.Senha = passwordHasher.HashPassword(put, put.Senha);
        }

        public async Task<ViewUsuario> DeleteAsync(int id)
        {
            var consulta = await usuarioRepository.DeleteAsync(id);
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