using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories
{
    public class PermissionRepository : RepositoryBaseAuth<Permission>, IPermissionRepository
    {
        public PermissionRepository(AuthFactory dbFactory)
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
                .Where(g => g.Id == groupId)
                .FirstOrDefault();

            //return group?.Permissions;  todo: c# 6
            return group != null ? group.Permissions : new List<Permission>();
        }

        public Permission GetByPermissionId(string id)
        {
            return (from p in DataContext.Permissions where p.PermissionId == id select p).FirstOrDefault(); ;
        }

    }

}
