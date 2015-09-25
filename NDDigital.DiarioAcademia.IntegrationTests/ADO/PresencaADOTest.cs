using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.IntegrationTests.Base;

namespace NDDigital.DiarioAcademia.IntegrationTests.ADO
{
    [TestClass]
    public class PresencaADOTest : BaseADOTest
    {
        private const string TestCategory =
            "Teste de Integração - Turma";

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Persistir_Turma_SQL_Test()
        {
            var aluno = AlunoRepository.GetById(1);

            var aula = AulaRepository.GetById(1);

            var presenca = ObjectBuilder.CreatePresenca();

            presenca.Aluno = aluno;
            presenca.Aula = aula;

            PresencaRepository.Add(presenca);

            Uow.Commit();            
        }        
    }
}