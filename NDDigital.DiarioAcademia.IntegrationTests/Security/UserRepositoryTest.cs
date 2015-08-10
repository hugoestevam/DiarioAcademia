using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using Microsoft.AspNet.Identity;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NDDigital.DiarioAcademia.SecurityTests
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
        [TestCategory("Athentication")]
        public void Deveria_Adicionar_Um_Usuario()
        {
        }

        [TestMethod]
        [TestCategory("Athentication")]
        public void Deveria_Excluir_Um_Usuario()
        {
        }

        [TestMethod]
        [TestCategory("Athentication")]
        public void Deveria_Buscar_Todos_Usuarios()
        {
        }

        [TestMethod]
        [TestCategory("Athentication")]
        public void Deveria_Buscar_Usuario_Por_Grupo()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Adicionar_Grupos_ao_Usuario()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Excluir_Grupos_de_Usuario()
        {
        }
    }
}
