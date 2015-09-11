using NDDigital.DiarioAcademia.Dominio;
using NDDigital.DiarioAcademia.Infraestrutura.Security.Entities;
using System.Collections.Generic;

namespace NDDigital.DiarioAcademia.Infraestrutura.Security.Contracts
{
    public interface IGroupRepository : IRepository<Group>
    {
        IList<Group> GetAllSpecifically(int[] groups);

        IList<Group> GetByUser(string username);

        bool IsAdmin(string username);
    }
}