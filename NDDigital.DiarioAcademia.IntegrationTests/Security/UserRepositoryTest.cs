using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using System;
using System.Data.Entity;
using System.Linq;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class UserTest:BaseSecurityTest
    {
        const string TestCategory = "Athentication - User";

        [TestMethod]
        [TestCategory(TestCategory)]
        [ExpectedException(typeof(ApplicationException))]
        public void Nao_Deveria_Adicionar_Um_Usuario_Repetido()
        {
            var user = ObjectBuilder.CreateUser(full: false);

            var dbuser = UserRepository.GetUsers().First();

            user.UserName = dbuser.UserName;

            UserRepository.AddUser(user);

        }
        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Adicionar_Um_Usuario()
        {
            var user = ObjectBuilder.CreateUser(full: false);

            user.UserName = user.Account.Username="New username";

            UserRepository.AddUser(user);

            Uow.Commit();

            var user2 = UserRepository.GetUserByUsername(user.UserName);

            Assert.IsNotNull(user2);

            Assert.AreEqual(user.FirstName, user2.FirstName);
        }
        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Excluir_Um_Usuario()
        {
            var user = UserRepository.GetUsers().First();

            UserRepository.Delete(user.UserName);

            var count = UserRepository.GetUsers().ToList().Count;

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Todos_Usuarios()
        {

            var count = UserRepository.GetUsers().Count;

            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Usuario_Por_Grupo()
        {
            var grupo = GroupRepository.GetAll().First();

            var users = UserRepository.GetUsersByGroup(grupo);


            Assert.AreEqual(1,users.Count);


        } 
    }
}