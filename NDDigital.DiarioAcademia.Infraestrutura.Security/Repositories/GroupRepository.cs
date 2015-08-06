using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Common;
using NDDigital.DiarioAcademia.Infraestrutura.Orm.Contexts;

namespace NDDigital.DiarioAcademia.Infraestrutura.Orm.Identity
{
    public interface IGroupRepository : IRepository<Group>
    {

    }
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
