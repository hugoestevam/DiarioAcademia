using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using NDDigital.DiarioAcademia.SecurityTests;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class GroupRepositoryTest
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

            _service = new AuthorizationService(_repoGroup, _repoPermission, uow);

            Database.SetInitializer(new BaseTest());
        }

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Adicionar_Um_Grupo()
        {
            _repoGroup.Add(ObjectBuilder.CreateGroup());

            uow.Commit();

            var list = _repoGroup.GetAll();

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Excluir_Um_Grupo()
        {
            var group = _repoGroup.GetById(1);

            _repoGroup.Delete(group);

            uow.Commit();

            var list = _repoGroup.GetAll();

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Buscar_Todos_Grupos()
        {
            var list = _repoGroup.GetAll();

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Adicionar_Prermissoes_do_Grupo()
        {
            //Deve receber o Id do grupo
            //E um array de string
            var group = _repoGroup.GetById(1);

            Assert.IsTrue(group.Permissions.Count == 0);

            _service.AddPermissionsGroup(1);

            group = _repoGroup.GetById(1);

            Assert.IsTrue(group.Permissions.Count > 0);
        }
    }
}