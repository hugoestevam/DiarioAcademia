using Microsoft.AspNet.Identity.EntityFramework;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity;
using System.Collections.Generic;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts
{
    public class AuthenticationContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationContext()
            : base("DiarioAuthContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AuthenticationContext>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static AuthenticationContext Create()
        {
            return new AuthenticationContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("TBUser")
                .Ignore(c => c.EmailConfirmed);
            modelBuilder.Entity<Group>().ToTable("TBGroup");
            modelBuilder.Entity<Permission>().ToTable("TBPermission");
        }

        /// <summary>
        /// Em algum momento vamos chamar esse método que mata as tabelas que não serão usadas
        /// </summary>
        /// <param name="context"></param>
        public void DropTables(AuthenticationContext context)
        {
            var listOfTables = new List<string> { "[dbo].[AspNetRoles]", "[dbo].[AspNetUserClaims]", "[dbo].[AspNetUserLogins]", "[dbo].[AspNetUserRoles]" };

            foreach (var tableName in listOfTables)
            {
                try
                {
                    context.Database.ExecuteSqlCommand("DROP TABLE " + tableName );
                }
                catch (System.Exception)
                {
                    return;
                }
            }
            context.SaveChanges();
        }
    }
}