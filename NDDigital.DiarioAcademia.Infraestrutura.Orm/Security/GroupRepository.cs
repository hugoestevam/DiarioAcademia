using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IGroupRepository : IRepository<Group>
    {
    }

    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IDatabaseFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}