using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
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

        public IList<Permission> GetByUser(string username)
        {

            Account acc;
            //TODO: rever implementação
            try {
                acc = dataContext.Accounts.Include("Groups").Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception ex) {
                dataContext = new Contexts.AuthContext();
                return GetByUser(username);
            }

            var list = new List<Permission>();

            foreach (var group in acc.Groups)
            {
                var listPermissions = DataContext.Groups.Include("Permissions").Where(g => g.Id == group.Id).FirstOrDefault().Permissions;

                list.AddRange(listPermissions);

                list = list.Distinct().ToList();
            }
            return list;
        }
    }
}
