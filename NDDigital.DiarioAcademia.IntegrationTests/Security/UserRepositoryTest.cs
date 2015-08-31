using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using System;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class UserTest
    {
        public UserRepository _userRepository;
        public IAccountRepository _accountRepository;
        public IGroupRepository _groupRepository;
        public IUserStore<User> _store;
        private IUnitOfWork uow;
        private User _user;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new BaseTestInitializer());

            ObjectBuilder.Reset();

            var fixture = new DatabaseFixture();

            var factory = fixture.Factory;

            var context = factory.Get();

            uow = fixture.UnitOfWork;

            _store = new MyUserStore(context);
            _userRepository = new UserRepository(_store,factory);
            _groupRepository = new GroupRepository(factory);
            _accountRepository = new AccountRepository(factory);

        }

       

        [TestMethod]
        [TestCategory("Athentication - User")]
        [ExpectedException(typeof(ApplicationException))]
        public void Nao_Deveria_Adicionar_Um_Usuario_Repetido()
        {
            var user = ObjectBuilder.CreateUser(full: false);

            var dbuser = _userRepository.GetUsers().First();

            user.UserName = dbuser.UserName;

            _userRepository.AddUser(user);

        }
[TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Adicionar_Um_Usuario()
        {
            var user = ObjectBuilder.CreateUser(full: false);

            user.UserName = user.Account.Username="New username";

            _userRepository.AddUser(user);

            uow.Commit();

            var user2 = _userRepository.GetUserByUsername(user.UserName);

            Assert.IsNotNull(user2);

            Assert.AreEqual(user.FirstName, user2.FirstName);
        }
        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Excluir_Um_Usuario()
        {
            var user = _userRepository.Users.First();

            _userRepository.Delete(user);

            var count = _userRepository.Users.ToList().Count;

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Buscar_Todos_Usuarios()
        {

            var count = _userRepository.GetUsers().Count;

            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        [TestCategory("Athentication - User")]
        public void Deveria_Buscar_Usuario_Por_Grupo()
        {
            var grupo = _groupRepository.GetAll().First();

            var users = _userRepository.GetUsersByGroup(grupo);


            Assert.AreEqual(1,users.Count);


        } 
    }
}