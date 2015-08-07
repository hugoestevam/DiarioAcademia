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
        public IPermissionRepository _repo;

        private IUnitOfWork uow;

        public DatabaseFixture databaseFixture = new DatabaseFixture();

        [TestInitialize]
        public void Initialize()
        {
            _repo = new PermissionRepository(databaseFixture.Factory);
            uow = databaseFixture.UnitOfWork;

            Database.SetInitializer(new BaseTest());
        }


        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Adicionar_Uma_Permissao()
        {
            _repo.Add(ObjectBuilder.CreatePermission());

            var list = _repo.GetAll();

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Excluir_Uma_Permissao()
        {
            var permissao = _repo.GetById(1);

            _repo.Delete(permissao);

            uow.Commit();

            var list = _repo.GetAll();

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Atualizar_Uma_Permissao()
        {
            var permissao = _repo.GetById(1);
            permissao.PermissionId = "02";

            _repo.Update(permissao);

            var permissaoEditada = _repo.GetById(1);

            Assert.AreEqual("02", permissaoEditada.PermissionId);

            permissaoEditada = _repo.GetById(2);

            Assert.AreEqual("02", permissaoEditada.PermissionId);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Buscar_Todas_Permissoes()
        {
            var list = _repo.GetAll();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        [TestCategory("Authorization - Permission")]
        public void Deveria_Buscar_Permissoes_Por_Grupo()
        {
            //var administrador = _repo.GetById(1);

            //_repo.GetByGroup(administrador);

            //var list = _repo.GetAll();

            //Assert.AreEqual(1, list.Count);
        }
    }
}