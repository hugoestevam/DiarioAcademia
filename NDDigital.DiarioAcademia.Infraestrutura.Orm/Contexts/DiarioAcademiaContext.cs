using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts
{
    public class DiarioAcademiaContext : DbContext
    {
        public DiarioAcademiaContext()
            : base("DiarioAcademiaContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DiarioAcademiaContext>());
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Presenca> Presencas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new AulaConfiguration());
            modelBuilder.Configurations.Add(new TurmaConfiguration());
            modelBuilder.Configurations.Add(new PresencaConfiguration());
        }
    }
}