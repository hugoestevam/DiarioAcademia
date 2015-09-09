using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [TestClass]
    public class TurmaServiceTest
    {
        private readonly Mock<ITurmaRepository> _turmaRepository = null;
        private readonly Mock<IUnitOfWork> _unitOfWork = null;
        private ITurmaService _turmaService;

        private const string TestCategory =
            "Teste de Serviço - Turma";

        public TurmaServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _turmaRepository = new Mock<ITurmaRepository>();

            _turmaService = new TurmaService(_turmaRepository.Object, _unitOfWork.Object);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Persistir_Turma_SQL_Test()
        {
            //arrange
            var turma = ObjectBuilder.CreateTurma();

            _turmaRepository
                .Setup(x => x.Add(It.IsAny<Turma>()));

            _unitOfWork.Setup(x => x.Commit());

            //act
            _turmaService.Add(new TurmaDTO(turma));

            //assert
            _turmaRepository.Verify(x => x.Add(It.IsAny<Turma>()), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Turma_SQL_Test()
        {
            //arrange
            _turmaRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(ObjectBuilder.CreateTurma());

            //act
            _turmaService.GetById(1);

            //assert
            _turmaRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Editar_Turma_SQL_Test()
        {
            //arrange
            var turma = ObjectBuilder.CreateTurma();

            turma.Ano = 2016;

            _turmaRepository
                .Setup(x => x.Update(turma));

            _turmaRepository
             .Setup(x => x.GetById(It.IsAny<int>()))
             .Returns(turma);

            _unitOfWork.Setup(x => x.Commit());

            //act
            _turmaService.Update(new TurmaDTO(turma));

            //assert
            _turmaRepository.Verify(x => x.Update(turma), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Todas_Turmas_SQL_Test()
        {
            //arrange
            var turmas = new List<Turma>() { ObjectBuilder.CreateTurma() };

            _turmaRepository
                .Setup(x => x.GetAll())
                .Returns(turmas);

            //act
            _turmaService.GetAll();

            //assert
            _turmaRepository.Verify(x => x.GetAll(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Remover_Turma_SQL_Test()
        {
            //arrange
            _turmaRepository
                .Setup(x => x.Delete(It.IsAny<int>()));

            //act
            _turmaService.Delete(1);

            _unitOfWork.Setup(x => x.Commit());

            //assert
            _turmaRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }
    }
}