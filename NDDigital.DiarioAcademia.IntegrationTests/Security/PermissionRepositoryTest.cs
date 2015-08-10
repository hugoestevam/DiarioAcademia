using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;

namespace NDDigital.DiarioAcademia.SecurityTests
{
    [TestClass]
    public class PermissionRepositoryTest
    {
        public IPermissionRepository _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new PermissionRepository();
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Adicionar_Uma_Permissao()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Excluir_Uma_Permissao()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Buscar_Todas_Permissoes()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Buscar_Permissoes_Por_Grupo()
        {
        }
    }
}