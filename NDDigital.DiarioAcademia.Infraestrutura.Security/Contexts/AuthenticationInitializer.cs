using System.Data.Entity;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contexts
{
    public class AuthenticationInitializer : DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            
        }
    }
}