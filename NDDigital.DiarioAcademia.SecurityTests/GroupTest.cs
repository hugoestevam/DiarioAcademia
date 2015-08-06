using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Security;

namespace NDDigital.DiarioAcademia.SecurityTests
{
    [TestClass]
    public class GroupTest
    {
        public IGroupRepository _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new GroupRepository();
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Adicionar_Um_Grupo()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Excluir_Um_Grupo()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Buscar_Todos_Grupos()
        {
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Adicionar_Prermissoes_do_Grupo()
        {
            //Deve receber o Id do grupo
            //E um array de string
        }

        [TestMethod]
        [TestCategory("Authorization")]
        public void Deveria_Excluir_Prermissoes_do_Grupo()
        {
            //Deve receber o Id do grupo
            //E um array de string
        }
    }
}
