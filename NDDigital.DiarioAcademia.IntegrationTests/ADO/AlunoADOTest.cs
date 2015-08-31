using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Common;
using NDDigital.DiarioAcademia.Infraestrutura.SQL.Repositories;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using System.Linq;

namespace NDDigital.DiarioAcademia.IntegrationTests.ADO
{
    [TestClass]
    public class AlunoADOTest
    {
        private AlunoRepositorySql _repoAluno;
        private TurmaRepositorySql _repoTurma;
        private ADOUnitOfWork _uow;

        [TestInitialize]
        public void Initialize()
        {
            new BaseTest();

            var factory = new AdoNetFactory();

            _uow = new ADOUnitOfWork(factory);

            _repoAluno = new AlunoRepositorySql(factory);

            _repoTurma = new TurmaRepositorySql(factory);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Persistir_Aluno_SQL_Test()
        {
            _repoTurma.Add(ObjectBuilder.CreateTurma());

            var turmaEncontrada = _repoTurma.GetById(1);

            var aluno = ObjectBuilder.CreateAluno(turmaEncontrada);

            _repoAluno.Add(aluno);

            var alunos = _repoAluno.GetAll();

            _uow.Commit();

            Assert.AreEqual(2, alunos.Count);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Buscar_Aluno_SQL_Test()
        {
            var alunoEncontrado = _repoAluno.GetById(1);

            Assert.IsNotNull(alunoEncontrado);
            Assert.AreEqual(1, alunoEncontrado.Id);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Editar_Aluno_SQL_Test()
        {
            var alunoEncontrado = _repoAluno.GetById(1);
            alunoEncontrado.Nome = "Alexandre Regis";

            _repoAluno.Update(alunoEncontrado);

            var alunoEditado = _repoAluno.GetById(1);

            _uow.Commit();

            Assert.AreEqual("Alexandre Regis", alunoEditado.Nome);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Buscar_Todas_Alunos_SQL_Test()
        {
            var alunosEncontrados = _repoAluno.GetAll();

            Assert.IsNotNull(alunosEncontrados);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Remover_Aluno_SQL_Test()
        {
            _repoAluno.Delete(1);

            var alunosEncontrados = _repoAluno.GetAll();

            _uow.Commit();

            Assert.IsTrue(alunosEncontrados.Count == 0);
        }
    }
}