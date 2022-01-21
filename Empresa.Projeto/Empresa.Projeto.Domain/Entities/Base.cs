namespace Empresa.Projeto.Domain
{
    public abstract class Base
    {
        public long Id { get; set; }

        protected Base() { }
        protected Base(long id) 
        {
            Id = id;
        }
    }
}