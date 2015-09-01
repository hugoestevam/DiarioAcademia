using Infrasctructure.DAO.ORM.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    //recurso:http://weblogs.asp.net/imranbaloch/a-simple-implementation-of-microsoft-aspnet-identity
    public class IdentityUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>, IQueryableUserStore<User>
    {
        private UserStore<IdentityUser> userStore;
        private static EntityFrameworkContext _context;

        public IQueryable<User> Users
        {
            get
            {
                return (userStore.Context as EntityFrameworkContext).Users;
            }
        }

        public IdentityUserStore(EntityFrameworkContext context)
        {
            userStore = new UserStore<IdentityUser>(_context = context);
        }

        public Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(User user)
        {
            var userLocated = _context.Users.First(u => u.UserName == user.UserName);
            _context.Users.Remove(userLocated);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return _context.Users.AsNoTracking().Where(u => u.Id.ToLower() == userId.ToLower()).FirstOrDefaultAsync();
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return _context.Users.AsNoTracking()
                .Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }

        //TODO: rever implementação (possivel chance de gambi pattern XGH)
        public Task UpdateAsync(User user)
        {
            var context = userStore.Context as EntityFrameworkContext;

            DbEntityEntry dbEntityEntry = _context.Entry(user);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _context.Users.Attach(user);
            }
            dbEntityEntry.State = EntityState.Modified;

            _context.SaveChanges();

            return _context.SaveChangesAsync();

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
