using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
