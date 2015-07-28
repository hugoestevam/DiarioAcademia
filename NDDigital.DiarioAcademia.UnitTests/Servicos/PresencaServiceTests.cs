using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.ORM.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [TestClass]
    public class PresencaServiceTests
    {
        private readonly Mock<IAlunoRepository> _alunoRepository = null;
        private readonly Mock<IAulaRepository> _aulaRepository = null;
        private readonly Mock<ITurmaRepository> _turmaRepository = null;
        private readonly Mock<IUnitOfWork> _unitOfWork = null;

        private IAulaService aulaService = null;

        public PresencaServiceTests()
        {
            _alunoRepository = new Mock<IAlunoRepository>();
            _aulaRepository = new Mock<IAulaRepository>();
            _turmaRepository = new Mock<ITurmaRepository>();

            _unitOfWork = new Mock<IUnitOfWork>();

            aulaService = new AulaService(_aulaRepository.Object, _alunoRepository.Object, _turmaRepository.Object, _unitOfWork.Object);
        }

        [TestMethod]
        [TestCategory("Camada de Serviço")]
        public void RegistraPresenca_deveria_persistir_as_presencas_dos_alunos()
        {
            //arrange
            int qtdAlunos = 5;

            var alunos = ObjectMother.CriaListaAlunos(qtdAlunos);

            var comando = ObjectMother.CriaRegistraPresencaCommand(alunos.Select(x => x.Id));

            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(alunos);

            _aulaRepository
                .Setup(x => x.GetByData(It.IsAny<DateTime>()))
                .Returns(new Aula(DateTime.Now, new Turma(2014)));

            //act
            aulaService.RealizaChamada(comando);

            //assert
            _alunoRepository.Verify(x => x.Update(It.IsAny<Aluno>()), Times.Exactly(5));

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory("Camada de Serviço")]
        public void RegistraPresenca_deveria_lancar_excecao_AlunoNaoEncontrado()
        {
            //arrange
            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(null as List<Aluno>);

            var comando = new ChamadaDTO { AnoTurma = 2000 };

            // act
            //Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => { aulaService.RealizaChamada(comando); })); TODO: Implementar

            // assert
            //Assert.IsType(typeof(AlunoNaoEncontrado), ex);

            //Assert.Throws<AlunoNaoEncontrado>(() => presencaService.RegistraPresenca(comando));
        }

        [TestMethod]
        [TestCategory("Camada de Serviço")]
        public void RegistraPresenca_deveria_lancar_excecao_AulaNaoEncontrado()
        {
            //arrange
            int qtdAlunos = 1;

            var alunos = ObjectMother.CriaListaAlunos(qtdAlunos);

            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(alunos);

            _aulaRepository
                .Setup(x => x.GetByData(It.IsAny<DateTime>()))
                .Returns(null as Aula);

            var comando = new ChamadaDTO { AnoTurma = 2000 };

            //act
            //Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => aulaService.RealizaChamada(comando))); TODO: Implementar

            //assert
            //Assert.IsType<AulaNaoEncontrada>(ex);
        }
    }
}