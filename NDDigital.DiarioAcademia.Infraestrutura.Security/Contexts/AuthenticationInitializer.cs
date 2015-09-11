using Ellevo.Biblioteca.Seguranca;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contexts
{
    public class AuthenticationInitializer : DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            Group group;
            base.Seed(context);
            if (context.Groups.Count() == 0)
            {
                group = new Group { Name = "Administration", IsAdmin = true };
                context.Groups.Add(group);
                if (context.Accounts.Count() == 0)
                {
                    var user = new User
                    {
                        UserName = "superadmin",
                        PasswordHash = Criptografia.Criptografar("174963"),
                        Account = new Account("superadmin"),
                        FirstName = "admin",
                        LastName = "admin"

                    };
                    user.Account.Groups = new List<Group>();
                    user.Account.Groups.Add(group);
                    context.Users.Add(user);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}",
                                                        validationError.PropertyName,
                                                        validationError.ErrorMessage);
                            }
                        }
                    }
                }
            }

        }
    }
}
