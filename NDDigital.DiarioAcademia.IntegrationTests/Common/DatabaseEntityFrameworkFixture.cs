using Infrastructure.DAO.ORM.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;

namespace NDDigital.DiarioAcademia.IntegrationTests.Common
{
    public class DatabaseEntityFrameworkFixture : IDisposable
    {
        public EntityFrameworkFactory Factory
        {
            get;
            private set;
        }

        public EntityFrameworkUnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        public DatabaseEntityFrameworkFixture()
        {
            Factory = new EntityFrameworkFactory();

            UnitOfWork = new EntityFrameworkUnitOfWork(Factory);
        }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}