using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.CepServices;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IUserRepository
    {
    }

    public class UserRepository : UserManager<User>, IUserRepository
    {
        private  static DiarioAcademiaContext _appDbContext;

        public UserRepository(IUserStore<User> store)
            : base(store)
        {
            _appDbContext = _appDbContext ?? new DiarioAcademiaContext();
        }
        public static UserRepository Create(IdentityFactoryOptions<UserRepository> options, IOwinContext context)
        {
            _appDbContext = context.Get<DiarioAcademiaContext>();
            var userManager = new UserRepository(new UserStore<User>(_appDbContext));

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

        public IList<User> GetUsersByGroup(Group group)
        {
            var gr = group; //key "group" is reserved
            return (
                from c
                in _appDbContext.Users
                where c.Groups.Any(g => g.Id == gr.Id)
                select c
                ).ToList();

        }
        public IList<User> GetUsers()
        {
            return _appDbContext.Users.ToList();
        }
    }
    //recurso: não temos uma implementação de IUserStore: http://weblogs.asp.net/imranbaloch/a-simple-implementation-of-microsoft-aspnet-identity
    public class MyUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>, IQueryableUserStore<User>
    {
        UserStore<IdentityUser> userStore;

        public IQueryable<User> Users
        {
            get
            {
                return (userStore.Context as DiarioAcademiaContext).Users;
            }
        }

        public MyUserStore(DiarioAcademiaContext context)
        {
            
            userStore = new UserStore<IdentityUser>(context);
        }
        public Task CreateAsync(User user)
        {
            var context = userStore.Context as DiarioAcademiaContext;
            context.Users.Add(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }
        public Task DeleteAsync(User user)
        {
            var context = userStore.Context as DiarioAcademiaContext;

            var userLocated = context.Users.First(u=>u.UserName==user.UserName);

            context.Users.Remove(userLocated);
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }
        public Task<User> FindByIdAsync(string userId)
        {
            var context = userStore.Context as DiarioAcademiaContext;
            return context.Users.Where(u => u.Id.ToLower() == userId.ToLower()).FirstOrDefaultAsync();
        }
        public Task<User> FindByNameAsync(string userName)
        {
            var context = userStore.Context as DiarioAcademiaContext;
            return context.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }
        public Task UpdateAsync(User user)
        {
            var context = userStore.Context as DiarioAcademiaContext;
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }
        public void Dispose()
        {
            userStore.Dispose();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetPasswordHashAsync(identityUser);
            SetUser(user, identityUser);
            return task;
        }
        public Task<bool> HasPasswordAsync(User user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.HasPasswordAsync(identityUser);
            SetUser(user, identityUser);
            return task;
        }
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);
            SetUser(user, identityUser);
            return task;
        }
        public Task<string> GetSecurityStampAsync(User user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetSecurityStampAsync(identityUser);
            SetUser(user, identityUser);
            return task;
        }
        public Task SetSecurityStampAsync(User user, string stamp)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetSecurityStampAsync(identityUser, stamp);
            SetUser(user, identityUser);
            return task;
        }
        private static void SetUser(User user, IdentityUser identityUser)
        {
            user.PasswordHash = identityUser.PasswordHash;
            user.SecurityStamp = identityUser.SecurityStamp;
            user.Id = identityUser.Id;
            user.UserName = identityUser.UserName;
        }
        private IdentityUser ToIdentityUser(User user)
        {
            return new IdentityUser
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName
            };
        }

        public Task<User> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }


}