using NDDigital.DiarioAcademia.Dominio.Entities;
using NDDigital.DiarioAcademia.Dominio.Entities.Security;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Dominio.Contracts
{
    public interface IGroupRepository : IRepository<Group>
    { IList<Group> GetAllSpecific(int[] groups);
    }
}