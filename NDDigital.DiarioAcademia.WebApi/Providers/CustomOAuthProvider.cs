using Ellevo.Biblioteca.Seguranca;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.WebApi.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        private AuthorizationService _authservice;
        private PermissionService _permissionService;

        public CustomOAuthProvider()
        {
            var unitOfWork = Injection.Get<IUnitOfWork>();

            var groupRepository = Injection.Get<IGroupRepository>();

            var permissionRepository = Injection.Get<IPermissionRepository>();

            var store = Injection.Get<IUserStore<User>>();// var store = new MyUserStore(factory.Get());

            var accountRepository = Injection.Get<IAccountRepository>(); // var accountRepository = new AccountRepository(factory);            

            _authservice = new AuthorizationService(groupRepository, permissionRepository, accountRepository, unitOfWork);

            _permissionService = new PermissionService(permissionRepository,unitOfWork);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userRepository = context.OwinContext.GetUserManager<UserRepository>();

            User user = userRepository.GetUserByUsername(context.UserName);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name is incorrect.");
                return;
            }

            var hash = Criptografia.Descriptografar(user.PasswordHash);
            if (context.Password != hash)
            {
                context.SetError("invalid_grant", "The password is incorrect.");
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }


            //ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userRepository, "JWT");

            var permissions = _permissionService.GetByUser(context.UserName);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("user", context.UserName));

            foreach (var p in permissions)
                identity.AddClaim(new Claim("claim",p.PermissionId));
            // var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(identity);

           // Task.FromResult<object>(null);
        }
    }
}