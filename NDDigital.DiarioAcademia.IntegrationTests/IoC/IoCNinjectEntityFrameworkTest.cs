using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.IntegrationTests.Base;

using System.Configuration;

namespace NDDigital.DiarioAcademia.IntegrationTests.IoC
{
    [TestClass]
    public class IoCNinjectEntityFrameworkTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ConfigurationManager.AppSettings["Infrasctructure.DAO"] = "NDDigital.DiarioAcademia.Infraestrutura.Orm.dll";
        }

        [TestMethod]
        [TestCategory("Teste de IoC")]
        public void Save_Turma_IoC_EF_Test()
        {
            Turma t = ObjectBuilder.CreateTurma();

            //Através do IoC Ninject busca um implementação do Repositório
            ITurmaRepository repository
                = Container.Get<ITurmaRepository>();

            Turma turmaAdcionada = repository.Add(t);

            Assert.IsTrue(turmaAdcionada.Id > 0);
        }
    }
}