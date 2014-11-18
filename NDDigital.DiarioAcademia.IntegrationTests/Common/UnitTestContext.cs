using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        
        protected readonly Guid Aula_Id = Guid.Parse("4064d4ed-f5b4-cb81-d201-08d1ccc21216");
        protected readonly DateTime Aula_Data = new DateTime(2014, 11,13);        

        protected readonly Guid Presenca_Id = Guid.Parse("76545b3e-9b2b-cb1c-524d-08d1cd58e012");

        protected readonly Guid Aluno_Id = Guid.Parse("952c499a-d155-c21d-8788-08d1cc983ea7");

        protected INDbUnitTest _db;

        public UnitTestContext()
        {
            Debug.Write("ctor: NDbUnitTestBase->");
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
            Debug.Write("dispose: NDbUnitTestBase->");

            _db.PerformDbOperation(DbOperationFlag.DeleteAll);
        }
    }
}
