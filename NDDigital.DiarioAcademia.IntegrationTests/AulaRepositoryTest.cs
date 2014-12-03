using FluentAssertions;
using NDDigital.DiarioAcademia.Aplicacao.Testes.Traits;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using NDDigital.DiarioAcademia.IntegrationTests.Common;
using System;
using Xunit;

namespace NDDigital.DiarioAcademia.IntegrationTests
{   
    [RepositorioTrait()]
    public class AulaRepositoryTest : UnitTestContext, IUseFixture<DatabaseFixture>
    {
        private IAulaRepository aulaRepository;
        private IPresencaRepository presencaRepository;
        private TurmaRepository turmaRepository;   

        private IUnitOfWork uow;             

        public void SetFixture(DatabaseFixture databaseFixture)
        {            
            aulaRepository = new AulaRepository(databaseFixture.Factory);
            turmaRepository = new TurmaRepository(databaseFixture.Factory);
            presencaRepository = new PresencaRepository(databaseFixture.Factory);

            uow = databaseFixture.UnitOfWork;
        }

        [Fact(DisplayName = "Deveria gravar aula")]
        public void Test_1()
        {
            //arrange
            InsertTestData(TBTurma);

            var turma = turmaRepository.GetById(TURMA_ID);
            
            var aula = new Aula(DateTime.Now, turma);

            //action
            aulaRepository.Add(aula);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(aula.Id);

            aulaEncontrada.Should().NotBeNull();
        }

        [Fact(DisplayName = "Deveria excluir aula e presencas relacionadas"), ]
        public void Test_2()
        {            
            //arrange
            InsertTestData(TBAula, TBPresenca, TBAluno, TBTurma);

            Aula aula = aulaRepository.GetByIdIncluding(AULA_ID, x => x.Presencas);

            //act
            aulaRepository.Delete(aula);

            uow.Commit();

            //assert
            aulaRepository.GetById(AULA_ID).Should().BeNull();

            presencaRepository.GetById(PRESENCA_ID).Should().BeNull();
        }

        [Fact(DisplayName = "Deveria atualizar aula")]
        public void Test_3()
        {            
            //arrange
            InsertTestData(TBAula, TBTurma, TBPresenca);

            Aula aula = aulaRepository.GetById(AULA_ID);

            aula.Data = DateTime.Now;            

            //act
            aulaRepository.Update(aula);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(aula.Id);

            aulaEncontrada.ShouldBeEquivalentTo(aula);
        }

        [Fact(DisplayName = "Deveria buscar todas aulas")]
        public void Test_4()
        {
            //arrange
            InsertTestData(TBAula);

            //action
            var aulas = aulaRepository.GetAll();

            //assert
            aulas.Should().HaveCount(3);
        }

        [Fact(DisplayName = "Deveria buscar aulas por data")]
        public void Test_5()
        {
            //arrange
            InsertTestData(TBAula);

            //action
            var aula = aulaRepository.GetByData(AULA_DATA);

            //assert
            aula.Should().NotBeNull();
        } 
    }
}
