using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services;
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

            var user = new User
            {
                FirstName = "Wesley",
                LastName = "Lemos",
                UserName = "anisan",
            };

            _userRepo.Create(user);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Permissao_ao_Grupo()
        {
            var grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "03" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

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

            var removedPermissions = new[] { "01", "03" };

            _service.RemovePermissionsFromGroup(grupo.Id, removedPermissions);

            var permission = _permissionRepo.GetByPermissionId("02");

            Assert.IsNotNull(permission);

            grupo = _groupRepo.GetByIdIncluding(2, g => g.Permissions);

            Assert.AreEqual(1, grupo.Permissions.Count);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Grupo_ao_Usuario()
        {
            var user = _userRepo.GetUserByUsername("anisan");

            _service.AddGroupToUser(user.UserName, new[] { 1 });

            var userAgain = _userRepo.GetUserByUsername("anisan");

            Assert.AreEqual(2, userAgain.Groups.Count);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Excluir_Grupo_do_Usuario()
        {
            var user = _userRepo.GetUserByUsername("anisan");

            _service.AddGroupToUser(user.UserName, new[] { 1, 2 });

            user = _userRepo.GetUserByUsername("anisan");

            Assert.AreEqual(2,
                 user.Groups.Count);

            _service.RemoveGroupFromUser(user.UserName, new[] { 1 });

            user = _userRepo.GetUserByUsername("anisan");
            Assert.AreEqual(1,
                 user.Groups.Count);

            Assert.AreEqual(2,
                 user.Groups.First().Id);
        }
    }
}