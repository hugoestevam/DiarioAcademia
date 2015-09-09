using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDDigital.DiarioAcademia.Aplicacao.DTOs;
using NDDigital.DiarioAcademia.Aplicacao.Services;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.UnitTests.Servicos
{
    [TestClass]
    public class AlunoServiceTest
    {
        private readonly Mock<IAlunoRepository> _alunoRepository = null;
        private readonly Mock<ITurmaRepository> _turmaRepository = null;
        private readonly Mock<IUnitOfWork> _unitOfWork = null;
        private IAlunoService _alunoService;

        private const string TestCategory =
            "Teste de Serviço - Aluno";

        public AlunoServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _alunoRepository = new Mock<IAlunoRepository>();

            _turmaRepository = new Mock<ITurmaRepository>();

            _alunoService = new AlunoService(_alunoRepository.Object, _turmaRepository.Object, _unitOfWork.Object);
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Persistir_Aluno_SQL_Test()
        {
            //arrange
            var aluno = ObjectBuilder.CreateAluno();

            aluno.Turma = ObjectBuilder.CreateTurma();

            _alunoRepository
                .Setup(x => x.Add(It.IsAny<Aluno>()));

            _unitOfWork.Setup(x => x.Commit());

            //act
            _alunoService.Add(new AlunoDTO(aluno));

            //assert
            _alunoRepository.Verify(x => x.Add(It.IsAny<Aluno>()), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Aluno_SQL_Test()
        {
            //arrange
            _alunoRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(ObjectBuilder.CreateAluno());

            //act
            _alunoService.GetById(1);

            //assert
            _alunoRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Editar_Aluno_SQL_Test()
        {
            //arrange
            var aluno = ObjectBuilder.CreateAluno();

            aluno.Nome = "Alex Regis";

            _alunoRepository
                .Setup(x => x.Update(aluno));

            _alunoRepository
             .Setup(x => x.GetById(It.IsAny<int>()))
             .Returns(aluno);

            _unitOfWork.Setup(x => x.Commit());

            //act
            _alunoService.Update(new AlunoDTO(aluno));

            //assert
            _alunoRepository.Verify(x => x.Update(aluno), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Buscar_Todas_Alunos_SQL_Test()
        {
            //arrange
            var alunos = new List<Aluno>() { ObjectBuilder.CreateAluno() };

            _alunoRepository
                .Setup(x => x.GetAll())
                .Returns(alunos);

            //act
            _alunoService.GetAll();

            //assert
            _alunoRepository.Verify(x => x.GetAll(), Times.Once());
        }

        [TestMethod]
        [TestCategory(TestCategory)]
        public void Deveria_Remover_Aluno_SQL_Test()
        {
            //arrange
            _alunoRepository
                .Setup(x => x.Delete(It.IsAny<int>()));

            //act
            _alunoService.Delete(1);

            _unitOfWork.Setup(x => x.Commit());

            //assert
            _alunoRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());

            _unitOfWork.Verify(x => x.Commit(), Times.Once());
        }
    }
}
