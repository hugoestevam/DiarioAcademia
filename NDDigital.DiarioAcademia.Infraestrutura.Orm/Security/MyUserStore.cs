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

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public class MyAccountStore : IUserStore<Account>, IUserPasswordStore<Account>, IUserSecurityStampStore<Account>, IQueryableUserStore<Account>
    {
        private UserStore<IdentityUser> userStore;
        private EntityFrameworkContext _context;

        public IQueryable<Account> Users
        {
            get
            {
                return (userStore.Context as EntityFrameworkContext).Users;
            }
        }

        public MyAccountStore(EntityFrameworkContext context)
        {
            userStore = new UserStore<IdentityUser>(_context = context);
        }

        public Task CreateAsync(Account user)
        {
            _context.Users.Add(user);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Account user)
        {
            var userLocated = _context.Users.First(u => u.UserName == user.UserName);
            _context.Users.Remove(userLocated);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }

        public Task<Account> FindByIdAsync(string userId)
        {
            return _context.Users.Where(u => u.Id.ToLower() == userId.ToLower()).FirstOrDefaultAsync();
        }

        public Task<Account> FindByNameAsync(string userName)
        {
            return _context.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }

        //TODO: rever implementação (possivel chance de gambi pattern XGH)
        public Task UpdateAsync(Account user)
        {
            var context = userStore.Context as EntityFrameworkContext;

            var set = context.Users.Include(u => u.Groups).SingleOrDefault(u => u.Id == user.Id); // get o do banco
            context.Entry(set).CurrentValues.SetValues(user); // atualiza as propriedades simples
            set.Groups = set.Groups.Concat(user.Groups).ToList(); // atualiza a colletion de group

            context.SaveChanges(); // save
            return context.SaveChangesAsync();

        }

        public void Dispose()
        {
            userStore.Dispose();
        }

        public Task<string> GetPasswordHashAsync(Account user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetPasswordHashAsync(identityUser);
            SetUser(user, identityUser);
            return task;
        }

        public Task<bool> HasPasswordAsync(Account user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.HasPasswordAsync(identityUser);
            SetUser(user, identityUser);
            return task;
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);
            SetUser(user, identityUser);
            return task;
        }

        public Task<string> GetSecurityStampAsync(Account user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetSecurityStampAsync(identityUser);
            SetUser(user, identityUser);
            return task;
        }

        public Task SetSecurityStampAsync(Account user, string stamp)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetSecurityStampAsync(identityUser, stamp);
            SetUser(user, identityUser);
            return task;
        }

        private static void SetUser(Account user, IdentityUser identityUser)
        {
            user.PasswordHash = identityUser.PasswordHash;
            user.SecurityStamp = identityUser.SecurityStamp;
            user.Id = identityUser.Id;
            user.UserName = identityUser.UserName;
        }

        private IdentityUser ToIdentityUser(Account user)
        {
            return new IdentityUser
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName
            };
        }

        public Task<Account> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        [DebuggerStepThrough]
        //Just for debug, call in Imediate Window
        private string LogEntry(Account user, EntityFrameworkContext ctx)
        {
            var sb = new StringBuilder(user.ToString());

            sb.Append(" - " + ctx.Entry(user).State);

            foreach (var g in user.Groups) sb.Append("  {" + g.Name + " - [" + ctx.Entry(g).State + "]}");
            return sb.ToString();
        }
    }
}