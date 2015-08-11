using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IList<Permission> GetByGroup(int groupId);
    }

    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {

        public PermissionRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }

        public IList<Permission> GetByGroup(int groupId)
        {
            var group = dataContext.Groups.Find(groupId);
            return group.Permissions;
        }
    }

   

}