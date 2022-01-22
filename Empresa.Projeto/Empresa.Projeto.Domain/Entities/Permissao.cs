using System;

namespace Empresa.Projeto.Domain
{
    public class Permissao : Base
    {
        // Propriedades
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int Status { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        // Propriedades de navegação

        // EF
        protected Permissao() { }

        // Construtor
        public Permissao(string nome,
                         string descricao,
                         int status,
                         DateTime? criadoEm,
                         DateTime? alteradoEm)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm;
        }

        // Metodos
    }
}