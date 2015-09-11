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
        private const string TestCategory = 
            "Teste de IoC";
        [TestInitialize]
        public void Initialize()
        {
            const string key = "Infrasctructure.DAO";
            const string dll = "NDDigital.DiarioAcademia.Infraestrutura.Orm.dll";

            ConfigurationManager.AppSettings[key] = dll;
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Salva_Turma_IoC_EF_Test()
        {
            Turma t = ObjectBuilder.CreateTurma();

            //Através do IoC Ninject busca um implementação do Repositório
            ITurmaRepository repository
                = Injection.Get<ITurmaRepository>();

            Turma turmaAdcionada = repository.Add(t);

            Assert.IsTrue(turmaAdcionada.Id > 0);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Contexts_IoC_EF_Test()
        {
           

        }
    }
}