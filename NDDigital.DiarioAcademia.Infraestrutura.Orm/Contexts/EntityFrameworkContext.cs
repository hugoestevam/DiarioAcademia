using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Infrasctructure.DAO.ORM.Contexts
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext()
            : base("DiarioAcademiaContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EntityFrameworkContext>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Presenca> Presencas { get; set; }

        public static EntityFrameworkContext Create()
        {
            return new EntityFrameworkContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AlunoConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new AulaConfiguration());
            modelBuilder.Configurations.Add(new TurmaConfiguration());
            modelBuilder.Configurations.Add(new PresencaConfiguration());
        }

        public void Detach(object entity)
        {
            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                IEnumerable<string> errors = e.EntityValidationErrors.SelectMany(
                    x =>
                        x.ValidationErrors).Select(
                    x =>
                        String.Format("{0}: {1}", x.PropertyName, x.ErrorMessage));

                throw new DbEntityValidationException(String.Join("; ", errors), e.EntityValidationErrors);
            }
        }
    }
}