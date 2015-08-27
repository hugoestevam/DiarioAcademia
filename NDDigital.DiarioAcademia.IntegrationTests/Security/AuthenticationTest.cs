using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class AuthenticationTest
    {
        public IGroupRepository _groupRepo;
        public IPermissionRepository _permissionRepo;
        public UserRepository _userRepo;
        private AuthorizationService _service;
        private AccountRepository _accountRepo;

        public DatabaseFixture databaseFixture = new DatabaseFixture();

        private IUnitOfWork uow;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new BaseTestInitializer());

            var factory = databaseFixture.Factory;

            _groupRepo = new GroupRepository(factory);
            _permissionRepo = new PermissionRepository(factory);

            uow = databaseFixture.UnitOfWork;

            var store = new MyUserStore(factory.Get());

            _userRepo = new UserRepository(store);

            _accountRepo = new AccountRepository(factory);

            _service = new AuthorizationService(_groupRepo, _permissionRepo, _accountRepo, uow);

        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Permissao_ao_Grupo()
        {
            var grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "9" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

            var permission = _permissionRepo.GetByPermissionId("9");

            Assert.IsNotNull(permission);
            Assert.AreEqual("9", permission.PermissionId);

            Assert.AreEqual(3, grupo.Permissions.Count);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Excluir_Permissoes_do_Grupo()
        {
            var grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            var id = grupo.Permissions.First().PermissionId;

            var permissions = new[] { id };

            _service.RemovePermissionsFromGroup(grupo.Id, permissions);

            var permission = _permissionRepo.GetByPermissionId(id);

            Assert.IsNotNull(permission);

            grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            Assert.AreEqual(1, grupo.Permissions.Count);
            Assert.IsFalse(grupo.Permissions.Contains(permission));
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Grupo_ao_Usuario()
        {
            var newGroup = ObjectBuilder.CreateGroup(false);

            _groupRepo.Add(newGroup);

            uow.Commit();

            var account = _accountRepo.GetByUserName("username 1");

            _service.AddGroupToUser(account.Username, new[] { newGroup.Id });

            var user = _userRepo.GetUserByUsername("username 1");

            Assert.AreEqual(3, user.Account.Groups.Count);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Excluir_Grupo_do_Usuario()
        {
            var user = _userRepo.GetUserByUsername("username 1");

            _service.RemoveGroupFromUser(user.UserName, new[] { 1 });

            uow.Commit();

            var acc = _userRepo.GetUserByUsername(user.Account.Username).Account;
            Assert.AreEqual(1,
                 acc.Groups.Count);
           
            Assert.AreEqual(2,
                 acc.Groups.First().Id);
        }
    }
}