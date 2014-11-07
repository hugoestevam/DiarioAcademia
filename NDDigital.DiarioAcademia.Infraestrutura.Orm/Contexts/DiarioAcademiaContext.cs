using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts
{
    public class DiarioAcademiaContext : DbContext
    {
        public DiarioAcademiaContext()
            : base("DiarioAcademiaContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Aluno> Alunos { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoConfiguration());
        }
    }

 
}