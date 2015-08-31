using Infrastructure.DAO.ORM.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using NDDigital.DiarioAcademia.IntegrationTests.Base;
using System.Data.Entity;

namespace NDDigital.DiarioAcademia.IntegrationTests.EF
{
    [TestClass]
    public class AlunoEFTest
    {
        public IAlunoRepository _repoAluno;
        public ITurmaRepository _repoTurma;
        public IUnitOfWork _uow;
        public EntityFrameworkFactory _factory;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new BaseTestInitializer());

            _factory = new EntityFrameworkFactory();

            _uow = new EntityFrameworkUnitOfWork(_factory);

            _repoTurma = new TurmaRepositoryEF(_factory);

            _repoAluno = new AlunoRepositoryEF(_factory);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Persistir_Aluno_ORM_Test()
        {
            _repoTurma.Add(ObjectBuilder.CreateTurma());

            _uow.Commit();

            var turmaEncontrada = _repoTurma.GetById(2);

            var aluno = ObjectBuilder.CreateAluno(turmaEncontrada);

            aluno.Turma = turmaEncontrada;

            _repoAluno.Add(aluno);

            _uow.Commit();

            Assert.IsNotNull(aluno);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Buscar_Aluno_ORM_Test()
        {
            var alunoEncontrado = _repoAluno.GetById(1);

            Assert.IsNotNull(alunoEncontrado);
            Assert.AreEqual(1, alunoEncontrado.Id);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Editar_Aluno_ORM_Test()
        {
            var alunoEncontrado = _repoAluno.GetById(1);
            alunoEncontrado.Nome = "Alexandre Regis";

            _repoAluno.Update(alunoEncontrado);

            _uow.Commit();

            var alunoEditada = _repoAluno.GetById(1);

            Assert.AreEqual("Alexandre Regis", alunoEditada.Nome);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Buscar_Todas_Alunos_ORM_Test()
        {
            var alunosEncontrados = _repoAluno.GetAll();

            Assert.IsNotNull(alunosEncontrados);
        }

        [TestMethod]
        [TestCategory("Teste de Integração Aluno")]
        public void Deveria_Remover_Aluno_ORM_Test()
        {
            _repoAluno.Add(new Aluno());

            _uow.Commit();

            var alunosEncontrados = _repoAluno.GetAll();

            Assert.IsTrue(alunosEncontrados.Count == 2);

            _repoAluno.Delete(1);

            _uow.Commit();

            alunosEncontrados = _repoAluno.GetAll();

            Assert.IsTrue(alunosEncontrados.Count == 1);
        }
    }
}