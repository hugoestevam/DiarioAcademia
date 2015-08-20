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
using System.Diagnostics;
using System.Text;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IUserRepository
    {
        IList<User> GetUsersByGroup(Group group);
        IList<Group> GetGroupsByUser(string username);
        IList<User> GetUsers();
        User GetUserById(string id);
        User GetByUserName(string username);
        void Delete(string username);
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
            return (from c 
                    in _appDbContext.Users
                    select c
                    ).ToList();
        }


        public User GetUserById(string id)
        {
            return (from c
                    in _appDbContext.Users.Include(u=>u.Groups)
                    where c.Id == id
                    select c).FirstOrDefault(); ;
        }

        public User GetUserByUsername(string username)
        {
            return (from c 
                    in (_appDbContext.Users.Include(u => u.Groups))
                    where c.UserName==username
                    select c
                    ).FirstOrDefault();
        }

        public User GetByUserName(string username)
        {
           return (from c 
                    in _appDbContext.Users
                    where c.UserName==username
                   select c).First();
        }

        public void Delete(string username)
        {
            var user = GetByUserName(username);
            _appDbContext.Users.Remove(user);
        }

        public IList<Group> GetGroupsByUser(string username)
        {
            throw new NotImplementedException();
        }
    }
    //recurso: não temos uma implementação de IUserStore: http://weblogs.asp.net/imranbaloch/a-simple-implementation-of-microsoft-aspnet-identity
    public class MyUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>, IQueryableUserStore<User>
    {
        UserStore<IdentityUser> userStore;
        DiarioAcademiaContext _context;

        public IQueryable<User> Users
        {
            get
            {
                return (userStore.Context as DiarioAcademiaContext).Users;
            }
        }

        public MyUserStore(DiarioAcademiaContext context)
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
          
            var userLocated = _context.Users.First(u=>u.UserName==user.UserName);

            _context.Users.Remove(userLocated);
            _context.Configuration.ValidateOnSaveEnabled = false;
            return _context.SaveChangesAsync();
        }
        public Task<User> FindByIdAsync(string userId)
        {
            return _context.Users.Where(u => u.Id.ToLower() == userId.ToLower()).FirstOrDefaultAsync();
        }
        public Task<User> FindByNameAsync(string userName)
        {
             return _context.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }
        public Task UpdateAsync(User user)
        {
            var entry = _context.Entry(user);
            // if (entry.State == EntityState.Detached)
            // {
            //    context.Detach(user);
            // }
            // _context.Users.Attach(user);
            foreach(var group in user.Groups)
            {
                var groupEntry = _context.Entry(group);

                if (groupEntry.State == EntityState.Unchanged) { 
                    groupEntry.State=EntityState.Modified;      //1st try
                    //context.Groups.Attach(group);              //2nd try
                    //groupEntry.State = EntityState.Detached;  //3rd try 
                }
            }
           // entry.State = EntityState.Modified;


            _context.SaveChanges();

            //context.Entry(user).State = EntityState.Modified;
            //context.Configuration.ValidateOnSaveEnabled = false;
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




        //Just for debug, call in Imediate Window
        private string LogEntry(User user, DiarioAcademiaContext ctx)
        {
            var sb = new StringBuilder(user.ToString());

            sb.Append(" - " + ctx.Entry(user).State);

            foreach (var g in user.Groups)
                sb.Append("{" + g.Name + " - [" + ctx.Entry(g).State + "]}");
            return sb.ToString();
        }


    }


}