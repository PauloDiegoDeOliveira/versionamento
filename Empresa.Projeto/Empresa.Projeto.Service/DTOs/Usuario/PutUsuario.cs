using Empresa.Projeto.Domain;

namespace Empresa.Projeto.Service
{
    public class PutUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }    
        public string Email { get; set; }
        public string Senha { get; set; }
        public Status Status { get; set; }
    }
}