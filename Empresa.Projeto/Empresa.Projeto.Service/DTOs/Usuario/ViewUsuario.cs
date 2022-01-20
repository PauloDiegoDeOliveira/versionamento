using Empresa.Projeto.Domain;
using System;

namespace Empresa.Projeto.Service
{
    public class ViewUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}