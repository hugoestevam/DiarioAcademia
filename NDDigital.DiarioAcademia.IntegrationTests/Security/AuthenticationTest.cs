using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using NDDigital.DiarioAcademia.SecurityTests;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class AuthenticationTest
    {
        public IGroupRepository _repoGroup;
        public IPermissionRepository _repoPermission;
        private AuthorizationService _service;

        public DatabaseFixture databaseFixture = new DatabaseFixture();

        private IUnitOfWork uow;

        [TestInitialize]
        public void Initialize()
        {
            _repoGroup = new GroupRepository(databaseFixture.Factory);
            _repoPermission = new PermissionRepository(databaseFixture.Factory);

            uow = databaseFixture.UnitOfWork;



            var store = new MyUserStore(databaseFixture.Factory.Get());

            var userRepository = new UserRepository(store);

            _service = new AuthorizationService(_repoGroup, _repoPermission, userRepository, uow);

            Database.SetInitializer(new BaseTest());
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Adicionar_Permissao_ao_Grupo()
        {

            var grupo = _repoGroup.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "03" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

            uow.Commit();

            var permission = _repoPermission.GetByPermissionId("03");

            Assert.IsNotNull(permission);
            Assert.AreEqual("03", permission.PermissionId);

            Assert.AreEqual(3, grupo.Permissions.Count);

        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void Deveria_Excluir_Permissoes_do_Grupo()
        {
            var grupo = _repoGroup.GetByIdIncluding(2, g => g.Permissions);

            var permissions = new[] { "03" };

            _service.AddPermissionsToGroup(grupo.Id, permissions);

            uow.Commit();

            var removedPermissions = new[] { "01", "03" };


            _service.RemovePermissionsFromGroup(grupo.Id, removedPermissions);

            var permission = _repoPermission.GetByPermissionId("02");

            uow.Commit();

            Assert.IsNotNull(permission);
            Assert.AreEqual("02", permission.PermissionId);

            Assert.AreEqual(1, grupo.Permissions.Count);
        }

    }
}