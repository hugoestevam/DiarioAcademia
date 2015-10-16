using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using NDDigital.DiarioAcademia.Dominio;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Repositories
{
    public class GroupRepository : RepositoryBaseAuth<Group>, IGroupRepository
    {
        private IUnitOfWork uow;

        public GroupRepository(AuthFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IList<Group> GetAllSpecifically(int[] ids)
        {
            var list = new List<Group>();
            foreach (var id in ids)
            {
                list.Add(DataContext.Groups.FirstOrDefault(p => p.Id == id));
            }
            list.RemoveAll(x => x == null);
            return list;
        }

        public IList<Group> GetByUser(string username)
        {
            Account acc;

            try
            {

                acc = (from a in DataContext.Accounts.Include("Groups")
                       where a.Username == username
                       select a).FirstOrDefault();

            }
            catch (InvalidOperationException)
            {
                return GetByUser(username);
            }
            catch (EntityCommandExecutionException)
            {
                return GetByUser(username);
            }
            catch (EntityException)
            {
                return GetByUser(username);
            }

            if (acc != null)

            return acc.Groups;

            return null;
        }

        public bool IsAdmin(string username)
        {
            var groups = GetByUser(username);

            if (groups == null) return false;

            return groups.Any(g => g.IsAdmin);
        }

        
    }
}