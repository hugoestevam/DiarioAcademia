using Infrasctructure.DAO.ORM.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.CepServices;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IAccountRepository
    {
        IList<Account> GetUsersByGroup(Group group);

        IList<Group> GetGroupsByUser(string username);

        IList<Account> GetUsers();

        Account GetUserById(string id);

        Account GetByUserName(string username);

        void Delete(string username);
    }

    public class AccountRepository : UserManager<Account>, IAccountRepository
    {
        private static EntityFrameworkContext _appDbContext;
        public IUserStore<Account> _store { get; set; }

        public AccountRepository(IUserStore<Account> store)
            : base(store)
        {
            _appDbContext = _appDbContext ?? new EntityFrameworkContext();
        }

        public static AccountRepository Create(IdentityFactoryOptions<AccountRepository> options, IOwinContext context)
        {
            _appDbContext = context.Get<EntityFrameworkContext>();
            var userManager = new AccountRepository(new UserStore<Account>(_appDbContext));

            // Configure validation logic for usernames
            userManager.UserValidator = new UserValidator<Account>(userManager)
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
                userManager.UserTokenProvider = new DataProtectorTokenProvider<Account>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return userManager;
        }

        public IList<Account> GetUsersByGroup(Group group)
        {
            var gr = group; //key "group" is reserved
            return (
                from c
                in _appDbContext.Users
                where c.Groups.Any(g => g.Id == gr.Id)
                select c
                ).ToList();
        }

        public IList<Account> GetUsers()
        {
            return (from c
                    in _appDbContext.Users
                    select c
                    ).ToList();
        }

        public Account GetUserById(string id)
        {
            return (from c
                    in _appDbContext.Users.Include(u => u.Groups)
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public Account GetUserByUsername(string username)
        {
            return (from c
                    in (_appDbContext.Users).Include(x => x.Groups)
                    where c.UserName == username
                    select c
                    ).FirstOrDefault();
        }

        public Account GetByUserName(string username)
        {
            return (from c
                     in _appDbContext.Users
                    where c.UserName == username
                    select c).FirstOrDefault();
        }

        public void Delete(string username)
        {
            var user = GetByUserName(username);
            _appDbContext.Users.Remove(user);
        }

        public IList<Group> GetGroupsByUser(string username)
        {
            var user = GetUserByUsername(username);

            if (user != null)

                return user.Groups;

            return new List<Group>();
        }
    }

}