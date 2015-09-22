using Ellevo.Biblioteca.Seguranca;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contexts
{
    public class AuthenticationInitializer : DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            
        }
    }
}