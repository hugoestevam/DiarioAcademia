﻿using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;
using System.Linq;

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
            catch (System.InvalidOperationException)
            {
                return GetByUser(username);
            }

            

            return acc?.Groups;
        }

        public bool IsAdmin(string username)
        {
            var groups = GetByUser(username);

            return groups.Any(g => g.IsAdmin);
        }
    }
}