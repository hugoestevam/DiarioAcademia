using Infrasctructure.DAO.ORM.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.CepServices;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{

    public class UserRepository : UserManager<User>, IUserRepository
    {
        private static EntityFrameworkContext dataContext;
        private static EntityFrameworkFactory _databaseFactory;
        public IUserStore<User> _store { get; set; }

        public UserRepository(IUserStore<User> store, EntityFrameworkFactory databaseFactory) 
            : base(store)
        {
            _databaseFactory = databaseFactory;
            dataContext = dataContext ?? (databaseFactory.Get());
        }

        public static UserRepository Create(IdentityFactoryOptions<UserRepository> options, IOwinContext context)
        {
            dataContext = dataContext ?? context.Get<EntityFrameworkContext>();
            var userManager = new UserRepository(new UserStore<User>(), _databaseFactory);

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

        public void AddUser(User user)
        {
            var dbuser = dataContext.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();

            if (dbuser != null)
                throw new ApplicationException("UsernameJaExisteException");
            dataContext.Users.Add(user);
            dataContext.SaveChanges();//TODO: rever pq factory static not works
        }

        public IList<User> GetUsersByGroup(Group group)
        {
            var gr = group; //key "group" is reserved
            return (
                from c
                in dataContext.Users
                where c.Account.Groups.Any(g => g.Id == gr.Id)
                select c
                ).ToList();
        }

        public IList<User> GetUsers()
        {
            return (from c
                    in dataContext.Users
                    select c
                    ).ToList();
        }

        public User GetUserById(string id)
        {
            return (from c
                    in dataContext.Users.Include(u => u.Account)
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return (from c
                    in (dataContext.Users).Include(x => x.Account).Include(x=>x.Account.Groups)
                    where c.UserName == username
                    select c
                    ).FirstOrDefault();
        }

        public void Delete(string username)
        {
            var user = GetUserByUsername(username);
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();

        }

        public IList<Group> GetGroupsByUser(string username)
        {
            var user = GetUserByUsername(username);

            if (user != null && user.Account != null)

                return user.Account.Groups;

            return new List<Group>();


           // return user?.Account?.Groups ?? new List<Group>();  todo: c# 6

        }

     
    }

}