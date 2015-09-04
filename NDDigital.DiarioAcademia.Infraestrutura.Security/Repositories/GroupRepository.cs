using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
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
    public class GroupRepository : RepositoryBaseAuth<Group>, IGroupRepository
    {
        private IUnitOfWork uow;

        public GroupRepository(AuthFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IList<Group> GetAllSpecific(int[] ids)
        {
            var list = new List<Group>();
            foreach (var id in ids)
            {
                list.Add(DataContext.Groups.FirstOrDefault(p => p.Id == id));
            }
            list.RemoveAll(x => x == null);
            return list;
        }
    }
}
