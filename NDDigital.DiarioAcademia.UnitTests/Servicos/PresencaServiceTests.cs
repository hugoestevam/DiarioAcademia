using FizzWare.NBuilder;
using Moq;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Testes.Traits;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Exceptions;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [AplicacaoTrait("")]
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

            aulaService = new AulaService(_aulaRepository.Object, _alunoRepository.Object, _turmaRepository.Object, _unitOfWork.Object  );
        }

        [Fact(DisplayName = "RegistraPresenca deveria persistir as presenças dos alunos")]
        public void Test_1()
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

        [Fact(DisplayName = "RegistraPresenca deveria lançar exceção AlunoNaoEncontrado")]
        public void Test_2()
        {
            //arrange
            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(null as List<Aluno>);

            var comando = new ChamadaDTO { AnoTurma = 2000 };
            
            // act
            Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => { aulaService.RealizaChamada(comando); }));

            // assert
            Assert.IsType(typeof(AlunoNaoEncontrado), ex);            
                        
            //Assert.Throws<AlunoNaoEncontrado>(() => presencaService.RegistraPresenca(comando));
        }

        [Fact(DisplayName = "RegistraPresenca deveria lançar exceção AulaNaoEncontrado")]
        public void Test_3()
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
            Exception ex = Record.Exception(new Assert.ThrowsDelegate(() => aulaService.RealizaChamada(comando)));

            //assert
            Assert.IsType<AulaNaoEncontrada>(ex);
        }

        
    }
}