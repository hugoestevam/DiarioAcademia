using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using NDDigital.DiarioAcademia.SecurityTests;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
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

        public DatabaseFixture databaseFixture = new DatabaseFixture();

        private IUnitOfWork uow;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new BaseTest());

            _groupRepo = new GroupRepository(databaseFixture.Factory);
            _permissionRepo = new PermissionRepository(databaseFixture.Factory);

            uow = databaseFixture.UnitOfWork;

            var store = new MyUserStore(databaseFixture.Factory.Get());

            _userRepo = new UserRepository(store);

            _service = new AuthorizationService(_groupRepo, _permissionRepo, _userRepo, uow);

            var user = ObjectBuilder.CreateUser();

            _userRepo.Create(user);
            
            uow.Commit();

        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Permissao_ao_Grupo()
        {


            var grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "03" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

            uow.Commit();

            var permission = _permissionRepo.GetByPermissionId("03");

            Assert.IsNotNull(permission);
            Assert.AreEqual("03", permission.PermissionId);

            Assert.AreEqual(3, grupo.Permissions.Count);

        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Excluir_Permissoes_do_Grupo()
        {
            var grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "03" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

            uow.Commit();

            var removedPermissions = new[] { "01", "03" };


            _service.RemovePermissionsFromGroup(grupo.Id, removedPermissions);

            var permission = _permissionRepo.GetByPermissionId("02");

            uow.Commit();

            Assert.IsNotNull(permission);
            Assert.AreEqual("02", permission.PermissionId);

            Assert.AreEqual(1, grupo.Permissions.Count);
        }
        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Grupo_ao_Usuario()
         {
            var user = _userRepo.GetUserByUsername("ttt");

           _service.AddGroupToUser(user.UserName, new[] {1});

            uow.Commit();
            var userAgain = _userRepo.GetUserByUsername("ttt");

             Assert.AreEqual(3, userAgain.Groups.Count);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Excluir_Grupo_do_Usuario()
        {
            var grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "03" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

            uow.Commit();

            var removedPermissions = new[] { "01", "03" };


            _service.RemovePermissionsFromGroup(grupo.Id, removedPermissions);

            var permission = _permissionRepo.GetByPermissionId("02");

            uow.Commit();

            Assert.IsNotNull(permission);
            Assert.AreEqual("02", permission.PermissionId);

            Assert.AreEqual(1, grupo.Permissions.Count);
        }

    }
}