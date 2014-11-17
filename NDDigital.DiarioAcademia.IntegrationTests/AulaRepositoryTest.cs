using FluentAssertions;
using NDDigital.DiarioAcademia.Aplicacao.Testes.Traits;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using Xunit;

namespace NDDigital.DiarioAcademia.IntegrationTests
{   
    [RepositorioTrait()]
    public class AulaRepositoryTest : UnitTestContext, IUseFixture<DatabaseFixture>
    {
        private IAulaRepository aulaRepository;
        private IPresencaRepository presencaRepository;

        private IUnitOfWork uow;        

        public void SetFixture(DatabaseFixture databaseFixture)
        {            
            aulaRepository = new AulaRepository(databaseFixture.Factory);
            presencaRepository = new PresencaRepository(databaseFixture.Factory);

            uow = databaseFixture.UnitOfWork;
        }

        [Fact(DisplayName = "Deveria persistir aula no banco de dados")]
        public void Test_1()
        {            
            //arrange
            var aula = new Aula(DateTime.Now);

            //action
            aulaRepository.Add(aula);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(aula.Id);

            aulaEncontrada.Should().NotBeNull();
        }

        [Fact(DisplayName = "Deveria excluir aula e presencas relacionadas")]
        public void Test_2()
        {            
            //arrange
            InsertTestData(TBAula, TBPresenca);

            Aula aula = aulaRepository.GetById(Aula_Id);

            //act
            aulaRepository.Delete(aula);

            uow.Commit();

            //assert
            aulaRepository.GetById(Aula_Id).Should().BeNull();

            presencaRepository.GetById(Presenca_Id).Should().BeNull();
        }

        [Fact(DisplayName = "Deveria atualizar aula no banco de dados")]
        public void Test_3()
        {            
            //arrange
            InsertTestData(TBAula, TBPresenca);

            Aula aula = aulaRepository.GetById(Aula_Id);

            aula.Data = DateTime.Now;            

            //act
            aulaRepository.Update(aula);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(aula.Id);

            aulaEncontrada.ShouldBeEquivalentTo(aula);
        }                      

                
    }
}
