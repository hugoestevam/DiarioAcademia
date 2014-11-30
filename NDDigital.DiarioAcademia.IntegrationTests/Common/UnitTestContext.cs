using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.IntegrationTests.Common
{
    public abstract class UnitTestContext : IDisposable
    {
        private const string XmlSchema = @"..\..\TestData\DiarioAcademia.xsd";

        protected const string TBAluno = @"..\..\TestData\DiarioAcademia.TBAluno.xml";
        protected const string TBAula = @"..\..\TestData\DiarioAcademia.TBAula.xml";
        protected const string TBTurma = @"..\..\TestData\DiarioAcademia.TBTurma.xml";
        protected const string TBPresenca = @"..\..\TestData\DiarioAcademia.TBPresenca.xml";

        protected readonly int AULA_ID = 1;
        protected readonly DateTime AULA_DATA = new DateTime(2014, 11,13);

        protected readonly int PRESENCA_ID = 1;

        protected readonly int ALUNO_ID = 1;

        protected readonly int TURMA_ID = 1;

        protected INDbUnitTest _db;

        public UnitTestContext()
        {            
            new DatabaseBootstrapper(new DiarioAcademiaContext()).Configure();

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
}
