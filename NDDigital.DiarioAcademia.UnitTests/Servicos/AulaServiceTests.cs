using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using System;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [TestClass]
    public class AulaServiceTest
    {
        private readonly Mock<IAulaRepository> _aulaRepository = null;
        private readonly Mock<IAlunoRepository> _alunoRepository = null;
        private readonly Mock<ITurmaRepository> _turmaRepository = null;
        private readonly Mock<IUnitOfWork> _unitOfWork = null;
        private IAulaService _aulaService;

        private const string TestCategory =
            "Teste de Serviço - Aula";

        public Mock<ITurmaRepository> TurmaRepository
        {
            get
            {
                return _turmaRepository;
            }
        }

        public AulaServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _aulaRepository = new Mock<IAulaRepository>();

            _alunoRepository = new Mock<IAlunoRepository>();

            _turmaRepository = new Mock<ITurmaRepository>();

            _aulaService = new AulaService(_aulaRepository.Object,  
                _alunoRepository.Object, _turmaRepository.Object, _unitOfWork.Object);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Persistir_Aula_SQL_Test()
        {
            //arrange
            var aula = ObjectBuilder.CreateAula();

            aula.Turma = ObjectBuilder.CreateTurma();

            _aulaRepository
                .Setup(x => x.Add(It.IsAny<Aula>()));

            _unitOfWork.Setup(x => x.Commit());

            //act
            _aulaService.Add(new AulaDTO(aula));

            //assert
            _aulaRepository.Verify(x => x.Add(It.IsAny<Aula>()), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Aula_SQL_Test()
        {
            //arrange
            _aulaRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(ObjectBuilder.CreateAula());

            //act
            _aulaService.GetById(1);

            //assert
            _aulaRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Editar_Aula_SQL_Test()
        {
            //arrange
            var aula = ObjectBuilder.CreateAula();

            aula.Data = DateTime.Now;

            _aulaRepository
                .Setup(x => x.Update(aula));

            _aulaRepository
             .Setup(x => x.GetById(It.IsAny<int>()))
             .Returns(aula);

            _unitOfWork.Setup(x => x.Commit());

            //act
            _aulaService.Update(new AulaDTO(aula));

            //assert
            _aulaRepository.Verify(x => x.Update(aula), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Todas_Aulas_SQL_Test()
        {
            //arrange
            var aulas = new List<Aula>() { ObjectBuilder.CreateAula() };

            _aulaRepository
                .Setup(x => x.GetAll())
                .Returns(aulas);

            //act
            _aulaService.GetAll();

            //assert
            _aulaRepository.Verify(x => x.GetAll(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Remover_Aula_SQL_Test()
        {
            //arrange
            _aulaRepository
                .Setup(x => x.Delete(It.IsAny<int>()));

            //act
            _aulaService.Delete(1);

            _unitOfWork.Setup(x => x.Commit());

            //assert
            _aulaRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }
    }
}