using Empresa.Projeto.Domain;

namespace Empresa.Projeto.Service
{
    public class ViewLogin
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }   
        public string Email { get; set; }
        public Status Status { get; set; }
     
        public string Token { get; set; }
        public string TokenExpira { get; set; }
        public string Mensagem { get; set; }
    }
}