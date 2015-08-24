using Infrastructure.DAO.ORM.Common.Base;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Factorys;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Repositories
{
    public class PresencaRepositoryEF : RepositoryBaseEF<Presenca>, IPresencaRepository
    {
        public PresencaRepositoryEF(UnitOfWorkFactory dbFactory) 
            : base(dbFactory)
        {
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}