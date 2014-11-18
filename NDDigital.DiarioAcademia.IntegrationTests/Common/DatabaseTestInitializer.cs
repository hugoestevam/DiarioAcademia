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
    public class DatabaseTestInitializer : DropCreateDatabaseIfModelChanges<DiarioAcademiaContext>
    {
        protected override void Seed(DiarioAcademiaContext context)
        {
            context.Aulas.Add(new Aula(DateTime.Now));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
