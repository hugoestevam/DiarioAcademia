using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class PermissionRepositoryTest
    {
        public IPermissionRepository _permissionRepo;
        public IGroupRepository _groupRepo;

        private IUnitOfWork uow;

        public DatabaseFixture databaseFixture = new DatabaseFixture();

        [TestInitialize]
        public void Initialize()
        {
            _permissionRepo = new PermissionRepository(databaseFixture.Factory);
            _groupRepo = new GroupRepository(databaseFixture.Factory);
            uow = databaseFixture.UnitOfWork;

            Database.SetInitializer(new BaseTestInitializer());
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Adicionar_Uma_Permissao()
        {
            _permissionRepo.Add(ObjectBuilder.CreatePermission());
            uow.Commit();

            var list = _permissionRepo.GetAll();

            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Excluir_Uma_Permissao()
        {
            var permissao = _permissionRepo.GetById(1);

            _permissionRepo.Delete(permissao);

            uow.Commit();

            var list = _permissionRepo.GetAll();

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Atualizar_Uma_Permissao()
        {
            var permissao = _permissionRepo.GetById(1);
            permissao.PermissionId = "02";

            _permissionRepo.Update(permissao);

            uow.Commit();

            var permissaoEditada = _permissionRepo.GetById(1);

            Assert.AreEqual("02", permissaoEditada.PermissionId);

        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Buscar_Todas_Permissoes()
        {
            var list = _permissionRepo.GetAll();

            Assert.IsNotNull(list);
            Assert.AreEqual(4,list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Buscar_Permissoes_Por_Grupo()
         {
            var administrador = _groupRepo.GetById(1);

            var permissao = ObjectBuilder.CreatePermission();

            administrador.Permissions.Add(permissao);

            uow.Commit();

            var adminPermissions = _permissionRepo.GetByGroup(administrador.Id);

            Assert.AreEqual(3, adminPermissions.Count);

            var allPermissions = _permissionRepo.GetAll();

            Assert.AreEqual(5, allPermissions.Count);
        }
    }
}