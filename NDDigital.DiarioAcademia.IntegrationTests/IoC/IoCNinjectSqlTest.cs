using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.IntegrationTests.Base;

namespace NDDigital.DiarioAcademia.IntegrationTests.IoC
{
    [TestClass]
    public class IoCNinjectSqlTest
    {
        [TestMethod]
        [TestCategory("Teste de IoC")]
        public void Save_Turma_IoC_SQL_Test()
        {
            Turma t = ObjectBuilder.CreateTurma();

            //Através do IoC Ninject busca um implementação do Repositório
            ITurmaRepository repository
                = Injection.Get<ITurmaRepository>();

            Turma turmaAdcionada = repository.Add(t);

            Assert.IsTrue(turmaAdcionada.Id > 0);
        }
    }
}