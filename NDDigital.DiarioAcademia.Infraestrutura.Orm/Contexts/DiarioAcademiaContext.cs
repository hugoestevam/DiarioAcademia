using Microsoft.AspNet.Identity.EntityFramework;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts
{
    public class DiarioAcademiaContext : IdentityDbContext<User>
    {
        public DiarioAcademiaContext()
            : base("DiarioAcademiaContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DiarioAcademiaContext>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Presenca> Presencas { get; set; }

        public static DiarioAcademiaContext Create()
        {
            return new DiarioAcademiaContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlunoConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new AulaConfiguration());
            modelBuilder.Configurations.Add(new TurmaConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PresencaConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
        }
    }
}