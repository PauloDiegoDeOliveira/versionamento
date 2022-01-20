using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Projeto.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }     
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }   
        public int Status { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
    }
}