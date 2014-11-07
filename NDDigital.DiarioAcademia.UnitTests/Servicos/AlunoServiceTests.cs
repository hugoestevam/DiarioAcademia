using FizzWare.NBuilder;
using Moq;
using NDDigital.DiarioAcademia.Aplicacao;
using NDDigital.DiarioAcademia.Aplicacao.Testes.Traits;
using NDDigital.DiarioAcademia.CommandQuery;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [AplicacaoTrait("")]
    public class AlunoServiceTests
    {
        private readonly Mock<IAlunoRepository> _alunoRepository = null;
        private readonly Mock<IAulaRepository> _aulaRepository = null;
        private readonly Mock<IUnitOfWork> _unitOfWork = null;

        private IPresencaService presencaService = null;

        public AlunoServiceTests()
        {
            _alunoRepository = new Mock<IAlunoRepository>();
            _aulaRepository = new Mock<IAulaRepository>();

            _unitOfWork = new Mock<IUnitOfWork>();

            presencaService = new PresencaService(_unitOfWork.Object, _alunoRepository.Object, _aulaRepository.Object);
        }

        [Fact(DisplayName = "RegistraPresenca deveria persistir as presenças dos alunos")]
        public void Test_1()
        {
            //arrange
            int qtdAlunos = 5;

            var alunos = Builder<Aluno>.CreateListOfSize(qtdAlunos).Build();

            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(alunos);

            _aulaRepository
                .Setup(x => x.GetByData(It.IsAny<DateTime>()))
                .Returns(new Aula(DateTime.Now));

            RegistraPresencaCommand comando = ObjectMother.MontaRegistraPresencaCommand(alunos.Select(x => x.Id));

            //act
            presencaService.RegistraPresenca(comando);

            //assert
            _alunoRepository.Verify(x => x.Update(It.IsAny<Aluno>()), Times.Exactly(5));

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [Fact(DisplayName = "RegistraPresenca deveria lançar exceção AlunoNaoEncontrado")]
        public void Test_2()
        {
            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(null as List<Aluno>);

            var comando = new RegistraPresencaCommand { AnoTurma = 2000 };

            Assert.Throws<AlunoNaoEncontrado>(() => presencaService.RegistraPresenca(comando));
        }

        [Fact(DisplayName = "RegistraPresenca deveria lançar exceção AulaNaoEncontrado")]
        public void Test_3()
        {
            int qtdAlunos = 5;

            var alunos = Builder<Aluno>.CreateListOfSize(qtdAlunos).Build();

            _alunoRepository
                .Setup(x => x.GetAllByTurma(It.IsAny<int>()))
                .Returns(alunos);

            _aulaRepository
                .Setup(x => x.GetByData(It.IsAny<DateTime>()))
                .Returns(null as Aula);

            var comando = new RegistraPresencaCommand { AnoTurma = 2000 };

            Assert.Throws<AulaNaoEncontrada>(() => presencaService.RegistraPresenca(comando));
        }
    }
}