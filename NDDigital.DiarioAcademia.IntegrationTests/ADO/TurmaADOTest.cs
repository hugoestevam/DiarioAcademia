using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.IntegrationTests.Base;

namespace NDDigital.DiarioAcademia.IntegrationTests.ADO
{
    [TestClass]
    public class TurmaADOTest: BaseADOTest
    {
        private const string TestCategory = 
            "Teste de Integração Turma";

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Persistir_Turma_SQL_Test()
        {
            var turma = ObjectBuilder.CreateTurma();

            TurmaRepository.Add(turma);

            var qtdTurmas = TurmaRepository.GetAll().Count;

            Uow.Commit();

            Assert.AreEqual(2, qtdTurmas);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Turma_SQL_Test()
        {
            var turmaEncontrada = TurmaRepository.GetById(1);

            Assert.IsNotNull(turmaEncontrada);
            Assert.AreEqual(1, turmaEncontrada.Id);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Editar_Turma_SQL_Test()
        {
            var turmaEncontrada = TurmaRepository.GetById(1);
            turmaEncontrada.Ano = 2016;

            TurmaRepository.Update(turmaEncontrada);

            var turmaEditada = TurmaRepository.GetById(1);

            Uow.Commit();

            Assert.AreEqual(2016, turmaEditada.Ano);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Todas_Turmas_SQL_Test()
        {
            var turmasEncontradas = TurmaRepository.GetAll();

            Assert.IsTrue(turmasEncontradas.Count > 0);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Remover_Turma_SQL_Test()
        {
            var turma = ObjectBuilder.CreateTurma();

            TurmaRepository.Add(turma);

            var qtdTurmas = TurmaRepository.GetAll().Count;

            Assert.AreEqual(2, qtdTurmas);

            TurmaRepository.Delete(2);

            qtdTurmas = TurmaRepository.GetAll().Count;

            Uow.Commit();

            Assert.AreEqual(1, qtdTurmas);
        }
    }
}