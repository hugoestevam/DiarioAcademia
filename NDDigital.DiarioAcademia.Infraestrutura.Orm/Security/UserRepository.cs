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
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;


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
        private static DiarioAcademiaContext _appDbContext;
        public IUserStore<User> _store { get; set; }

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
                    in _appDbContext.Users.Include(u => u.Groups)
                    where c.Id == id
                    select c).FirstOrDefault();
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
                    where c.UserName == username
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
   


}