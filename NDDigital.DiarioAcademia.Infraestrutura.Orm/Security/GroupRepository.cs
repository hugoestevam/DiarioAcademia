using System;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{
    public interface IGroupRepository : IRepository<Group>
    {
        IList<Group> GetAllSpecific(int[] groups);
    }

    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        private UnitOfWork uow;

        public GroupRepository(IDatabaseFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IList<Group> GetAllSpecific(int[] ids)
        {
            var list = new List<Group>();
            foreach (var id in ids)
            {
                list.Add(dataContext.Groups.Where(p => p.Id == id).FirstOrDefault());
            }
            list.RemoveAll(x => x == null);
            return list;
        }
    }
}