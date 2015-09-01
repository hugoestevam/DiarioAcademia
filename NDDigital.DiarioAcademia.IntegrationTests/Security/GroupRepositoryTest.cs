using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.IntegrationTests.Base;

namespace NDDigital.DiarioAcademia.IntegrationTests.Security
{
    [TestClass]
    public class GroupRepositoryTest : BaseSecurityTest
    {
        const string TestCategory = 
            "Athentication - Group";

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Adicionar_Um_Grupo()
        {
            GroupRepository.Add(ObjectBuilder.CreateGroup());
            
            Uow.Commit();

            var list = GroupRepository.GetAll();

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Excluir_Um_Grupo()
        {
            var group = GroupRepository.GetById(1);

            GroupRepository.Delete(group);

            Uow.Commit();

            var list = GroupRepository.GetAll();

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        [TestCategory("Authorization - Group")]
        public void Deveria_Buscar_Todos_Grupos()
        {
            var list = GroupRepository.GetAll();

            Assert.AreEqual(2, list.Count);
        }
    }
}