using Infrastructure.DAO.ORM.Common.Base;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{


    public class PermissionRepository : RepositoryBaseEF<Permission>, IPermissionRepository
    {
        public PermissionRepository(EntityFrameworkFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IList<Permission> GetAllSpecific(string[] ids)
        {
            var list = new List<Permission>();
            foreach (var id in ids)
            {
                var permission = DataContext.Permissions.Where(p => p.PermissionId == id).FirstOrDefault();

                list.Add(permission ?? new Permission(id));
            }
            list.RemoveAll(x => x == null);
            return list;
        }

        public IList<Permission> GetByGroup(int groupId)
        {
            var group = DataContext.Groups
                .Include("Permissions")
                .Where(g=>g.Id==groupId)
                .FirstOrDefault();
           
             return group?.Permissions;
        }

        public Permission GetByPermissionId(string id)
        {
            return (from p in DataContext.Permissions where p.PermissionId == id select p).FirstOrDefault(); ;
        }

    }
}