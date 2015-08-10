using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class TurmaRepositoryEF : RepositoryBase<Turma>, ITurmaRepository
    {
        public TurmaRepositoryEF(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}