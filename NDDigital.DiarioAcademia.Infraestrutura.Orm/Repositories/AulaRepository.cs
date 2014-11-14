using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class AulaRepository : RepositoryBase<Aula>, IAulaRepository
    {
        public AulaRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }


        public Aula GetByData(DateTime data)
        {
            return GetQueryable().FirstOrDefault(x => x.Data.Equals(data));
        }

        

        public override void Delete(Aula entity)
        {
            base.Delete(entity);

            var presencas = dataContext
                .Presencas
                .Where(p => p.Aula.Equals(entity))
                .ToList();

            foreach (var p in presencas)
            {
                dataContext.Presencas.Remove(p);
            }

        }

        

       

    }
}