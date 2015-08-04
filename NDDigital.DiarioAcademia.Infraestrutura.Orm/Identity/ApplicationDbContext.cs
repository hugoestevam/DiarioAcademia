using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DiarioAuthContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}