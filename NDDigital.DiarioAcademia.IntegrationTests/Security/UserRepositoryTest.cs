using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using NDDigital.DiarioAcademia.SecurityTests;
using System.Linq;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class UserTest
    {
        public UserRepository _userRepository;
        public GroupRepository _groupRepository;
        public IUserStore<User> _store;
        private IUnitOfWork uow;
        private User _user;
        public const string SqlCleanDB = @"DBCC CHECKIDENT ('[TBPresenca]', RESEED, 0) DBCC CHECKIDENT ('[TBAula]', RESEED, 0) DBCC CHECKIDENT ('[TBAluno]', RESEED, 0)DBCC CHECKIDENT ('[TBTurma]', RESEED, 0)DBCC CHECKIDENT ('[TBGroup]', RESEED, 0)DBCC CHECKIDENT ('[TBPermission]', RESEED, 0)DELETE FROM TBPresenca DELETE FROM TBAula DELETE FROM TBAluno DELETE FROM TBTurma DELETE FROM TBUserGroups DELETE FROM TBGroupPermission DELETE FROM TBGroup DELETE FROM TBPermission DELETE FROM TBUser";

        [TestInitialize]
        public void Initialize()
        {

            var fixture = new DatabaseFixture();

            var factory = fixture.Factory;

            var context = factory.Get();

            uow = fixture.UnitOfWork;

            _store = new MyUserStore(context);
            _userRepository = new UserRepository(_store);
            _groupRepository = new GroupRepository(fixture.Factory);


            _user = ObjectBuilder.CreateUser();

            context.Database.ExecuteSqlCommand(SqlCleanDB);
            context.SaveChanges();

            _userRepository.Create(_user);
           // uow.Commit();

        }

        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Adicionar_Um_Usuario()
        {
            //var user = ObjectBuilder.CreateUser();
            var user = new User {
                FirstName ="Wesley",
                LastName="Lemos",
                UserName="anisan"
            };

            var username = user.UserName += '2';


            _userRepository.Create(user);

           // uow.Commit();

            var user2 =_userRepository.FindByName(username);

            Assert.AreEqual(user.FirstName, user2.FirstName);
        }

        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Excluir_Um_Usuario()
        {
            var user = _userRepository.Users.First();
                
            _userRepository.Delete(user);

            //uow.Commit();

            var count = _userRepository.Users.ToList().Count;

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Buscar_Todos_Usuarios()
        {
            var count = _userRepository.Users.ToList().Count;

            Assert.IsTrue(count>0);
        }

        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Buscar_Usuario_Por_Grupo()
        {
            var grupo = _user.Groups.First();

            _groupRepository.Add(grupo);

            uow.Commit();
            
            _user.Groups.Add(grupo);

           // uow.Commit();

            var users = _userRepository.GetUsersByGroup(grupo);

            var count = users.Count;

            Assert.IsTrue(count > 0);


        }
    }

 
}