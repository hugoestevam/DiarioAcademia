using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.IoC;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Modules;
using Ninject;
using Ninject.Parameters;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [TestClass]
    public class TurmaServiceTest
    {
        private ITurmaService _turmaService;
        private ITurmaRepository _repo;
        private IUnitOfWork _uow;

        public TurmaServiceTest()
        {
            _uow = Container.Get<IUnitOfWork>();

            _repo = Container.Get<ITurmaRepository>();

            _turmaService = new TurmaService(_repo, _uow);
        }

        [TestMethod]
        public void Test()
        {

        }
    }
}