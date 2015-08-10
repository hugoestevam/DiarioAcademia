using System.Data.Entity;

namespace NDDigital.DiarioAcademia.IntegrationTests.Common
{
    public class DatabaseBootstrapper
    {
        private readonly DbContext context;

        public DatabaseBootstrapper(DbContext context)
        {
            this.context = context;
        }

        public void Configure()
        {
            if (context.Database.Exists())
                return;

            context.Database.Create();
        }
    }
}