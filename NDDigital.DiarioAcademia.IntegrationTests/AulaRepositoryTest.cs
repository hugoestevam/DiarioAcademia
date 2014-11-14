using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosRepositories;
using Xunit;
using Xunit.Extensions;
using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentAssertions.Primitives;
using NDDigital.DiarioAcademia.Dominio.Common;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Transactions;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using FizzWare.NBuilder;
using NDDigital.DiarioAcademia.Aplicacao.Testes.Traits;

namespace NDDigital.DiarioAcademia.IntegrationTests
{

    public abstract class NDbUnitTestBase : IDisposable
    {
        private const string XmlSchema = @"..\..\TestData\DiarioAcademia.xsd";

        protected const string TBAluno = @"..\..\TestData\DiarioAcademia.TBAluno.xml";
        protected const string TBAula = @"..\..\TestData\DiarioAcademia.TBAula.xml";
        protected const string TBTurma = @"..\..\TestData\DiarioAcademia.TBTurma.xml";
        protected const string TBPresenca = @"..\..\TestData\DiarioAcademia.TBPresenca.xml";

        protected readonly Guid AulaId = Guid.Parse("4064d4ed-f5b4-cb81-d201-08d1ccc21216");

        protected readonly Guid AlunoId = Guid.Parse("952c499a-d155-c21d-8788-08d1cc983ea7");

        protected INDbUnitTest _db;

        public NDbUnitTestBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DiarioAcademiaContext"].ConnectionString;

            _db = new SqlDbUnitTest(connectionString);
            _db.ReadXmlSchema(XmlSchema);
        }

        public void InsertTestData(params string[] dataFileNames)
        {
            _db.PerformDbOperation(DbOperationFlag.DeleteAll);

            if (dataFileNames == null)
            {
                return;
            }

            try
            {
                foreach (string fileName in dataFileNames)
                {
                    if (!File.Exists(fileName))
                    {
                        throw new FileNotFoundException(Path.GetFullPath(fileName));
                    }
                    _db.ReadXml(fileName);
                    _db.PerformDbOperation(DbOperationFlag.InsertIdentity);
                }
            }
            catch
            {
                _db.PerformDbOperation(DbOperationFlag.DeleteAll);
                throw;
            }
        }

        public void Dispose()
        {
            _db.PerformDbOperation(DbOperationFlag.DeleteAll);
        }
    }

    [RepositorioTrait()]
    public class AulaRepositoryTest : NDbUnitTestBase, IUseFixture<DatabaseFixture>
    {
        private IAulaRepository aulaRepository;
        private IAlunoRepository alunoRepository;        

        private IUnitOfWork uow;

        public void SetFixture(DatabaseFixture databaseFixture)
        {            
            aulaRepository = new AulaRepository(databaseFixture.Factory);
            alunoRepository = new AlunoRepository(databaseFixture.Factory);  

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

        [Fact(DisplayName = "Deveria excluir a aula com base no ID")]
        public void Test_2()
        {
            //arrange
            InsertTestData(TBAula);            

            //act
            aulaRepository.Delete(AulaId);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(AulaId);

            aulaEncontrada.Should().BeNull();
        }

        [Fact(DisplayName = "Deveria excluir a aula com base no objeto")]
        public void Test_4()
        {
            //arrange
            InsertTestData(TBAula);

            Aula aula = new Aula(DateTime.Now);
            aula.ChangeCurrentIdentity(AulaId);

            //act
            aulaRepository.Delete(aula);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(AulaId);

            aulaEncontrada.Should().BeNull();
        }

        
        [Fact(DisplayName = "Deveria atualizar uma aula persistida no banco de dados")]
        public void Test_3()
        {
            //arrange
            InsertTestData(TBAula);

            Aula aula = aulaRepository.GetById(AulaId);

            aula.Data = new DateTime(2000, 10, 10);

            //act
            aulaRepository.Update(aula);

            uow.Commit();

            //assert
            var aulaEncontrada = aulaRepository.GetById(aula.Id);

            aulaEncontrada.ShouldBeEquivalentTo(aula);
        }
       

        [Fact(DisplayName = "Deveria retornar do banco de dados a quantidade de presenças e ausências")]
        public void Deveria_retornar_quantidade_presencas_ausencias()
        {
            //arrange

            InsertTestData(TBAluno, TBAula, TBPresenca, TBTurma);

            //act            
            var alunoEncontrado = alunoRepository.GetById(AlunoId);

            //assert
            alunoEncontrado.ObtemQuantidadePresencas().Should().Be(1);
            alunoEncontrado.ObtemQuantidadeAusencias().Should().Be(1);
        }        
    }
}
