using Empresa.Projeto.Domain;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Projeto.Infra
{
    public class AppContext : DbContext
    {
        //// Migration
        //public AppContext() { } 

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        //// Migration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=Diego-PC;Initial Catalog=Projeto;Integrated Security=SSPI;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
    }
}