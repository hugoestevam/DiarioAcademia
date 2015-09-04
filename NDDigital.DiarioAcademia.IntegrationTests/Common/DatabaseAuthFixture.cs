using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using System;

namespace NDDigital.DiarioAcademia.IntegrationTests.Common
{
    public class DatabaseAuthFixture : IDisposable
    {
        public AuthFactory Factory
        {
            get;
            private set;
        }

        public AuthUnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        public DatabaseAuthFixture()
        {
            Factory = new AuthFactory();

            UnitOfWork = new AuthUnitOfWork(Factory);
        }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}