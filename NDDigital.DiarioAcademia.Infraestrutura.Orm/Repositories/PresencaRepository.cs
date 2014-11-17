using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class PresencaRepository : RepositoryBase<Presenca>, IPresencaRepository
    {
        public PresencaRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }       
    }
}