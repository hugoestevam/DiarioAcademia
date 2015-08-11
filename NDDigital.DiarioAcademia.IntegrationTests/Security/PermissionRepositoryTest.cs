using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using NDDigital.DiarioAcademia.SecurityTests;
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

            Database.SetInitializer(new BaseTest());
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Adicionar_Uma_Permissao()
        {
            _permissionRepo.Add(ObjectBuilder.CreatePermission());

            var list = _permissionRepo.GetAll();

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Excluir_Uma_Permissao()
        {
            var permissao = _permissionRepo.GetById(1);

            _permissionRepo.Delete(permissao);

            uow.Commit();

            var list = _permissionRepo.GetAll();

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Atualizar_Uma_Permissao()
        {
            var permissao = _permissionRepo.GetById(1);
            permissao.PermissionId = "02";

            _permissionRepo.Update(permissao);

            var permissaoEditada = _permissionRepo.GetById(1);

            Assert.AreEqual("02", permissaoEditada.PermissionId);

            permissaoEditada = _permissionRepo.GetById(2);

            Assert.AreEqual("02", permissaoEditada.PermissionId);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Buscar_Todas_Permissoes()
        {
            var list = _permissionRepo.GetAll();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Buscar_Permissoes_Por_Grupo()
        {

            //arrange
            var administrador = _groupRepo.GetById(1);

            var permissao = ObjectBuilder.CreatePermission();

            administrador.Permissions.Add(permissao);

            uow.Commit();

            //act
            var list = _permissionRepo.GetByGroup(administrador.Id);
            
            //asert
            Assert.AreEqual(1, list.Count);

;        }
    }
}