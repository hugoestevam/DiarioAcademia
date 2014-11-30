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

        public IEnumerable<Aula> GetAllByTurma(int ano)
        {
            return GetQueryable()
               .Include(x => x.Turma)
               .Where(x => x.Turma.Ano == ano)
               .ToList();
        }
    }
}