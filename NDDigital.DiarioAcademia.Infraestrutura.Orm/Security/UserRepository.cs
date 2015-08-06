using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.CepServices;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public class UserRepository : UserManager<User>
    {
        public UserRepository(IUserStore<User> store)
            : base(store)
        {
        }

        public static UserRepository Create(IdentityFactoryOptions<UserRepository> options, IOwinContext context)
        {
            var appDbContext = context.Get<AuthenticationContext>();
            var userManager = new UserRepository(new UserStore<User>(appDbContext));

            // Configure validation logic for usernames
            userManager.UserValidator = new UserValidator<User>(userManager)
            {
                AllowOnlyAlphanumericUserNames = true
            };

            // Configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            userManager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return userManager;
        }
    }
}