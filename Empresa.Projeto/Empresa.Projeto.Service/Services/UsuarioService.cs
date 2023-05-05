using AutoMapper;
using Empresa.Projeto.Domain;
using Empresa.Projeto.Infra;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Empresa.Projeto.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IJWTService jwt;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IMapper mapper,
                              IConfiguration configuration,
                              IJWTService jwt)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.jwt = jwt;
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

        public async Task<ViewLogin> AutenticacaoAsync(ViewAutenticacao viewAutenticacao)
        {
            var consulta = await usuarioRepository.GetBuscarEmailAsync(viewAutenticacao.Email);
            if (consulta == null)
            {
                return null;
            }

            //await usuarioRepository.UltimoAcessoAsync(usuarioConsultado);

            if (await ValidaEAtualizaHashAsync(viewAutenticacao, consulta.Senha))
            {
                var usuarioLogado = mapper.Map<ViewLogin>(consulta);

                usuarioLogado.Token = jwt.GerarToken(consulta);
                usuarioLogado.Mensagem = "Usuário autenticado com sucesso!";
                usuarioLogado.TokenExpira = DateTime.Now.AddMinutes(Convert.ToInt32(configuration.GetSection("JWT:ExpiraEmMinutos").Value)).ToString();
                return usuarioLogado;
            }
            return null;
        }

        private static async Task<bool> ValidaEAtualizaHashAsync(ViewAutenticacao viewAutenticacao, string hash)
        {
            await Task.CompletedTask;
            var passwordHasher = new PasswordHasher<ViewAutenticacao>();
            var status = passwordHasher.VerifyHashedPassword(viewAutenticacao, hash, viewAutenticacao.Senha);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                case PasswordVerificationResult.SuccessRehashNeeded:
                    return true;

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}