using Infrastructure.DAO.ORM.Common.Base;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Dominio.Contracts;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using NDDigital.DiarioAcademia.Infraestrutura.DAO.Common.Uow;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using System.Collections.Generic;
using System.Linq;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Security
{

    public class GroupRepository : RepositoryBaseEF<Group>, IGroupRepository
    {
        private IUnitOfWork uow;

        public GroupRepository(EntityFrameworkFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IList<Group> GetAllSpecific(int[] ids)
        {
            var list = new List<Group>();
            foreach (var id in ids)
            {
                list.Add(DataContext.Groups.Where(p => p.Id == id).FirstOrDefault());
            }
            list.RemoveAll(x => x == null);
            return list;
        }
    }
}