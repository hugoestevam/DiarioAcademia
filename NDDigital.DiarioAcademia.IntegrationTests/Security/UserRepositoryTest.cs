using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class UserTest
    {
        public IUserRepository _userRepository;
        public IUserStore<User> _store;

        [TestInitialize]
        public void Initialize()
        {
            _userRepository = new UserRepository(_store);
        }

        [TestMethod]
        [Ignore]
        [TestCategory("Athentication")]
        public void Deveria_Adicionar_Um_Usuario()
        {

        }

        [TestMethod]
        [Ignore]
        [TestCategory("Athentication")]
        public void Deveria_Excluir_Um_Usuario()
        {
        }

        [TestMethod]
        [Ignore]
        [TestCategory("Athentication")]
        public void Deveria_Buscar_Todos_Usuarios()
        {
        }

        [TestMethod]
        [Ignore]
        [TestCategory("Athentication")]
        public void Deveria_Buscar_Usuario_Por_Grupo()
        {
        }
    }
}