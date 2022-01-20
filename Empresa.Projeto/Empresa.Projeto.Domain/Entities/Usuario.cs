using System;

namespace Empresa.Projeto.Domain
{
    public class Usuario : Base
    {
        // Propriedades
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }
        public string Apelido { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public int Status { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        // EF
        protected Usuario()
        { }

        public Usuario(string nome,
                       string sobrenome,
                       string apelido,
                       string email,
                       string senha,
                       int status,
                       DateTime? criadoEm,
                       DateTime? alteradoEm)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Apelido = apelido;
            Email = email;
            Senha = senha;
            Status = status;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm;
        }
    }
}