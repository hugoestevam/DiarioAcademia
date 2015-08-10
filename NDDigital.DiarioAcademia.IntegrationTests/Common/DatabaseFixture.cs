using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;

namespace NDDigital.DiarioAcademia.IntegrationTests.Common
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFactory Factory
        {
            get;
            private set;
        }

        public UnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        public DatabaseFixture()
        {
            Factory = new DatabaseFactory();

            UnitOfWork = new UnitOfWork(Factory);
        }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}