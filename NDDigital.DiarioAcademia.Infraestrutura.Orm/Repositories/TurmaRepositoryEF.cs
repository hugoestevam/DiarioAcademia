using Infrastructure.DAO.ORM.Common.Base;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class TurmaRepositoryEF : RepositoryBaseEF<Turma>, ITurmaRepository
    {
        public TurmaRepositoryEF(UnitOfWorkFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}