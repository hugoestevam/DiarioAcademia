using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class TurmaRepository: RepositoryBase<Turma>, ITurmaRepository
    {
        public TurmaRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
