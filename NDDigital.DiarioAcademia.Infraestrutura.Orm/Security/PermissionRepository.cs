using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IList<Permission> GetByGroup(int groupId);
        IList<Permission> GetAllSpecific(string[] permissions);
    }

    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {

        public PermissionRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }

        public IList<Permission> GetAllSpecific(string[] ids)
        {
            var list = new List<Permission>();
            foreach (var id in ids)
            {
                list.Add(dataContext.Permissions.Where(p=>p.PermissionId==id).FirstOrDefault());
            }
            return list;
        }

        public IList<Permission> GetByGroup(int groupId)
        {
            var group = dataContext.Groups.Find(groupId);
            return group.Permissions;
        }
    }

   

}